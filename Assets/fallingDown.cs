using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingDown : MonoBehaviour {

	bool isFalling = false;
	float fallSpeed = 0;
	float yPos = 0;
	float upSpeed = 0;

	void Start(){
		yPos = transform.position.y;
	}

	void OnTriggerEnter(Collider collider){
		if (collider.gameObject.name == "player") {
			fallSpeed = 0;
			isFalling = true;


		}
	}

	void OnTriggerExit(Collider collider){
		if (collider.gameObject.name == "player") {
			upSpeed = 0;
			isFalling = false;
		}
	}

	void Update(){
		if (isFalling) {
			fallSpeed += Time.deltaTime/50;
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
