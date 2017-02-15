using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

	public GameObject Dog, Student;
	private GameObject go0, go1, go2, s0, s1, s2;

	public float spawnDelay = 5f;
	private float spawnTimer;

	public float spawnDelay2 = 10f;
	private float spawnTimer2;

	// Use this for initialization
	void Start () {
		spawnTimer = Time.time + spawnDelay;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Time.time >= spawnTimer) { //Dogs
			int type = Random.Range (0, 3);

			if (type == 0 && go0 == null) {
				go0 = Instantiate(Dog) as GameObject;
				go0.transform.position = new Vector3(102f, 2f, 2.85f);
				go0.GetComponent<Dog>().type = type;
			} else if (type == 1 && go1 == null) {
				go1 = Instantiate(Dog) as GameObject;
				go1.transform.position = new Vector3(-115f, 2f, 3f);
				go1.GetComponent<Dog>().type = type;
			} else if (type == 2 && go2 == null) {
				go2 = Instantiate(Dog) as GameObject;
				go2.transform.position = new Vector3(79f, 2f, 109f);
				go2.GetComponent<Dog>().type = type;
			}
			spawnTimer = Time.time + spawnDelay;
		}

		if (Time.time >= spawnTimer2) { //Students
			int type = Random.Range (0, 3);

			if (type == 0) {
				s0 = Instantiate(Student) as GameObject;
				s0.transform.position = new Vector3(-111f, 5f, 112f);
				s0.GetComponent<Student>().type = type;
			} else if (type == 1) {
				s1 = Instantiate(Student) as GameObject;
				s1.transform.position = new Vector3(104f, 5f, 70f);
				s1.GetComponent<Student>().type = type;
			} else if (type == 2) {
				s2 = Instantiate(Student) as GameObject;
				s2.transform.position = new Vector3(17f, 5f, 4f);
				s2.GetComponent<Student>().type = type;
			}
			spawnTimer2 = Time.time + spawnDelay2;
		}
	}
}
