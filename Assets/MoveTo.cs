using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson; 

public class MoveTo : MonoBehaviour {
	
	public Transform goal;
	public ThirdPersonCharacter character;
	NavMeshAgent agent;
	public GameObject[] platforms;


	void Start () {
		
		platforms = GetComponent<generatePlatforms> ().randomPlatformHolder;
		agent = GetComponent<NavMeshAgent>();
//		agent.destination = goal.position; 
		agent.destination = platforms[platforms.Length-1].transform.position;
		agent.updateRotation = false;
	}

	void Update(){
//		Debug.Log (agent.velocity.y);
		if (agent.remainingDistance > agent.stoppingDistance) {
			character.Move (agent.desiredVelocity, false, true);
		} else {
			character.Move (Vector3.zero, false, false);
		}

	}


}