using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class PlatformAI : MonoBehaviour {


	public indexFinder[] platforms;
	public NavMeshLink[] links;
	public MoveTo moveTo;
//	public int platformLength;
	// Use this for initialization
	void Start () {
		platforms = FindObjectsOfType<indexFinder>().OrderBy( go => go.name ).ToArray();
//		Array.Sort(platforms,
//			delegate(indexFinder x, indexFinder y) { return x.chance.CompareTo(y.chance); });
		links = new NavMeshLink[platforms.Length];

//		GameObject currPlatform = platforms [0];

		for (int i = 0; i < platforms.Length; i++) 
		{
			platforms [i].GetComponent<NavMeshSurface>().BuildNavMesh ();   
		} 

		GameObject firstLinkObj = new GameObject();
		NavMeshLink firstLink = firstLinkObj.AddComponent<NavMeshLink>();
		firstLink.startPoint = new Vector3 (-4.7f, -8.1f, -20.15f);
		firstLink.endPoint = platforms [0].gameObject.transform.position;
		firstLink.UpdateLink ();
		firstLink.costModifier = 1;

		for(int i = 1; i != platforms.Length; ++i) {
//			string currname = "Platform" + i;
//			string prevname = "Platform" + (i-1);
//			Debug.Log (currname);
//			Transform currPlatformT = transform.Find ("Platform1");
//			if (currPlatformT == null) {
//				Debug.Log (i);
//			} else {
			GameObject currPlatform = platforms[i-1].gameObject;
			GameObject nextPlatform = platforms[i].gameObject;
//			Debug.Log (currPlatform.name + " " + nextPlatform.name);
			Vector3 currCent = currPlatform.transform.position;
			Vector3 nextCent = nextPlatform.transform.position;
//				NavMeshLink currLink = currPlatform.AddComponent<NavMeshLink>();
			GameObject linkObj = new GameObject();
//			Instantiate (linkObj, Vector3.zero, Quaternion.identity);
			NavMeshLink currLink = linkObj.AddComponent<NavMeshLink>();
				//			Vector3 thisCent =  currPlatform.transform.position;
				//			Vector3 prevCent = prevPlatform.transform.position;
				//			Vector3 dir = Vector3.Normalize ((thisCent - prevCent));
				currLink.startPoint = currCent;
//			Debug.Log (currLink.startPoint);
				currLink.endPoint = nextCent;
			currLink.costModifier = 1;
//			currLink.transform.position = Vector3.zero;
			currLink.UpdateLink();
			currLink.costModifier = 1;
			links [i] = currLink;
//			}


		}
		moveTo.enabled = true;
		  
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 1; i != links.Length; ++i) {
			if (i == 1) {
//				Debug.Log (links [i].startPoint);
			}
//			links [i].UpdateLink ();
		}

	}
}
