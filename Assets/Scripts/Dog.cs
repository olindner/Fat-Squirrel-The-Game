using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour {

	public int speed = 30;
	public float speedChase = 5f;
	public bool chasing = false;
	private bool onPathMoving;
	public Vector3 stored;
	public int type;
	public AudioSource player;

	void Start(){
		if (type == 0) iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("DogPath0"), "time", speed, "onComplete", "Done", "orienttopath", true));
		else if (type == 1) iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("DogPath1"), "time", speed, "onComplete", "Done", "orienttopath", true));
		else if (type == 2) iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("DogPath2"), "time", speed, "onComplete", "Done", "orienttopath", true));
		onPathMoving = true;
		transform.GetChild(0).gameObject.SetActive(false);
	}

	void Update ()
	{
		if (Squirrel.instance.inTree) { //if player is in a tree, stop chasing
			chasing = false;
			player.Stop ();
			onPathMoving = false;
			transform.GetChild(0).gameObject.SetActive(false);
		}

		if (!chasing && !onPathMoving && transform.position == stored) { //just got back to path from chase
			onPathMoving = true;
			iTween.Resume();
		}

		if (chasing) { //override pathing and "chase" player
			transform.GetChild(0).gameObject.SetActive(true);
			iTween.Pause ();
			onPathMoving = false;
			transform.LookAt (Squirrel.instance.gameObject.transform);
			transform.Translate (speedChase * Vector3.forward * Time.deltaTime);
		} else if (!chasing && !onPathMoving) { //move back to last point on path
			transform.position = Vector3.MoveTowards(transform.position, stored, Time.deltaTime * speedChase);
		}
	}

	void Done () //when reached end of path
	{
		//not destroy, something else?
		Destroy(gameObject);
	}
}
