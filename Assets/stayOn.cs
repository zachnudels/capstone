using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stayOn : MonoBehaviour {


	void OnTriggerEnter(Collider other){

		if(other.gameObject.tag == "platform"){
			transform.parent = other.transform;

		}
	}

	void OnTriggerExit(Collider other){
		if(other.gameObject.tag == "platform"){
			transform.parent = null;

		}
	} 



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
