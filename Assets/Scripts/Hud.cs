using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Hud : MonoBehaviour {

	public Image bit0;
	public Image bit1;
	public Image bit2;
	public Image bit3;

	// Use this for initialization
	void Start () {
		bit0.enabled = bit1.enabled = bit2.enabled = bit3.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
