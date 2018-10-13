using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sibling : MonoBehaviour {

	public GameObject sibling;
	public bool setTransfom;

	// Use this for initialization
	void Start () {
		
	}

	public void disable(){
		sibling.SetActive (false);
	}

	public void enable(){
		sibling.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		if(setTransfom)
			sibling.transform.SetPositionAndRotation (transform.position, transform.rotation);
	}
}
