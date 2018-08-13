using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ranSpawn : MonoBehaviour {
	int randomX;
	int randomZ;
	int y = 35;
	Vector3 pos;
	int numberOf; 
	public GameObject pre1;
	public GameObject pre2;
	public GameObject pre3;
	public GameObject pre4;
	public GameObject pre5;

	int[] randX;
	int[] randZ;

	int ranAr;

	GameObject [] prefRanHolder;
	GameObject[] prefHolder = new GameObject[5];

	void makeRandoms(){
		numberOf = Random.Range (20, 40);
		randX = new int[numberOf];
		randZ = new int[numberOf];

		prefHolder [0] = pre1;
		prefHolder [1] = pre2;
		prefHolder [2] = pre3;
		prefHolder [3] = pre4;
		prefHolder [4] = pre5;

		prefRanHolder = new GameObject[numberOf];
		for (int i = 0; i < numberOf; i++) {
			randX [i] = Random.Range (-250, 250);
			randZ [i] = Random.Range (-250, 250);
			int ranPre = Random.Range (0, 5);

			prefRanHolder [i] = prefHolder [ranPre];

		}


		
	}
	//Instantiate(prefeb[prefeb_num],


	void Start(){
		makeRandoms ();
		for(int i = 0; i < numberOf; i ++){
			//ranAr = Random.Range (0, 4);

			pos = new Vector3 (randX[i], y, randZ[i]);
			


			Instantiate (prefRanHolder[i], pos, transform.rotation);

		}


		//pos = new Vector3 (randomX, y, randomZ);
		//Instantiate (wizard, spawnPlace, Quaternion.identity);
	}

}
