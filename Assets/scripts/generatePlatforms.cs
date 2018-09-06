using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generatePlatforms : MonoBehaviour {
	float randomX;
	float randomY;
	float randomZ;
	int numberOfPlatforms;
	float startingY;
	int chosenPlatform;

	public int lights_per_platforms;

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

	public GameObject lightPrefab;

	float[] randomXHolder;
	float[] randomYHolder;
	float[] randomZHolder;
	int[] XpositiveOrNegative;
	int[] ZpositiveOrNegative;

	Vector3 spawnPosition;

	GameObject[] randomPlatformHolder;
	GameObject[] availablePlatforms = new GameObject[9];


	void makeRandoms(){
		//init the amount of platforms to be generated
		numberOfPlatforms = Random.Range (100, 150);
		randomXHolder = new float[numberOfPlatforms];
		randomYHolder = new float[numberOfPlatforms];
		randomZHolder = new float[numberOfPlatforms];
		randomPlatformHolder = new GameObject[numberOfPlatforms];
		XpositiveOrNegative = new int[numberOfPlatforms];
		ZpositiveOrNegative = new int[numberOfPlatforms];

		//loops through each position of platforms
		for (int i = 0; i < numberOfPlatforms; i++) {
			//There are number ranges associated with each platform
			//to create different probabilities of each happening
			chosenPlatform = Random.Range (1, 50);

			//first platform should be regular
			//can change the && i != 0 to continue I think will do that later
			//the first platform should be a regular platform
			if (i == 0) {
				randomPlatformHolder [i] = availablePlatforms [8];
				continue;
			
			}
			//find whose platform range we randomly rolled on
			if ((((chosenPlatform > 1) && (chosenPlatform < 7)) || ((chosenPlatform == 1) || (chosenPlatform == 7))) && (i != 0)) {
				
				//small platform
				randomPlatformHolder[i] = availablePlatforms[5];
				continue;
			}
			if ((((chosenPlatform > 8) && (chosenPlatform < 12)) || ((chosenPlatform == 8) || (chosenPlatform == 12))) && (i != 0)) {
				//medium platform
				randomPlatformHolder[i] = availablePlatforms[6];
				continue;
			}
			if ((((chosenPlatform > 13) && (chosenPlatform < 15)) || ((chosenPlatform == 13) || (chosenPlatform == 15))) && (i != 0)) {
				//large platform
				randomPlatformHolder[i] = availablePlatforms[7];
				continue;
			}
			if ((((chosenPlatform > 16) && (chosenPlatform < 32)) || ((chosenPlatform == 16) || (chosenPlatform == 32))) && (i != 0)) {
				//regular platform
				randomPlatformHolder[i] = availablePlatforms[8];
				continue;
			}
			if ((((chosenPlatform > 33) && (chosenPlatform < 34)) || ((chosenPlatform == 33) || (chosenPlatform == 34))) && (i != 0)) {
				//falling platform
				randomPlatformHolder[i] = availablePlatforms[0];
				continue;
			}
			if ((((chosenPlatform > 35) && (chosenPlatform < 38)) || ((chosenPlatform == 35) || (chosenPlatform == 38))) && (i != 0)) {
				//yBF platform
				randomPlatformHolder[i] = availablePlatforms[1];
				continue;
			}
			if ((((chosenPlatform > 39) && (chosenPlatform < 42)) || ((chosenPlatform == 39) || (chosenPlatform == 42))) && (i != 0)) {
				//xBF platform
				randomPlatformHolder[i] = availablePlatforms[2];
				continue;
			}
			if ((((chosenPlatform > 43) && (chosenPlatform < 46)) || ((chosenPlatform == 43) || (chosenPlatform == 46))) && (i != 0)) {
				//rotate platform
				randomPlatformHolder[i] = availablePlatforms[3];
				continue;
			}
			if ((((chosenPlatform > 47) && (chosenPlatform < 50)) || ((chosenPlatform == 47) || (chosenPlatform == 50))) && (i != 0)) {
				//spin platform
				randomPlatformHolder[i] = availablePlatforms[4];
				continue;
			}
		}//all platforms now selected

		for (int j = 0; j < numberOfPlatforms; j++) {
			//first platform must be at certain height
			if (j == 0) {
				//working in a space of 170 by 170
				//randomX = Random.Range (-120.0f, 50.0f);
				randomX = 11.0f;
				randomY = -5.0f;
				randomZ = -27.0f;
				//randomZ = Random.Range (-120.0f, 50.0f);

				randomXHolder [j] = randomX;
				randomYHolder [j] = randomY;
				randomZHolder [j] = randomZ;
				XpositiveOrNegative [j] = 0;
				ZpositiveOrNegative [j] = 0;
			}




			///////////////////////CHECKING UPPER BOUND FOR XBF, YBF
			/// 
			/// 
		
			/*
			if ((j != 0) && (randomPlatformHolder [j] == availablePlatforms [1])) {////////////////////////UPPER YBF	


				//for z, the moving platform will move -20 to +20 from its position, so must put it 20 away to not crash
				float zadd = 20.0f;

				//will it be added to the back or front? Check what last one was, add to the same.
				int ZposOrNeg = ZpositiveOrNegative[j-1];

				//if going out of boundaries on POS side, switch to NEG
				if(((randomZHolder[j-1] + 25.0f) > 50.0f)){
					ZposOrNeg = 0;
				}
				else if(((randomZHolder[j-1] - 25.0f) < -120.0f)){
					ZposOrNeg = 1;

				}
				//if negative or postive add/sub the scale Z (7 for yBF) and add/sub the random range
				if (ZposOrNeg == 0) {
					randomZ = randomZHolder [j] - 7.0f - zadd;
				} else if (ZposOrNeg == 1) {
					randomZ = randomZHolder [j] + 7.0f + zadd;
				}


				randomZHolder [j] += randomZ;





			}
			if ((j != 0) && (randomPlatformHolder [j] == availablePlatforms [2])) {////////////////////////UPPER YBF	


				//for z, the moving platform will move -20 to +20 from its position, so must put it 20 away to not crash
				float xadd = 20.0f;

				//will it be added to the back or front? Check what last one was, add to the same.
				int XposOrNeg = XpositiveOrNegative[j-1];

				//if going out of boundaries on POS side, switch to NEG
				if(((randomXHolder[j-1] + 25.0f) > 50.0f)){
					XposOrNeg = 0;
				}
				else if(((randomXHolder[j-1] - 25.0f) < -120.0f)){
					XposOrNeg = 1;

				}
				//if negative or postive add/sub the scale Z (7 for yBF) and add/sub the random range
				if (XposOrNeg == 0) {
					randomX = randomXHolder [j] - 7.0f - xadd;
				} else if (XposOrNeg == 1) {
					randomX = randomXHolder [j] + 7.0f + xadd;
				}


				randomXHolder [j] += randomX;




			}

			*/


















			if ((j != 0) && (randomPlatformHolder [j - 1] == availablePlatforms [0])) {///////////////////////////////////////////FALLING
				///////////////////////////////////////////////////////////////////////////////////////////////////////// Y

				//if the last platform is falling
				randomY = randomYHolder[j-1] - 2.0f;

				///////////////////////////////////////////////////////////////////////////////////////////////////////// X
				//the x that will be added
				float xadd = Random.Range (1.0f, 2.0f);

				//will it be added to the back or front
				int XposOrNeg = XpositiveOrNegative[j-1];

				//if going out of boundaries on POS side, switch to NEG
				if(((randomXHolder[j-1] + 10) > 50)){
					XposOrNeg = 0;
				}
				else if(((randomXHolder[j-1] - 10) < -120)){
					XposOrNeg = 1;

				}
				//if negative or postive add/sub the scale X (7 for falling) and add/sub the random range
				if (XposOrNeg == 0) {
					randomX = randomXHolder [j - 1] - 7.0f - xadd;
				} else if (XposOrNeg == 1) {
					randomX = randomXHolder [j - 1] + 7.0f + xadd;
				}

				///////////////////////////////////////////////////////////////////////////////////////////////////////// Z

				//now we do the same for the Z position, how much will it move by
				float zadd = Random.Range(1.0f, 2.0f);

				//will it be added to the back or front
				int ZposOrNeg = ZpositiveOrNegative[j-1];

				//if going out of boundaries on POS side, switch to NEG
				if(((randomZHolder[j-1] + 10.0f) > 50.0f)){
					ZposOrNeg = 0;
				}
				else if(((randomZHolder[j-1] - 10.0f) < -120.0f)){
					ZposOrNeg = 1;

				}
				//if negative or postive add/sub the scale X (7 for falling) and add/sub the random range
				if (ZposOrNeg == 0) {
					randomZ = randomZHolder [j - 1] - 7.0f - zadd;
				} else if (ZposOrNeg == 1) {
					randomZ = randomZHolder [j - 1] + 7.0f + zadd;
				}

				randomXHolder [j] = randomX;
				randomYHolder [j] = randomY;
				randomZHolder [j] = randomZ;
				XpositiveOrNegative [j] = XposOrNeg;
				ZpositiveOrNegative [j] = ZposOrNeg;



			}//must do +-scale then add the difference
			if ((j != 0) && (randomPlatformHolder [j - 1] == availablePlatforms [1])) {///////////////////////////////////////////YBF
				//if the last platform is yBF

				///////////////////////////////////////////////////////////////////////////////////////////////////////// Y

				//if the last platform is yBF, next platform will stay on the same level
				randomY = randomYHolder[j-1];

				///////////////////////////////////////////////////////////////////////////////////////////////////////// X
				//the x that will be added -- keep it same as last since the z will be moving
				float xadd = randomXHolder[j - 1];

				//will it be added to the back or front? Check what last was and keep the same
				int XposOrNeg = XpositiveOrNegative[j-1];

				//if going out of boundaries on POS side, switch to NEG
				if(((randomXHolder[j-1] + 10) > 50)){
					XposOrNeg = 0;
				}
				else if(((randomXHolder[j-1] - 10) < -120)){
					XposOrNeg = 1;

				}
				//if negative or postive add/sub the scale X (7 for falling) and add/sub the random range
				if (XposOrNeg == 0) {
					randomX = randomXHolder [j - 1];
				} else if (XposOrNeg == 1) {
					randomX = randomXHolder [j - 1];
				}

				///////////////////////////////////////////////////////////////////////////////////////////////////////// Z

				//for z, the moving platform will move -20 to +20 from its position, so must put it 20 away to not crash
				float zadd = 40.0f;

				//will it be added to the back or front? Check what last one was, add to the same.
				int ZposOrNeg = ZpositiveOrNegative[j-1];

				//if going out of boundaries on POS side, switch to NEG
				if(((randomZHolder[j-1] + 25.0f) > 50.0f)){
					ZposOrNeg = 0;
				}
				else if(((randomZHolder[j-1] - 25.0f) < -120.0f)){
					ZposOrNeg = 1;

				}
				//if negative or postive add/sub the scale Z (7 for yBF) and add/sub the random range
				if (ZposOrNeg == 0) {
					randomZ = randomZHolder [j - 1] - 7.0f - zadd;
				} else if (ZposOrNeg == 1) {
					randomZ = randomZHolder [j - 1] + 7.0f + zadd;
				}

				randomXHolder [j] = randomX;
				randomYHolder [j] = randomY;
				randomZHolder [j] = randomZ;
				XpositiveOrNegative [j] = XposOrNeg;
				ZpositiveOrNegative [j] = ZposOrNeg;


			}
			if ((j != 0) && (randomPlatformHolder [j - 1] == availablePlatforms [2])) {///////////////////////////////////////////XBF
				//if the last platform is xBF


				///////////////////////////////////////////////////////////////////////////////////////////////////////// Y

				//if the last platform is xBF, next platform will stay on the same level
				randomY = randomYHolder[j-1];

				///////////////////////////////////////////////////////////////////////////////////////////////////////// Z
				//the x that will be added -- keep it same as last since the z will be moving
				float zadd = randomZHolder[j - 1];

				//will it be added to the back or front? Check what last was and keep the same
				int ZposOrNeg = ZpositiveOrNegative[j-1];

				//if going out of boundaries on POS side, switch to NEG
				if(((randomZHolder[j-1] + 10) > 50)){
					ZposOrNeg = 0;
				}
				else if(((randomZHolder[j-1] - 10) < -120)){
					ZposOrNeg = 1;

				}
				//if negative or postive add/sub the scale X (7 for falling) and add/sub the random range
				if (ZposOrNeg == 0) {
					randomZ = randomZHolder [j - 1];
				} else if (ZposOrNeg == 1) {
					randomZ = randomZHolder [j - 1];
				}

				///////////////////////////////////////////////////////////////////////////////////////////////////////// X

				//for z, the moving platform will move -20 to +20 from its position, so must put it 20 away to not crash
				float xadd = 40.0f;

				//will it be added to the back or front? Check what last one was, add to the same.
				int XposOrNeg = XpositiveOrNegative[j-1];

				//if going out of boundaries on POS side, switch to NEG
				if(((randomXHolder[j-1] + 25.0f) > 50.0f)){
					XposOrNeg = 0;
				}
				else if(((randomXHolder[j-1] - 25.0f) < -120.0f)){
					XposOrNeg = 1;

				}
				//if negative or postive add/sub the scale Z (7 for yBF) and add/sub the random range
				if (XposOrNeg == 0) {
					randomX = randomXHolder [j - 1] - 7.0f - xadd;
				} else if (XposOrNeg == 1) {
					randomX = randomXHolder [j - 1] + 7.0f + xadd;
				}

				randomXHolder [j] = randomX;
				randomYHolder [j] = randomY;
				randomZHolder [j] = randomZ;
				XpositiveOrNegative [j] = XposOrNeg;
				ZpositiveOrNegative [j] = ZposOrNeg;



			}
			if ( (j != 0) && (randomPlatformHolder [j - 1] == availablePlatforms [3])) {///////////////////////////////////////////ROTATE
				//if the last platform is rotate, rotates left

				///////////////////////////////////////////////////////////////////////////////////////////////////////// Y

				//if the last platform is falling
				randomY = Random.Range(3.0f, 5.0f);
				randomY += randomYHolder [j - 1];  

				///////////////////////////////////////////////////////////////////////////////////////////////////////// X
				//the x that will be added
				float xadd = Random.Range (1.0f, 2.0f);

				//will it be added to the back or front, check last
				int XposOrNeg = XpositiveOrNegative[j-1];

				//if going out of boundaries on POS side, switch to NEG
				if(((randomXHolder[j-1] + 10) > 50)){
					XposOrNeg = 0;
				}
				else if(((randomXHolder[j-1] - 10) < -120)){
					XposOrNeg = 1;

				}
				//if negative or postive add/sub the scale X (7 for rotate) and add/sub the random range
				if (XposOrNeg == 0) {
					randomX = randomXHolder [j - 1] - 20.0f - xadd;
				} else if (XposOrNeg == 1) {
					randomX = randomXHolder [j - 1] + 20.0f + xadd;
				}

				///////////////////////////////////////////////////////////////////////////////////////////////////////// Z

				//now we do the same for the Z position, how much will it move by
				float zadd = Random.Range(1.0f, 2.0f);

				//will it be added to the back or front, check last one
				int ZposOrNeg = ZpositiveOrNegative[j-1];

				//if going out of boundaries on POS side, switch to NEG
				if(((randomZHolder[j-1] + 10.0f) > 50.0f)){
					ZposOrNeg = 0;
				}
				else if(((randomZHolder[j-1] - 10.0f) < -120.0f)){
					ZposOrNeg = 1;

				}
				//if negative or postive add/sub the scale X (7 for rotate) and add/sub the random range
				if (ZposOrNeg == 0) {
					randomZ = randomZHolder [j - 1] - 7.0f - zadd;
				} else if (ZposOrNeg == 1) {
					randomZ = randomZHolder [j - 1] + 7.0f + zadd;
				}

				randomXHolder [j] = randomX;
				randomYHolder [j] = randomY;
				randomZHolder [j] = randomZ;
				XpositiveOrNegative [j] = XposOrNeg;
				ZpositiveOrNegative [j] = ZposOrNeg;



			}
			if ( (j != 0) && (randomPlatformHolder [j - 1] == availablePlatforms [4])) {///////////////////////////////////////////SPIN
				//if the last platform is spinning

				///////////////////////////////////////////////////////////////////////////////////////////////////////// Y


				randomY = Random.Range(3.0f, 5.0f);
				randomY += randomYHolder [j - 1];  

				///////////////////////////////////////////////////////////////////////////////////////////////////////// X
				//the x that will be added,
				float xadd = Random.Range (1.0f, 2.0f);

				//will it be added to the back or front, check last
				int XposOrNeg = XpositiveOrNegative[j-1];

				//if going out of boundaries on POS side, switch to NEG
				if(((randomXHolder[j-1] + 10) > 50)){
					XposOrNeg = 0;
				}
				else if(((randomXHolder[j-1] - 10) < -120)){
					XposOrNeg = 1;

				}
				//if negative or postive add/sub the scale X (2 for spin) and add/sub the random range
				if (XposOrNeg == 0) {
					randomX = randomXHolder [j - 1] - 2.0f - xadd;
				} else if (XposOrNeg == 1) {
					randomX = randomXHolder [j - 1] + 2.0f + xadd;
				}

				///////////////////////////////////////////////////////////////////////////////////////////////////////// Z

				//now we do the same for the Z position, how much will it move by
				float zadd = Random.Range(1.0f, 2.0f);

				//will it be added to the back or front, check last
				int ZposOrNeg = ZpositiveOrNegative[j-1];

				//if going out of boundaries on POS side, switch to NEG
				if(((randomZHolder[j-1] + 10.0f) > 50.0f)){
					ZposOrNeg = 0;
				}
				else if(((randomZHolder[j-1] - 10.0f) < -120.0f)){
					ZposOrNeg = 1;

				}
				//if negative or postive add/sub the scale X (20 for spin) and add/sub the random range
				if (ZposOrNeg == 0) {
					randomZ = randomZHolder [j - 1] - 20.0f - zadd;
				} else if (ZposOrNeg == 1) {
					randomZ = randomZHolder [j - 1] + 20.0f + zadd;
				}

				randomXHolder [j] = randomX;
				randomYHolder [j] = randomY;
				randomZHolder [j] = randomZ;
				XpositiveOrNegative [j] = XposOrNeg;
				ZpositiveOrNegative [j] = ZposOrNeg;




			}
			if ( (j != 0) && (randomPlatformHolder [j - 1] == availablePlatforms [5])) {///////////////////////////////////////////SMALL
				//if the last platform is small



				///////////////////////////////////////////////////////////////////////////////////////////////////////// Y


				randomY = Random.Range(3.0f, 5.0f);
				randomY += randomYHolder [j - 1];

				///////////////////////////////////////////////////////////////////////////////////////////////////////// X
				//the x that will be added
				float xadd = Random.Range (1.0f, 2.0f);

				//will it be added to the back or front
				int XposOrNeg = XpositiveOrNegative[j-1];

				//if going out of boundaries on POS side, switch to NEG
				if(((randomXHolder[j-1] + 10) > 50)){
					XposOrNeg = 0;
				}
				else if(((randomXHolder[j-1] - 10) < -120)){
					XposOrNeg = 1;

				}
				//if negative or postive add/sub the scale X (20 for small) and add/sub the random range
				if (XposOrNeg == 0) {
					randomX = randomXHolder [j - 1] - 20.0f - xadd;
				} else if (XposOrNeg == 1) {
					randomX = randomXHolder [j - 1] + 20.0f + xadd;
				}

				///////////////////////////////////////////////////////////////////////////////////////////////////////// Z

				//now we do the same for the Z position, how much will it move by
				float zadd = Random.Range(1.0f, 2.0f);

				//will it be added to the back or front
				int ZposOrNeg = ZpositiveOrNegative[j-1];

				//if going out of boundaries on POS side, switch to NEG
				if(((randomZHolder[j-1] + 10.0f) > 50.0f)){
					ZposOrNeg = 0;
				}
				else if(((randomZHolder[j-1] - 10.0f) < -120.0f)){
					ZposOrNeg = 1;

				}
				//if negative or postive add/sub the scale Z (10 for small) and add/sub the random range
				if (ZposOrNeg == 0) {
					randomZ = randomZHolder [j - 1] - 10.0f - zadd;
				} else if (ZposOrNeg == 1) {
					randomZ = randomZHolder [j - 1] + 10.0f + zadd;
				}

				randomXHolder [j] = randomX;
				randomYHolder [j] = randomY;
				randomZHolder [j] = randomZ;
				XpositiveOrNegative [j] = XposOrNeg;
				ZpositiveOrNegative [j] = ZposOrNeg;

			}
			if ( (j != 0) && (randomPlatformHolder [j - 1] == availablePlatforms [6])) {///////////////////////////////////////////MEDIUM
				//if the last platform is medium


				///////////////////////////////////////////////////////////////////////////////////////////////////////// Y


				randomY = Random.Range(3.0f, 5.0f);
				randomY += randomYHolder [j - 1];

				///////////////////////////////////////////////////////////////////////////////////////////////////////// X
				//the x that will be added
				float xadd = Random.Range (1.0f, 2.0f);

				//will it be added to the back or front
				int XposOrNeg = XpositiveOrNegative[j-1];

				//if going out of boundaries on POS side, switch to NEG
				if(((randomXHolder[j-1] + 10) > 50)){
					XposOrNeg = 0;
				}
				else if(((randomXHolder[j-1] - 10) < -120)){
					XposOrNeg = 1;

				}
				//if negative or postive add/sub the scale X (50 for medium) and add/sub the random range
				if (XposOrNeg == 0) {
					randomX = randomXHolder [j - 1] - 50.0f - xadd;
					randomXHolder [j - 1] += -15.0f;
				} else if (XposOrNeg == 1) {
					randomX = randomXHolder [j - 1] + 50.0f + xadd;
					randomXHolder [j - 1] += 15.0f;
				}

				///////////////////////////////////////////////////////////////////////////////////////////////////////// Z

				//now we do the same for the Z position, how much will it move by
				float zadd = Random.Range(1.0f, 2.0f);

				//will it be added to the back or front
				int ZposOrNeg = ZpositiveOrNegative[j-1];

				//if going out of boundaries on POS side, switch to NEG
				if(((randomZHolder[j-1] + 10.0f) > 50.0f)){
					ZposOrNeg = 0;
				}
				else if(((randomZHolder[j-1] - 10.0f) < -120.0f)){
					ZposOrNeg = 1;

				}
				//if negative or postive add/sub the scale Z (20 for medium) and add/sub the random range
				if (ZposOrNeg == 0) {
					randomZ = randomZHolder [j - 1] - 20.0f - zadd;
					randomZHolder [j-1] += -9.0f;
				} else if (ZposOrNeg == 1) {
					randomZ = randomZHolder [j - 1] + 20.0f + zadd;
					randomZHolder [j-1] += 9.0f;
				}

				randomXHolder [j] = randomX;
				randomYHolder [j] = randomY;
				randomZHolder [j] = randomZ;
				XpositiveOrNegative [j] = XposOrNeg;
				ZpositiveOrNegative [j] = ZposOrNeg;


			

			}
			if ((j != 0) && (randomPlatformHolder [j - 1] == availablePlatforms [7])) {///////////////////////////////////////////LARGE
				//if the last platform is large


				///////////////////////////////////////////////////////////////////////////////////////////////////////// Y


				randomY = Random.Range(3.0f, 5.0f);
				randomY += randomYHolder [j - 1];

				///////////////////////////////////////////////////////////////////////////////////////////////////////// X
				//the x that will be added
				float xadd = Random.Range (1.0f, 2.0f);

				//will it be added to the back or front
				int XposOrNeg = XpositiveOrNegative[j-1];

				//if going out of boundaries on POS side, switch to NEG
				if(((randomXHolder[j-1] + 10) > 50)){
					XposOrNeg = 0;
				}
				else if(((randomXHolder[j-1] - 10) < -120)){
					XposOrNeg = 1;

				}
				//if negative or postive add/sub the scale X (100 for large) and add/sub the random range
				if (XposOrNeg == 0) {
					randomX = randomXHolder [j - 1] - 50.0f - xadd;
					//randomXHolder [j - 1] += -30.0f;
				} else if (XposOrNeg == 1) {
					randomX = randomXHolder [j - 1] + 50.0f + xadd;
					//randomXHolder [j - 1] += 30.0f;
				}

				///////////////////////////////////////////////////////////////////////////////////////////////////////// Z

				//now we do the same for the Z position, how much will it move by
				float zadd = Random.Range(1.0f, 2.0f);

				//will it be added to the back or front
				int ZposOrNeg = ZpositiveOrNegative[j-1];

				//if going out of boundaries on POS side, switch to NEG
				if(((randomZHolder[j-1] + 10.0f) > 50.0f)){
					ZposOrNeg = 0;
				}
				else if(((randomZHolder[j-1] - 10.0f) < -120.0f)){
					ZposOrNeg = 1;

				}
				//if negative or postive add/sub the scale Z (30 for large) and add/sub the random range
				if (ZposOrNeg == 0) {
					randomZ = randomZHolder [j - 1] - 15.0f - zadd;
					//randomZHolder [j-1] += -9.0f;
				} else if (ZposOrNeg == 1) {
					randomZ = randomZHolder [j - 1] + 25.0f + zadd;
					//randomZHolder [j-1] += 9.0f;
				}

				randomXHolder [j] = randomX;
				randomYHolder [j] = randomY;
				randomZHolder [j] = randomZ;
				XpositiveOrNegative [j] = XposOrNeg;
				ZpositiveOrNegative [j] = ZposOrNeg;



			}
			if ((j != 0) && (randomPlatformHolder [j - 1] == availablePlatforms [8])) {///////////////////////////////////////////REGULAR
				//if the last platform is regular

		

				///////////////////////////////////////////////////////////////////////////////////////////////////////// Y


				randomY = Random.Range(3.0f, 5.0f);
				randomY += randomYHolder [j - 1];

				///////////////////////////////////////////////////////////////////////////////////////////////////////// X
				//the x that will be added
				float xadd = Random.Range (1.0f, 2.0f);

				//will it be added to the back or front
				int XposOrNeg = XpositiveOrNegative[j-1];

				//if going out of boundaries on POS side, switch to NEG
				if(((randomXHolder[j-1] + 10) > 50)){
					XposOrNeg = 0;
				}
				else if(((randomXHolder[j-1] - 10) < -120)){
					XposOrNeg = 1;

				}
				//if negative or postive add/sub the scale X (10 for regular) and add/sub the random range
				if (XposOrNeg == 0) {
					randomX = randomXHolder [j - 1] - 10.0f - xadd;
				} else if (XposOrNeg == 1) {
					randomX = randomXHolder [j - 1] + 10.0f + xadd;
				}

				///////////////////////////////////////////////////////////////////////////////////////////////////////// Z

				//now we do the same for the Z position, how much will it move by
				float zadd = Random.Range(1.0f, 2.0f);

				//will it be added to the back or front
				int ZposOrNeg = ZpositiveOrNegative[j-1];

				//if going out of boundaries on POS side, switch to NEG
				if(((randomZHolder[j-1] + 10.0f) > 50.0f)){
					ZposOrNeg = 0;
				}
				else if(((randomZHolder[j-1] - 10.0f) < -120.0f)){
					ZposOrNeg = 1;

				}
				//if negative or postive add/sub the scale Z (10 for regular) and add/sub the random range
				if (ZposOrNeg == 0) {
					randomZ = randomZHolder [j - 1] - 10.0f - zadd;
				} else if (ZposOrNeg == 1) {
					randomZ = randomZHolder [j - 1] + 10.0f + zadd;
				}

				randomXHolder [j] = randomX;
				randomYHolder [j] = randomY;
				randomZHolder [j] = randomZ;
				XpositiveOrNegative [j] = XposOrNeg;
				ZpositiveOrNegative [j] = ZposOrNeg;



			}

		}
	}


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
	
	// Update is called once per frame
	void Update () {
		
	}
}
