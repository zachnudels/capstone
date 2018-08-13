using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControl : MonoBehaviour {

	public float Vertical;
	public float Horizontal;
	public Vector2 Mouse;
	public bool ShootFirst;
	public bool ShootFPS;

	//controls the user input
	void Update(){
		Vertical = Input.GetAxis("Vertical");
		Horizontal = Input.GetAxis("Horizontal");
		Mouse = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
		ShootFirst = Input.GetMouseButtonDown (0);
		ShootFPS = Input.GetKeyDown(KeyCode.Q);
	}

}
