using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPlatform : MonoBehaviour {


	public GameObject Player;
	bool isFalling = false;
	float fallSpeed = 0;
	float yPos = 0;
	float upSpeed = 0;

	void Start(){
		yPos = transform.position.y;
		Player = GameObject.FindGameObjectWithTag("myPlayer").gameObject;
	}

	void OnTriggerEnter(Collider collider){
		print ("colliding");
		if (collider.gameObject.tag == "myPlayer") {
			print ("colliding with player");
			fallSpeed = 0;
			isFalling = true;


		}
	}

	void OnTriggerExit(Collider collider){
		print ("leaving");
		if (collider.gameObject.tag == "myPlayer") {
			print ("leaving player");
			upSpeed = 0;
			isFalling = false;
		}
	}

	void Update(){
		if (isFalling) {
			fallSpeed += Time.deltaTime / 50;
			transform.position = new Vector3 (transform.position.x, transform.position.y - fallSpeed, transform.position.z);
		}
		if (!isFalling) {
			upSpeed += Time.deltaTime / 50;
			if (transform.position.y <= yPos) {
				transform.position = new Vector3 (transform.position.x, transform.position.y + upSpeed, transform.position.z);
			}

		}
	}

}
