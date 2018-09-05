using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightOrbit : MonoBehaviour {

	const float angle = 1;
	Vector3 rotation;

	// Use this for initialization
	void Start () {
		rotation = new Vector3 (0, angle, 0);
	}
	
	// Update is called once per frame
	void Update () {
		//Rotate orbiting camera
//		parPos = transform.parent.position;
//		Debug.Log (parPos);
		transform.Rotate (rotation, Space.World);
//		transform.LookAt (parPos);
	}
}
