using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour {

	public AudioMixer audioMixer;

	public void setVolume(float vol){

		audioMixer.SetFloat ("Volume", vol);

	}

	public void SetFull(bool isFullScreen){
		Screen.fullScreen = isFullScreen;
	}

	public void quitToMenu(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex - 1);
	}

}
