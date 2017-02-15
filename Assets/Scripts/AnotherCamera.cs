using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnotherCamera : MonoBehaviour {

	//public GameObject player;
	public float speed = 5f;

	// Use this for initialization
	void Start () {
		//transform.Rotate(0, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0);
		transform.rotation = Quaternion.identity;
	}
	
	// Update is called once per frame
	void Update () {
		//transform.rotation = Quaternion.identity;
		//transform.Rotate(0, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0);

		transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0);

//		Vector3 forward = player.transform.forward.normalized;
//		transform.position = new Vector3(player.transform.position.x + (-1*forward.x*mult), transform.position.y + 7f, transform.position.z + (-1*forward.z*mult));
//		transform.LookAt(player);
//		transform.rotation = new Quaternion(transform.rotation.x,
	}
}
