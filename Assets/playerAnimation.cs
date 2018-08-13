using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimation : MonoBehaviour {

	Animator animator;
	void Awake(){
		animator = GetComponentInChildren<Animator> ();
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetFloat ("Vertical", Manager.Instance.InputControl.Vertical);
	}
}
