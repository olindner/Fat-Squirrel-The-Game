using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour {

	public Color start = Color.green;
	public Color middle = Color.red;
	public Color end = Color.white;
	public float fadeTimeRed = 10f;
	public float fadeTimeWhite = 10f;
	private float t = 0f;
	private float a = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (t <= 1) { //green to red
			t += Time.deltaTime / fadeTimeRed; //advance timer
			GetComponent<MeshRenderer> ().material.color = Color.Lerp (start, middle, t);
			GetComponent<ParticleSystemRenderer>().material.color = Color.Lerp (start, middle, t);
		}
		if (t > 1) { //red to white
			a += Time.deltaTime / fadeTimeWhite;
			GetComponent<MeshRenderer> ().material.color = Color.Lerp (middle, end, a);
			GetComponent<ParticleSystemRenderer>().material.color = Color.Lerp (middle, end, a);
		}
	}
}
