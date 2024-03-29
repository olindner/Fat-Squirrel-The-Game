using UnityEngine;
using System.Collections;

public class FloatUpAndDown : MonoBehaviour {
	private float origY;
	public float speed;
	public float distance;
	public bool spin;
	public float spinSpeed;
//	private float timer;
//	public int timeUntilRespawn;
	//public GameObject go;

	void Start () {
		origY = transform.position.y;
	}

	void Update ()
	{
//		if (!GetComponent<Collider>().enabled) {
//			timer -= Time.deltaTime;
//			if (timer <= 0) {
//				timer = 0;
//				gameObject.GetComponent<Collider>().enabled = true;
//				Renderer[] rs = gameObject.GetComponentsInChildren<Renderer> ();
//				foreach (Renderer r in rs) {
//					r.enabled = true;
//				}
//			}
//		}
		//Hover up and down
		if(Mathf.Abs(transform.position.y - origY) > distance) {
			speed = -speed; //flip direction
		}

		transform.Translate(0,speed*Time.deltaTime,0);

		//Rotation element
		if (spin) {
			transform.Rotate(Vector3.up * Time.deltaTime * spinSpeed);
		}
	}

	void OnTriggerEnter (Collider coll)
	{
		if (coll.tag == "Squirrel" && Squirrel.instance.tummy <= 3 && (tag == "Burger" || tag == "Fries")) {
			coll.gameObject.GetComponent<Squirrel> ().CollectedFood ();
//			gameObject.GetComponent<Collider>().enabled = false;
//			Renderer[] rs = gameObject.GetComponentsInChildren<Renderer> ();
//			foreach (Renderer r in rs) {
//				r.enabled = false;
//			}
//			timer = timeUntilRespawn;
			foreach (Transform child in transform) {
				Destroy(child.gameObject);
			}
			Destroy(gameObject);
		}
	}
}
