﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformAttach : MonoBehaviour {

	public GameObject Player;
	private Transform playerParent;

	void Start(){
		Player = GameObject.FindGameObjectWithTag("Player").gameObject;
		playerParent = Player.transform.parent;
	}

	private void OnTriggerEnter(Collider other){
		print ("trigger has hit " + other.gameObject.tag);
		if (other.gameObject.tag == "Player") {
			print ("trigger has platform");
			Player.transform.parent.parent = transform;
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
