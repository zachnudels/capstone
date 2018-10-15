using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson; 

public class MoveTo : MonoBehaviour {

	//	public Transform goal;
	public ThirdPersonCharacter character;
	NavMeshAgent agent;
	public indexFinder[] platforms;
	public int pathLength;
	public GameObject model;


	void Start () {

		platforms = FindObjectsOfType<indexFinder>().OrderBy( go => go.name ).ToArray();
		agent = GetComponent<NavMeshAgent>();
		//		agent.destination = goal.position;
		agent.destination = platforms[pathLength].transform.position; 
		Debug.Log (agent.destination);

		//		agent.destination = platforms[platforms.Length-1].transform.position;
		agent.updateRotation = false;
	}

	void Update(){
		//		Debug.Log (agent.velocity.y);
		//		agent.destination = platforms[platforms.Length-1].transform.position; 
		if (agent.remainingDistance > agent.stoppingDistance) {
			//			Debug.Log ("Still trying");
			character.Move (agent.desiredVelocity, false, true);
		} else {
			character.Move (Vector3.zero, false, false);
			agent.gameObject.SetActive (false);

			//			GameObject model = FindObjectOfType<Sibling> ().gameObject;
			model.transform.SetPositionAndRotation (transform.position, transform.rotation);
			model.SetActive (true);

			//			Debug.Log (agent.destination);
			//			Debug.Log (transform.position);
			//			Debug.Log (agent.remainingDistance);
		}

	}


}