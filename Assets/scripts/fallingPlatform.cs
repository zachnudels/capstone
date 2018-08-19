using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPlatform : MonoBehaviour {


	public GameObject player;
	bool isFalling = false;
	float fallSpeed = 0;
	float yPos = 0;
	float upSpeed = 0;

	//On start, the platforms original Y postion is captured so that it can always return to that value
	void Start(){
		yPos = transform.position.y;
	}

	//Once a player collides with the platform, the platform sets a flag and resets the falling speed.
	void OnTriggerEnter(Collider collider){
		print ("colliding");
		if (collider.gameObject.tag == "Player") {
			print ("colliding with player");
			fallSpeed = 0;
			isFalling = true;


		}
	}
	//Once the player leaves the platform, it sets a flag and resets the up speed.
	void OnTriggerExit(Collider collider){
		print ("leaving");
		if (collider.gameObject.tag == "Player") {
			print ("leaving player");
			upSpeed = 0;
			isFalling = false;
		}
	}
	//The flag is checked if the player is on or off the platform.
	void Update(){

		//If the player is newly on the platform (where the fallspeed was set to 0) the fallspeed becomes increasingly great
		if (isFalling) {
			fallSpeed += Time.deltaTime / 50;
			transform.position = new Vector3 (transform.position.x, transform.position.y - fallSpeed, transform.position.z);
		}
		//If the player is newly off the platform, the up speed becomes increasingly great until the platform has reached its original height
		if (!isFalling) {
			upSpeed += Time.deltaTime / 50;
			if (transform.position.y <= yPos) {
				transform.position = new Vector3 (transform.position.x, transform.position.y + upSpeed, transform.position.z);
			}

		}
	}

}
