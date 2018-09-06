using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blackHoleGenerator : MonoBehaviour {

	Vector3 startingPos;
	bool blackHole;
	public GameObject black;

	int power;
	float spawnX;
	float spawnZ;
	Vector3 pos;


	// Use this for initialization
	void Start () {
		//startingPos = this.transform.position;

		makeRandom ();
		if (blackHole) {
			
				Instantiate (black, pos, transform.rotation);

		}
	}


	void makeRandom(){
		int prob = 3;
		if (prob == 3) {
			blackHole = true;
		}

	
		spawnX = this.transform.position.x; 
		spawnZ = this.transform.position.z;
		pos = new Vector3 (spawnX, this.transform.position.y + 1, spawnZ);



	}

	// Update is called once per frame
	void Update () {

	}
}
