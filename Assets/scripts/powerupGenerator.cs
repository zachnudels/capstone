using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupGenerator : MonoBehaviour {

	Vector3 startingPos;
	bool powerUp;
	public GameObject spawn;
	public GameObject speed;
	int power;
	float spawnX;
	float spawnZ;
	Vector3 pos;


	// Use this for initialization
	void Start () {
		//startingPos = this.transform.position;

		makeRandom ();
		if (powerUp) {
			if (power == 1) {
				//instantaite spawn
				Instantiate (spawn, pos, transform.rotation);
			}
			if (power == 2) {
				//instantaite speed
				Instantiate (speed, pos, transform.rotation);
			}
		}
	}


	void makeRandom(){
		int prob = 3;
		if (prob == 3) {
			powerUp = true;
		}

		if (powerUp) {
			power = Random.Range (1, 3);

		}
		spawnX = this.transform.position.x + Random.Range(-2, 2);
		spawnZ = this.transform.position.z + Random.Range (-2, 2);
		pos = new Vector3 (spawnX, this.transform.position.y + 1, spawnZ);



	}

	// Update is called once per frame
	void Update () {
		
	}
}
