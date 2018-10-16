using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalMusic1 : MonoBehaviour {
	private static GlobalMusic1 instance = null;
	void Awake(){
		if (!instance) {
			instance = this;
			gameObject.GetComponent<AudioSource> ().Play ();

		} else {
			Debug.Log ("Stop");
			gameObject.GetComponent<AudioSource> ().Stop ();
			Destroy (this.gameObject);
		}
		DontDestroyOnLoad (this.gameObject);
	}

	void Update () {
		string scene = SceneManager.GetActiveScene ().name;
		if(!(scene == "stage1" || scene == "mapme" || scene == "Multi" || scene == "Plane" ))
		{
			Destroy (this.gameObject);
		}
	}
}
