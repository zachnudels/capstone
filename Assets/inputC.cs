using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputC : MonoBehaviour {

	public float Vertical;
	public float Horizontal;
	public Vector2 Mouse;

	void Update(){
		Vertical = Input.GetAxis("Vertical");
		Horizontal = Input.GetAxis("Horizontal");
		Mouse = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
	}

}
