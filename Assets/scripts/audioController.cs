using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class audioController : MonoBehaviour {

	//plays audio, finds a source and uses a clip when needed

	[SerializeField] AudioClip clip;
	[SerializeField] float timeBetween;

	bool canPlay;
	float lastTime = 0.0f;
	AudioSource source;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
		canPlay = true;
	}
	
	// Update is called once per frame
	public void Play(){

		print ("playing");



		if (timeBetween > Time.deltaTime - lastTime) {
			source.PlayOneShot (clip);
			lastTime = Time.deltaTime;
			return;
		}

	}
}
