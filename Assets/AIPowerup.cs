﻿using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.ThirdPerson; 
using UnityEngine;
using UnityEngine.AI;

public class AIPowerup : MonoBehaviour {

	GameObject model;
	public GameObject particleEffect;
//	public ThirdPersonCharacter modelControl;
//	public MoveTo moveto;
//	public NavMeshAgent agent;
	GameObject modelChild;


	// Use this for initialization
	void Start () {
//		model = transform.Find ("ModelParent").gameObject;
//		modelChild = transform.Find ("ModelChild").gameObject;

	}



	IEnumerator OnTriggerEnter (Collider col) {
		if (col.CompareTag ("Player")) {
			Debug.Log ("Collision");
			model = col.gameObject.transform.parent.gameObject;

			GameObject AI = model.GetComponentInParent<Sibling> ().sibling;
			AI.SetActive (true);
			AI.GetComponent<MoveTo> ().enabled = true;

			model.SetActive (false);



//			model.GetComponent<NavMeshAgent> ().enabled = true;
//			model.GetComponent<Animator> ().enabled = true;
//			model.GetComponent<AgentLinkMover> ().enabled = true;
//			model.GetComponent<MoveTo> ().enabled = true;


			//Speed(col);
//			Instantiate (particleEffect, transform.position, transform.rotation);

//			MeshRenderer mesh = GetComponent<MeshRenderer> ();
//			mesh.enabled = false;

			// Disable Mesh Collider here


//			anim = col.GetComponent<Animator> ();

//			anim.speed = 2;

		}
//		Destroy (particleEffect, 1.2f);

		yield return new WaitForSeconds (3);
//		anim.speed = 1;
		Destroy (gameObject);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
