using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformAttach : MonoBehaviour {

	public GameObject Player;
	private Transform playerParent;


	//Holds the value of the player's current parent
	void Start(){
		playerParent = Player.transform.parent;
	}


	//If the player touches a platform, the player becomes a child of the platform so that it may move independantly with the platform
	private void OnTriggerEnter(Collider other){
		print ("trigger has hit");
		if (other.gameObject == Player) {
			print ("trigger has platform");
			Player.transform.parent = transform;
		}
	}

	//If the player leaves the platform, its parent is reset
	private void OnTriggerExit(Collider other){
		print ("trigger has left");
		if (other.gameObject == Player) {
			print ("trigger has left platform");
			Player.transform.parent = null;
		}
	}
}
