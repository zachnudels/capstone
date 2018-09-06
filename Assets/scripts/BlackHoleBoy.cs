using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleBoy : MonoBehaviour {

	private float delta;  // Amount to move left and right from the start point
	private float speed = 0.5f; 
	private Vector3 startPos;
	private bool start;
	private bool playerIn;
	private float pullRadius = 20;
	private float timePassed = 0;
	private float forceStrength = 1;
	private bool still = false;

	// Use this for initialization
	void Start () {
		startPos = transform.position;
		delta = -2.0f;
		playerIn = false;
		start = true;

	}
	
	// Update is called once per frame
	void Update () {
		shimmy ();
		pullPlayer();
		//Debug.Log (timePassed);
		if (timePassed > 20) {
			Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter(Collider other){
		if (start && delta < -1.0f && other.gameObject.tag == "platform") {
			Bounds bounds = other.GetComponent<MeshRenderer> ().bounds;
			delta = bounds.max.x - bounds.min.x;
			delta /= 3;
			speed = delta / 12;
			start = false;
		} 
		if (other.gameObject.tag == "Player" && !still) {
			playerIn = true;
			still = true;
		}
	}
		
	//Move side to side
	void shimmy(){
		if (!playerIn) {
			Vector3 v = startPos;
			v.x += delta * Mathf.Sin (Time.time * speed);
			transform.position = v;
		} else {
			timePassed += Time.deltaTime;
		}
	}

	void pullPlayer(){
		foreach (Collider collider in Physics.OverlapSphere(transform.position, pullRadius)) {

			// apply force on target towards me
			if (collider.tag == "Player") {
				Vector3 forceDir = transform.position - collider.transform.position;
				forceDir = new Vector3 (forceDir.x, 0.0f, forceDir.z);
				collider.gameObject.GetComponentInParent<Rigidbody>().AddRelativeForce(forceDir*forceStrength,ForceMode.Force);
			}
		}
	}
		
}
