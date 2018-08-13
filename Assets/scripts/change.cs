using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change : MonoBehaviour {

	[SerializeField]public GameObject third;
	[SerializeField]public GameObject orbit;
	[SerializeField]public GameObject fps;

	public bool hi;

	AudioListener thirdAudio;
	AudioListener orbitAudio;
	AudioListener fpsAudio;

	int cameraNumber;

	// Use this for initialization
	void Start () {

		thirdAudio = third.GetComponent<AudioListener> ();
		orbitAudio = orbit.GetComponent<AudioListener> ();
		fpsAudio = fps.GetComponent<AudioListener> ();




	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.T)) {
			cameraNumber = 1;

			third.SetActive (true);
			thirdAudio.enabled = true;

			orbitAudio.enabled = false;
			orbit.SetActive (false);

			fpsAudio.enabled = false;
			fps.SetActive (false);

		}
		if (Input.GetKeyDown (KeyCode.Y)) {
			cameraNumber = 2;

			third.SetActive (false);
			thirdAudio.enabled = false;

			orbitAudio.enabled = true;
			orbit.SetActive (true);

			fpsAudio.enabled = false;
			fps.SetActive (false);


		}
		if (Input.GetKeyDown (KeyCode.U)) {
			cameraNumber = 3;

			third.SetActive (false);
			thirdAudio.enabled = false;

			orbitAudio.enabled = false;
			orbit.SetActive (false);

			fpsAudio.enabled = true;
			fps.SetActive (true);
		}	
	}


	void switchCamera(){


	}


}
