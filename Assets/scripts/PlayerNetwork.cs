using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerNetwork : NetworkBehaviour {

	private NetworkIdentity id;

	private NetworkAnimator anim;

	// Use this for initialization
	void Start () {

		id = GetComponent<NetworkIdentity> ();

		//id = GetComponentInChildren<NetworkIdentity> ();

		//anim = GetComponent<NetworkAnimator> ();

		anim = GetComponent<NetworkAnimator> ();

		//transform.GetComponent<NetworkAnimator> ().SetParameterAutoSend (0, true);
		//transform.GetComponent<NetworkAnimator> ().SetParameterAutoSend (1, true);
	}
	
	// Update is called once per frame
	void Update () {

		if (id.isLocalPlayer) {
			anim.GetParameterAutoSend (0);
			anim.GetParameterAutoSend (1);
			anim.GetParameterAutoSend (2);
			anim.GetParameterAutoSend (3);
		}

		anim.SetParameterAutoSend (0, true);
		anim.SetParameterAutoSend (1, true);
		anim.SetParameterAutoSend (2, true);
		anim.SetParameterAutoSend (3, true);
	}
}
