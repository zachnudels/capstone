using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerCheck : MonoBehaviour {

	public bool win = false;
	public int platform_index = 0;
	public GameObject endgame;


	void OnTriggerEnter (Collider col) {

		//indexFinder indf = col.GetComponent<indexFinder>();
		platform_index = col.GetComponent<indexFinder> ().index;
		Debug.Log (platform_index);


		if (platform_index == 100) {
			win = true;
		} 
		else {
			win = false;
		}
		Debug.Log (win);
		//win = false;

	}
}
