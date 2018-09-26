using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlatformAI : MonoBehaviour {


	public GameObject[] platforms;
	// Use this for initialization
	void Start () {
		platforms = GetComponent<generatePlatforms> ().randomPlatformHolder;
		for(int i = 1; i != platforms.Length; ++i) {
			NavMeshLink currLink = platforms[i].AddComponent<NavMeshLink>();
			Vector3 thisCent = platforms [i].transform.position;
			Vector3 prevCent = platforms [i - 1].transform.position;
			Vector3 dir = (thisCent - prevCent).Normalize ();

		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
