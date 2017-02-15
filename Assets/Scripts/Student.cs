using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Student : MonoBehaviour {

	public GameObject hamburger;
	public GameObject fries;
	private float timer = 0f;
	private bool isSet = false;
	public float speed = 5f;

	public int type;
	private Vector3 target;

	// Use this for initialization
	void Start ()
	{
		if (type == 0) {
			target = new Vector3 (104f, 5f, 112f);
		} else if (type == 1) {
			target = new Vector3 (-17f, 5f, 4f);
		} else if (type == 2) {
			target = new Vector3 (-111f, 5f, 112f);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (transform.position == target) Destroy(gameObject);
		else transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime*speed);

		if (!isSet) {
			timer = Time.time + Random.Range (10f, 20f);
			isSet = true;
		}
		if (isSet && Time.time >= timer) {
			int num = Random.Range (0, 2);
			if (num == 0) { //spawn hamburger
				GameObject go = Instantiate(hamburger) as GameObject;
				go.transform.position = new Vector3(transform.position.x, 2f, transform.position.z);
			} else { //spawn fries
				GameObject go = Instantiate(fries) as GameObject;
				go.transform.position = new Vector3(transform.position.x, 2f, transform.position.z);
			}
			isSet = false;
		}
	}
}
