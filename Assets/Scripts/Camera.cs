using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Camera : MonoBehaviour {

	public float rotMult;
	public float speed;
	public float jump;
	public float jumpDelay;
	private float jumpTimer = 0f;
	public int tummy = 0;

	public Image bit0;
	public Image bit1;
	public Image bit2;
	public Image bit3;
	public AudioSource player;
	public AudioClip eat;
	public AudioClip burp;
	
	// Use this for initialization
	void Start () {
		bit0.enabled = bit1.enabled = bit2.enabled = bit3.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Rotate (Vector3.down * Time.deltaTime * rotMult);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Rotate (Vector3.up * Time.deltaTime * rotMult);
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			GetComponent<Rigidbody> ().AddForce (transform.forward * speed);
			if (Time.time >= jumpTimer) {
				Jump ();
			}
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			GetComponent<Rigidbody> ().AddForce (-transform.forward * speed);
		}

//		if (GetComponent<Rigidbody> ().velocity.magnitude > 0 && GetComponent<Rigidbody> ().velocity.magnitude < 10 && Time.time >= jumpTimer) {
//			GetComponent<Rigidbody>().AddForce(transform.up * jump);
//			jumpTimer = Time.time + jumpDelay;
//		}
	}

	void Jump() {
		//GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ;
		GetComponent<Rigidbody>().velocity += (Vector3.up * jump);
		jumpTimer = Time.time + jumpDelay;
//		GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
//		GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX;
//		GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY;
	}

	void OnTriggerEnter (Collider coll)
	{
		if (coll.gameObject.tag == "Burger") {
			print("yum");
			Destroy(coll.gameObject);
		}
	}

	public void CollectedFood() {
		player.clip = eat;
		player.Play();
//		player.clip = burp;
//		player.Play();
		tummy++;
		if (tummy == 1) bit0.enabled = true;
		if (tummy == 2) bit1.enabled = true;
		if (tummy == 3) bit2.enabled = true;
		if (tummy == 4) bit3.enabled = true;
	}
}
