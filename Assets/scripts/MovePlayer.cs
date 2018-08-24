﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

	public float speed = 6.0f;
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;
	public float rotateSpeed = 3.0f;
	private Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		CharacterController controller = GetComponent<CharacterController> ();


			moveDirection = new Vector3 (0, 0, Input.GetAxis ("Vertical"));
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection *= speed;
			if (Input.GetButton ("Jump")) {
				moveDirection.y = jumpSpeed;
			}
		if (Input.GetKey (KeyCode.C)) {
			moveDirection.y = -jumpSpeed;
		}
			


		//moveDirection.y -= gravity * Time.deltaTime;
		controller.Move (moveDirection * Time.deltaTime);

		transform.Rotate (0, Input.GetAxis ("Horizontal"), 0);


	}
}
