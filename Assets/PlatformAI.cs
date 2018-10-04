using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlatformAI : MonoBehaviour {


//	public GameObject[] platforms;
	public int platformLength;
	// Use this for initialization
	void Start () {
//		for(int i = 1; i != platformLength-1; ++i) {
//			string currname = "Platform" + i;
//			string prevname = "Platform" + (i-1);
//			Debug.Log (currname);
			Transform currPlatformT = transform.Find ("Platform1");
			if (currPlatformT == null) {
				Debug.Log ("No platform found");
			} else {
//				GameObject currPlatform = currPlatformT.gameObject;
//				Vector3 currCent = transform.Find (currname).position;
//				Vector3 prevCent = transform.Find (prevname).position;
//				NavMeshLink currLink = currPlatform.AddComponent<NavMeshLink>();
//				//			Vector3 thisCent =  currPlatform.transform.position;
//				//			Vector3 prevCent = prevPlatform.transform.position;
//				//			Vector3 dir = Vector3.Normalize ((thisCent - prevCent));
//				currLink.startPoint = prevCent;
//				currLink.endPoint = currCent;
			}


//		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
