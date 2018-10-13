﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generatePlatforms : MonoBehaviour {
	float randomX;
	float randomY;
	float randomZ;
	 public int numberOfPlatforms;
	float startingY;
	int chosenPlatform;

	Vector3 position;

	//Moving platforms
	public GameObject fallingPlatform;	//0
	public GameObject yBFPlatform;		//1
	public GameObject xBFPlatform;		//2
	public GameObject rotatePlatform;	//3
	public GameObject spinPlatform;		//4

	//Sized Platforms
	public GameObject smallPlatform;	//5
	public GameObject mediumPlatform;	//6
	public GameObject largePlatform;	//7
	public GameObject regularPlatform;	//8

	public float[] percentagePlatforms;

	float[] randomXHolder;
	float[] randomYHolder;
	float[] randomZHolder;
	int[] XpositiveOrNegative;
	int[] ZpositiveOrNegative;

	int XposOrNeg = 0;
	int ZposOrNeg = 0;


	Vector3 spawnPosition;

	GameObject[] randomPlatformHolder;
	GameObject[] availablePlatforms = new GameObject[9];

	public int lights_per_platforms;
	public GameObject lightPrefab;


	// Use this for initialization
	void Start () {

		availablePlatforms [0] = fallingPlatform;
		availablePlatforms [1] = yBFPlatform;
		availablePlatforms [2] = xBFPlatform;
		availablePlatforms [3] = rotatePlatform;
		availablePlatforms [4] = spinPlatform;
		availablePlatforms [5] = smallPlatform;
		availablePlatforms [6] = mediumPlatform;
		availablePlatforms [7] = largePlatform;
		availablePlatforms [8] = regularPlatform;

		makeRandoms ();


		int platforms_per_light = 100/lights_per_platforms;
		Debug.Log (platforms_per_light);
		Debug.Log (numberOfPlatforms);
		int light_count = 0;

		for (int i = 0; i < numberOfPlatforms; i++) {

			spawnPosition = new Vector3 (randomXHolder[i], randomYHolder[i], randomZHolder[i]);
			Instantiate (randomPlatformHolder[i], spawnPosition, transform.rotation);


			if (i % platforms_per_light == 0) {
				light_count++;
				Vector3 lightPos = spawnPosition + new Vector3 (0.0f, 5, 0.0f);
				Quaternion lightInitRot = Quaternion.Euler(new Vector3 (135, 0, 0) + transform.rotation.eulerAngles);
				Instantiate (lightPrefab, lightPos, lightInitRot);

			}


		}
		Debug.Log (light_count);



	}

	void constructPlatforms(){
		//init the amount of platforms to be generated
//		numberOfPlatforms = 100;
		randomXHolder = new float[numberOfPlatforms];
		randomYHolder = new float[numberOfPlatforms];
		randomZHolder = new float[numberOfPlatforms];
		randomPlatformHolder = new GameObject[numberOfPlatforms];
		XpositiveOrNegative = new int[numberOfPlatforms];
		ZpositiveOrNegative = new int[numberOfPlatforms];

		int[] platformDist = new int[percentagePlatforms.Length];

		for(int i = 0 ; i < percentagePlatforms.Length; ++i){
			Debug.Log(percentagePlatforms[i]);
			platformDist[i] = (int) (percentagePlatforms[i] * numberOfPlatforms * 0.01);
			Debug.Log("platform "+i+": "+platformDist[i]);
		}

		//loops through each position of platforms
		for (int i = 0; i < numberOfPlatforms; i++) {
			//There are number ranges associated with each platform
			//to create different probabilities of each happening
			chosenPlatform = Random.Range (1, 10000);
			chosenPlatform %= availablePlatforms.Length;
			while(platformDist[chosenPlatform] == 0){
				chosenPlatform = Random.Range(1,10000);
				chosenPlatform %= availablePlatforms.Length;
			}

			--platformDist[chosenPlatform];
			randomPlatformHolder[i] = availablePlatforms[chosenPlatform];
			Debug.Log(i+": "+chosenPlatform);

		}//all platforms now generated in holder array

	}

	void makeRandoms(){

		constructPlatforms();
		GameObject lastPlatform = randomPlatformHolder[0];
		GameObject currPlatform = randomPlatformHolder[1];

		randomX = 11.0f;
		randomY = -5.0f;
		randomZ = -27.0f;
		//randomZ = Random.Range (-120.0f, 50.0f);

		randomXHolder [0] = randomX;
		randomYHolder [0] = randomY;
		randomZHolder [0] = randomZ;
		XpositiveOrNegative [0] = 0;
		ZpositiveOrNegative [0] = 0;

		for (int j = 1; j < numberOfPlatforms; j++) {

			lastPlatform = randomPlatformHolder[j-1];
			currPlatform = randomPlatformHolder[j];




			//first platform must be at certain height
			if (j == 0) {
				//working in a space of 170 by 170
				//randomX = Random.Range (-120.0f, 50.0f);

//				lastPlatform = randomPlatformHolder[0];

				continue;
			}
			else{

				Bounds currBound;
				Bounds lastBound;
				if (currPlatform.transform.childCount > 0) {
					currBound = currPlatform.GetComponentInChildren<Renderer> ().bounds;
				} else {
					currBound = currPlatform.GetComponent<Renderer> ().bounds;
				}
				if (lastPlatform.transform.childCount > 0) {
					lastBound = lastPlatform.GetComponentInChildren<Renderer> ().bounds;
				} else {
					lastBound = lastPlatform.GetComponent<Renderer> ().bounds;
				}


				if ((j != 0) && (randomPlatformHolder [j - 1] == availablePlatforms [1])) {///////////////////////////////////////////YBF
					setRegularLocation(j, lastBound.extents.x, lastBound.extents.z, currBound.extents.x, currPlatform.transform.lossyScale.z, 1);
				}

				if ((j != 0) && (randomPlatformHolder [j - 1] == availablePlatforms [2])) {///////////////////////////////////////////XBF
					setRegularLocation(j, lastPlatform.transform.lossyScale.x, lastPlatform.transform.lossyScale.z,currPlatform.transform.lossyScale.x, currPlatform.transform.lossyScale.z, 2);
				}
				else {
					setRegularLocation(j, lastBound.extents.x, lastBound.extents.z, currBound.extents.x, currBound.extents.z, 0);
				}
			

			randomXHolder [j] = randomX;
			randomYHolder [j] = randomY;
			randomZHolder [j] = randomZ;
			XpositiveOrNegative [j] = XposOrNeg;
			ZpositiveOrNegative [j] = ZposOrNeg;
			
//			currPlatform = randomPlatformHolder[j];
			}

		}
	}



	// Update is called once per frame
	void Update () {

	}


	void setRegularLocation(int j, float prevXSize, float prevZSize, float currXSize, float currZSize, int move){
		float xSize = prevXSize + currXSize; 
		float zSize = prevZSize + currZSize;
		Debug.Log ("xSize: " + xSize);
		bool xOverlap = false;
		bool zOverlap = false;
		//if the last platform is small

		//will it be added to the back or front
		ZposOrNeg = ZpositiveOrNegative[j-1];

//		if going out of boundaries on POS side, switch to NEG
		if(((randomZHolder[j-1]+prevZSize + currZSize*2) > 50.0f)){
			ZposOrNeg = 0;
			zOverlap = true;
		}
		else if(((randomZHolder[j-1] - prevZSize - currZSize*2) < -120.0f)){
			ZposOrNeg = 1;
			zOverlap = true;

		}

		//will it be added to the back or front
		XposOrNeg = XpositiveOrNegative[j-1];

//		//if going out of boundaries on POS side, switch to NEG
		if(((randomXHolder[j-1] + prevXSize + currXSize*2) > 50)){
			XposOrNeg = 0;
			xOverlap = true;
		}
		else if(((randomXHolder[j-1] - prevXSize - currXSize*2) < -120)){
			XposOrNeg = 1;
			xOverlap = true;
		}

			///////////////////////////////////////////////////////////////////////////////////////////////////////// Y


			if(move == 1 || move == 2){
				randomY = randomYHolder[j-1];
			}else{
				randomY = Random.Range(3.0f, 5.0f);
				randomY += randomYHolder [j - 1];
			}

			///////////////////////////////////////////////////////////////////////////////////////////////////////// X
			//the x that will be added
		float xadd = 0;//Random.Range (1.0f, 2.0f);

			if(move == 2){ // XBF
				xadd = 23.0f;
			}
			
			//if negative or postive add/sub the scale X (20 for small) and add/sub the random range
			if (XposOrNeg == 0) {
				randomX = randomXHolder [j - 1] - xSize - xadd;
			} else if (XposOrNeg == 1) {
				randomX = randomXHolder [j - 1] + xSize + xadd;
			}
		if (zOverlap) {
			
		}


			///////////////////////////////////////////////////////////////////////////////////////////////////////// Z

			//now we do the same for the Z position, how much will it move by
			float zadd = Random.Range(1.0f, 2.0f);
			if(move == 1){ //YBF
					zadd = 23.0f;
			}

			
			//if negative or postive add/sub the scale Z (10 for small) and add/sub the random range
			if (ZposOrNeg == 0) {
				randomZ = randomZHolder [j - 1] - zSize - zadd;
			} else if (ZposOrNeg == 1) {
				randomZ = randomZHolder [j - 1] + zSize + zadd;
			}
		if (xOverlap) {
			
		}

	}

}
