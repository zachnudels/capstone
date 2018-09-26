using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson; 

public class MoveTo : MonoBehaviour {
	
	public Transform goal;
	public ThirdPersonCharacter character;
	NavMeshAgent agent;

	void Start () {
		agent = GetComponent<NavMeshAgent>();
		agent.destination = goal.position; 
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