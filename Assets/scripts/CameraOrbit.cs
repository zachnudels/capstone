using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour {

	const float angle = 20;
	Vector3 parPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Rotate orbiting camera
		parPos = transform.parent.position;
//		Debug.Log (parPos);
		transform.RotateAround (parPos, Vector3.up, angle * Time.deltaTime);
		transform.LookAt (parPos);
	}
}
