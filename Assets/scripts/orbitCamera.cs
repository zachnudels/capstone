using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbitCamera : MonoBehaviour {

	public GameObject target = null;


	public bool orbitY = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) {
			transform.LookAt (target.transform);

			if (orbitY) {
				transform.RotateAround (target.transform.position, Vector3.up, Time.deltaTime * 10);
			}

			//allows to change the position of the camera
			if (Input.GetKey(KeyCode.O)) {
				float holder = transform.position.y;
				holder += 0.5f;

				transform.position = new Vector3 (transform.position.x, holder, transform.position.z);
				//Ahead.transform.position.y += 1;
			}
			if (Input.GetKey(KeyCode.I)) {
				float holder = transform.position.y;
				holder -= 0.5f;

				transform.position = new Vector3 (transform.position.x, holder, transform.position.z);
				//Ahead.transform.position.y += 1;
			}
			float xHold = transform.position.x;
			float yHold = transform.position.y;

			if (Input.GetKey(KeyCode.L)) {
				float holder = transform.position.z;

				holder += 0.5f;
				transform.position = new Vector3 (xHold, yHold, holder);
				//isnt taking into account the change in rotation of y
			}
			if (Input.GetKey(KeyCode.K)) {
				float holder = transform.position.z;
				holder -= 0.5f;
				transform.position = new Vector3 (xHold, yHold, holder);
			}

		}

	}
}
