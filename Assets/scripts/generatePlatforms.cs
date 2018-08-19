using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generatePlatforms : MonoBehaviour {
	int randomX;
	int randomY;
	int randomZ;
	int numberOfPlatforms;
	int startingY;
	int chosenPlatform;

	Vector3 position;

	public GameObject fallingPlatform;	//0
	public GameObject yBFPlatform;		//1
	public GameObject xBFPlatform;		//2
	public GameObject rotatePlatform;	//3
	public GameObject spinPlatform;		//4
	public GameObject smallPlatform;	//5
	public GameObject mediumPlatform;	//6
	public GameObject largePlatform;	//7
	public GameObject regularPlatform;	//8

	int[] randomXHolder;
	int[] randomYHolder;
	int[] randomZHolder;

	GameObject[] randomPlatformHolder;
	GameObject[] availablePlatforms = new GameObject[9];


	void makeRandoms(){
		//init the amount of platforms to be generated
		numberOfPlatforms = Random.Range (20, 30);
		randomXHolder = new int[numberOfPlatforms];
		randomYHolder = new int[numberOfPlatforms];
		randomZHolder = new int[numberOfPlatforms];
		randomPlatformHolder = new GameObject[numberOfPlatforms];

		//loops through each position of platforms
		for (int i = 0; i < numberOfPlatforms; i++) {
			//There are number ranges associated with each platform
			//to create different probabilities of each happening
			chosenPlatform = Random.Range (1, 50);

			//first platform should be regular
			//can change the && i != 0 to continue I think will do that later
			if (i == 0) {
				randomPlatformHolder [i] = availablePlatforms [8];
			}

			if (1 <= chosenPlatform <= 7 && i != 0) {
				//small platform
				randomPlatformHolder[i] = availablePlatforms[5];
			}
			if (8 <= chosenPlatform <= 14 && i != 0) {
				//medium platform
				randomPlatformHolder[i] = availablePlatforms[6];
			}
			if (15 <= chosenPlatform <= 22 && i != 0) {
				//large platform
				randomPlatformHolder[i] = availablePlatforms[7];
			}
			if (23 <= chosenPlatform <= 32 && i != 0) {
				//regular platform
				randomPlatformHolder[i] = availablePlatforms[8];
			}
			if (33 <= chosenPlatform <= 34 && i != 0) {
				//falling platform
				randomPlatformHolder[i] = availablePlatforms[0];
			}
			if (35 <= chosenPlatform <= 38 && i != 0) {
				//yBF platform
				randomPlatformHolder[i] = availablePlatforms[1];
			}
			if (39 <= chosenPlatform <= 42 && i != 0) {
				//xBF platform
				randomPlatformHolder[i] = availablePlatforms[2];
			}
			if (43 <= chosenPlatform <= 46 && i != 0) {
				//rotate platform
				randomPlatformHolder[i] = availablePlatforms[3];
			}
			if (47 <= chosenPlatform <= 50 && i != 0) {
				//spin platform
				randomPlatformHolder[i] = availablePlatforms[4];
			}
		}//all platforms now selected

		for (int j = 0; j < numberOfPlatforms; j++) {
			//first platform must be at certain height
			if (j == 0) {
				//working in a space of 170 by 170
				randomX = Random.Range (-120, 50);
				randomY = -5.0;
				randomZ = Random.Range (-120, 50);

				randomXHolder [j] == randomX;
				randomYHolder [j] == randomY;
				randomZHolder [j] == randomZ;
			}
			if (randomPlatformHolder [j - 1] == availablePlatforms [0]) {
				//if the last platform is falling
				randomY = randomYHolder[j-1] - 5;

				//the x that will be added
				int xadd = Random.Range (0, 6);

				//will it be added to the back or front
				int posOrNeg = Random.Range(0,1);

				//if going out of boundaries on POS side, switch to NEG
				if(((randomXHolder[j-1] + 10) > 50)){
					posOrNeg = 0;
				}
				else if(((randomXHolder[j-1] - 10) < -120)){
					posOrNeg = 1;

				}
				//if negative or postive add/sub the scale X (7 for falling) and add/sub the random range
				if (posOrNeg == 0) {
					randomX = randomXHolder [j - 1] - 7 - xadd;
				} else if (posOrNeg == 1) {
					randomX = randomXHolder [j - 1] + 7 + xadd;
				}

					
		

			}//must do +-scale then add the difference
			if (randomPlatformHolder [j - 1] == availablePlatforms [1]) {
				//if the last platform is yBF

			}
			if (randomPlatformHolder [j - 1] == availablePlatforms [2]) {
				//if the last platform is xBF
			}
			if (randomPlatformHolder [j - 1] == availablePlatforms [3]) {
				//if the last platform is rotate
			}
			if (randomPlatformHolder [j - 1] == availablePlatforms [4]) {
				//if the last platform is spinning
			}
			if (randomPlatformHolder [j - 1] == availablePlatforms [5]) {
				//if the last platform is small
			}
			if (randomPlatformHolder [j - 1] == availablePlatforms [6]) {
				//if the last platform is medium
			}
			if (randomPlatformHolder [j - 1] == availablePlatforms [7]) {
				//if the last platform is large
			}
			if (randomPlatformHolder [j - 1] == availablePlatforms [8]) {
				//if the last platform is regular
			}

		}
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
