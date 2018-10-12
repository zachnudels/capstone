using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerCheck : MonoBehaviour {

	public bool win = false;

	public GameObject endgame;


	void OnTriggerEnter (Collider col) {

		//indexFinder indf = col.GetComponent<indexFinder>();

		if (col.GetComponent<indexFinder> ().index == 100) {
			win = true;
		} 
		else {
			win = false;
		}
		Debug.Log (win);
		//win = false;

	}
}
