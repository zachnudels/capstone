using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cap : MonoBehaviour {


	public float speed = 15;
	// Use this for initialization
	void Start () {
		print ("started");
	}
	
	// Update is called once per frame
	void Update () {

		//print (Input.GetAxis ());
		transform.Translate (Input.GetAxis("Horizontal")* Time.deltaTime *speed, 0f, Input.GetAxis("Vertical")* Time.deltaTime * speed);
	}
}
