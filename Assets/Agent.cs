using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour {

	NavMeshAgent agent;
	MoveTo move;

	// Use this for initialization
	void Start () {
//		agent.isStopped = true;
//		move.enabled = true;
//		agent.enabled = true;
//		agent.isStopped = false;
	}

	void Awake()
	{
		agent = gameObject.GetComponent<NavMeshAgent> ();
//		yield return new WaitForSeconds (1);
		move = gameObject.GetComponent<MoveTo> ();
		move.enabled = true;
		agent.enabled = true;
	}


	
	// Update is called once per frame
	void Update () {
		
	}
}
