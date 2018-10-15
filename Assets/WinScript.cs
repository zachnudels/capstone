using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WinScript : NetworkBehaviour {

	[SyncVar]
	public bool win = false;

	// Use this for initialization
	void Start () {

			win = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
