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
			if (platforms [i] == null) {
				Debug.Log (i + " is null");
			} else {
				platforms [i].GetComponent<NavMeshSurface>().BuildNavMesh ();   
			}

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

			Bounds nextBound = nextPlatform.GetComponent<Renderer> ().bounds;
			Bounds currBound = currPlatform.GetComponent<Renderer> ().bounds;


//			Debug.Log (currPlatform.name + " " + nextPlatform.name);
			Vector3 currCent = currPlatform.transform.position;
			Vector3 nextCent = nextPlatform.transform.position;
//				NavMeshLink currLink = currPlatform.AddComponent<NavMeshLink>();
			GameObject linkObj = new GameObject();
//			Instantiate (linkObj, Vector3.zero, Quaternion.identity);
			NavMeshLink currLink = linkObj.AddComponent<NavMeshLink>();

			Vector3 direction = nextBound.center - currBound.center;

			Vector3 forwardDir = Vector3.Normalize(new Vector3(direction.x, 0 , direction.z));

			float currMag = Vector3.Magnitude (new Vector3 (currBound.extents.x, 0, currBound.extents.z))*0.5f;
			float nextMag = Vector3.Magnitude (new Vector3 (nextBound.extents.x, 0, nextBound.extents.z)) * 0.5f;
				//			Vector3 thisCent =  currPlatform.transform.position;
				//			Vector3 prevCent = prevPlatform.transform.position;
				//			Vector3 dir = Vector3.Normalize ((thisCent - prevCent));
			currLink.startPoint = currCent + currMag*(forwardDir);

//			Debug.Log (currLink.startPoint);
			currLink.endPoint = nextCent - (nextMag*forwardDir);// - nextBound.extents + new Vector3(1, 0, 1);
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
