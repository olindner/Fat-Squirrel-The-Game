using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadMenu ()
	{
		SceneManager.LoadScene("Menu");
	}
}
