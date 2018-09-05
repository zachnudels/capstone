using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attach : MonoBehaviour {

	// Use this for initialization
	GameObject Player;

	void Start () {

		Player = GameObject.FindGameObjectWithTag("Player").gameObject;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
