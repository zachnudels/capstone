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


		GameObject currPlatform = platforms[0].gameObject;
		GameObject nextPlatform = platforms[1].gameObject;

		Bounds currBound;
		Bounds nextBound;

		Vector3 currYBump = Vector3.zero;
		Vector3 nextYBump = Vector3.zero;

		Vector3 currCent;




		if (currPlatform.transform.childCount > 0) {
			currBound = currPlatform.GetComponentInChildren<Renderer> ().bounds;
			currYBump += new Vector3 (0, currBound.extents.y, 0);
		} else {
			currBound = currPlatform.GetComponent<Renderer> ().bounds;
		}
		currCent = currBound.center + currYBump;

		float currMag = Vector3.Magnitude (new Vector3 (currBound.extents.x, 0, currBound.extents.z)) * 0.5f;


		for(int i = 0; i != platforms.Length; ++i) {

			nextPlatform = platforms [i].gameObject;

			if (nextPlatform.tag == "spinPlat")
				continue;
	



			if (nextPlatform.transform.childCount > 0) {
				nextBound = nextPlatform.GetComponentInChildren<Renderer> ().bounds;
				nextYBump += new Vector3 (0, nextBound.extents.y, 0);
			} else {
				nextBound = nextPlatform.GetComponent<Renderer> ().bounds;
			}



			Vector3 nextCent = nextBound.center + nextYBump;

			GameObject linkObj = new GameObject();
			NavMeshLink currLink = linkObj.AddComponent<NavMeshLink>();

			Vector3 direction = nextBound.center - currBound.center;

			Vector3 forwardDir = Vector3.Normalize(new Vector3(direction.x, 0 , direction.z));


			float nextMag = Vector3.Magnitude (new Vector3 (nextBound.extents.x, 0, nextBound.extents.z)) * 0.5f;


			currLink.startPoint = currCent + currMag*(forwardDir);
			currLink.endPoint = nextCent - (nextMag*forwardDir);
			currLink.UpdateLink();
			currLink.costModifier = 1;
			links [i] = currLink;

			currPlatform = nextPlatform;
			currBound = nextBound;
			currCent = nextCent;
			currMag = nextMag;


		}
		moveTo.enabled = true;
		  
	}
	
	// Update is called once per frame
	void Update () {
	}
}
