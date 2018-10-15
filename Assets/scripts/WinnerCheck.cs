using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerCheck : MonoBehaviour {

	public bool win;
	public int platform_index;
	public GameObject endgame;


	void OnCollisionEnter (Collision col) {

		//indexFinder indf = col.GetComponent<indexFinder>();
		platform_index = col.transform.GetComponent<indexFinder> ().index;
		Debug.Log (platform_index);


		if (platform_index == 99) {
			win = true;
			endgame.GetComponent<WinScript> ().win = true;
		} 
		else {
			win = false;
		}
		//Debug.Log (win);
		//win = false;

	}
}
