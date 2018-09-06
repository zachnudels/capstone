using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeDirection : MonoBehaviour {
	
	public GameObject Player;
	private Transform playerParent;

	void Start(){
		Player = GameObject.FindGameObjectWithTag("Player").gameObject;
		playerParent = Player.transform.parent;
	}



	private void OnTriggerEnter(Collider other){
		print ("trigger has hit  " + other.gameObject.tag);
		if (other.gameObject.tag == "platform" && other.gameObject.tag == "spinPlat") {
			print ("trigger changed direction");
			Player.transform.parent.parent = transform;
		}
		if (other.gameObject.tag == "platform") {
			print ("trigger has platform");
			GameObject.Find ("XBFcube").GetComponent<forwardBack> ().direction *= -1;
		}
	}

	private void OnTriggerExit(Collider other){
		print ("trigger has left");
		if (other.gameObject.tag == "Player") {
			print ("trigger has left platform");
			Player.transform.parent.parent = null;
		}
	}

}
