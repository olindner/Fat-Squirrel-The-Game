using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Squirrel : MonoBehaviour {

	public float rotMult;
	public float speed;
	public float maxSpeed = 15f;
	public float boost = 5f;
	public float gameTimer = 300f;
//	public float jump;
//	public float jumpDelay;
	//private float jumpTimer = 0f;
	public int tummy = 0;
	public bool inTree = false;
	private Quaternion saveAngle;

	public Image bit0;
	public Image bit1;
	public Image bit2;
	public Image bit3;
	public Image red;
	public Image health1;
	public Image health2;
	public Image health3;
	private float hurtTimer = 0f;
	public AudioSource player;
	public AudioClip eat;
	public AudioClip burp;
	public AudioClip hurt;
	public AudioClip ding;
	public Text SpaceToExitText;
	public Text WarnText;

	public GameObject[] food;
	private int filled = 0;

	private int health = 3;
	public static Squirrel instance;
	
	// Use this for initialization
	void Start ()
	{
		bit0.enabled = bit1.enabled = bit2.enabled = bit3.enabled = false;
		health1.enabled = health2.enabled = health3.enabled = true;
		SpaceToExitText.enabled = false;
		instance = this;
		red.enabled = false;
		WarnText.enabled = false;

		foreach (GameObject g in food) {
			g.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{

		gameTimer -= Time.deltaTime;
		if (gameTimer < 60f) {
			WarnText.enabled = true;
		}
		if (gameTimer < 50f)
			WarnText.enabled = false;
		if (gameTimer <= 0f)
			Application.LoadLevel ("DeathFreeze");

		if (hurtTimer > 0f) {
//			Color temp = Color.red;
//			temp.a = 80f;
//			red.material.color = temp;
			red.enabled = true;
			hurtTimer -= Time.time;
		} else
			red.enabled = false;

		if (!inTree) {
			if (Input.GetKey (KeyCode.LeftArrow)) {
				transform.Rotate (Vector3.down * Time.deltaTime * rotMult);
			}
			if (Input.GetKey (KeyCode.RightArrow)) {
				transform.Rotate (Vector3.up * Time.deltaTime * rotMult);
			}
			if (Input.GetKey (KeyCode.UpArrow)) {
				GetComponent<Rigidbody> ().AddForce (transform.forward * speed);
				if (GetComponent<Rigidbody> ().velocity.magnitude > maxSpeed)
					GetComponent<Rigidbody> ().velocity = GetComponent<Rigidbody> ().velocity.normalized * maxSpeed;
//				if (Time.time >= jumpTimer) {
//					Jump ();
//				}
			}
			if (Input.GetKey (KeyCode.DownArrow)) {
				GetComponent<Rigidbody> ().AddForce (-transform.forward * speed);
				if (GetComponent<Rigidbody> ().velocity.magnitude > maxSpeed)
					GetComponent<Rigidbody> ().velocity = GetComponent<Rigidbody> ().velocity.normalized * maxSpeed;
			}
			if ((Input.GetKeyDown (KeyCode.LeftShift) || Input.GetKeyDown (KeyCode.RightShift)) && tummy >= 1) {
				UseFood ();
			}
			if (Input.GetKey (KeyCode.LeftControl) || Input.GetKey (KeyCode.RightControl)) {
				transform.GetChild(0).transform.eulerAngles = new Vector3(0f, (transform.eulerAngles.y + 180f) % 360f, 0f);
			}
			if (Input.GetKeyUp (KeyCode.LeftControl) || Input.GetKeyUp (KeyCode.RightControl)) {
				transform.GetChild(0).transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);
			}

		} else { //is in tree
			if (Input.GetKey (KeyCode.Space)) { //press Space to exit tree
				inTree = false;
				SpaceToExitText.enabled = false;
				transform.position = new Vector3(transform.position.x, transform.position.y - 10f, transform.position.z); //move back down to floor
				GetComponent<Rigidbody>().useGravity = true; //enable gravity
				transform.rotation = saveAngle; //reset original camera angle
				GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None; //unfreeze
				GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ; //back to normal
			}
		}
	}

//	void Jump() {
//		//GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ;
//		GetComponent<Rigidbody>().velocity += (Vector3.up * jump);
//		//jumpTimer = Time.time + jumpDelay;
////		GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
////		GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
//	}

	void OnTriggerEnter (Collider coll)
	{
		if (coll.gameObject.name == "Trunk") { //next to a tree
			inTree = true;
			SpaceToExitText.enabled = true;
			saveAngle = transform.rotation; //save camera angle
			GetComponent<Rigidbody> ().useGravity = false; //disable gravity
			float randx = Random.Range (5f, 10f);
			if (randx < 7.5f)
				randx *= -1; //50% chance to make negative
			float randz = Random.Range (5f, 10f);
			if (randz < 7.5f)
				randz *= -1; //50% chance to make negative
			transform.position = new Vector3 (transform.position.x + randx, transform.position.y + 10f, transform.position.z + randz); //Move up, out, and angle down
			GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll; //freeze everything
			transform.LookAt (coll.gameObject.transform);//look at tree
		}
		if (coll.gameObject.tag == "Dog" && coll.GetType () == typeof(BoxCollider)) { //seen by dog
			//print ("I see you squirrel scum!");
			coll.gameObject.GetComponent<Dog> ().chasing = true;
			coll.gameObject.GetComponent<Dog> ().stored = new Vector3 (coll.gameObject.transform.position.x, coll.gameObject.transform.position.y, coll.gameObject.transform.position.z);
			coll.gameObject.GetComponent<Dog> ().player.Play ();
		}
		if (coll.gameObject.tag == "Dog" && coll.GetType () == typeof(SphereCollider)) { //bit by dog
			foreach (Transform child in coll.gameObject.transform) {
				Destroy(child.gameObject);
			}
			Destroy(coll.gameObject);

			health--;
			player.clip = hurt;
			player.Play ();
			hurtTimer = 400f;
			if (health == 2)
				health3.enabled = false;
			if (health == 1)
				health2.enabled = false;
			if (health == 0) {
				health1.enabled = false;
				Application.LoadLevel("DeathByDog");
			}

		}
		if (coll.gameObject.tag == "Stockpile" && tummy > 0) {
			player.clip = ding;
			player.Play();
			for (int i = filled; i < filled + tummy; ++i) {
				food[i].SetActive(true);
				if (i == 9) Application.LoadLevel("Win");
			}
			filled += tummy;
			tummy = 0;
			GetComponent<Rigidbody>().drag = 0;
			bit0.enabled = bit1.enabled = bit2.enabled = bit3.enabled = false;
		}
	}

	public void CollectedFood ()
	{
		player.clip = eat;
		player.Play ();
//		yield return new WaitForSeconds (2);
//		player.clip = burp;
//		player.Play ();
		if (tummy <= 3) tummy++;
		if (tummy == 1) {
			bit0.enabled = true;
		} else if (tummy == 2) {
			bit1.enabled = true;
		} else if (tummy == 3) {
			bit2.enabled = true;
		} else if (tummy == 4) {
			bit3.enabled = true;
		}
		GetComponent<Rigidbody>().drag++;
	}

	void UseFood() {
		player.clip = burp;
		player.Play();
		tummy--;
		if (tummy == 0) {
			bit0.enabled = false;
		} else if (tummy == 1) {
			bit1.enabled = false;
		} else if (tummy == 2) {
			bit2.enabled = false;
		} else if (tummy == 3) {
			bit3.enabled = false;
		}
		//GetComponent<Rigidbody> ().AddForce (transform.forward * boost);
		GetComponent<Rigidbody>().drag--;
	}
}
