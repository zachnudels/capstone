using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalMusic : MonoBehaviour {
	private static GlobalMusic instance = null;
	void Awake(){
		if (!instance) {
			instance = this;

		} else {
			Debug.Log ("Stop");
			gameObject.GetComponent<AudioSource> ().Stop ();
			Destroy (this.gameObject);
		}
		DontDestroyOnLoad (this.gameObject);
	}

	void Update () {
		string scene = SceneManager.GetActiveScene ().name;
		if (!(scene == "Menu" || scene == "LobbyScene")) {
			gameObject.GetComponent<AudioSource> ().Stop ();
		} else {
			if(!gameObject.GetComponent<AudioSource> ().isPlaying)
				gameObject.GetComponent<AudioSource> ().Play ();
		}
	}
}
