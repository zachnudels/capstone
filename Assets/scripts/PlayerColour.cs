using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerColour : NetworkBehaviour {

	private NetworkIdentity id;

	// Use this for initialization
	void Start () {
		SkinnedMeshRenderer mesh1 = GetComponent<SkinnedMeshRenderer> ();

		//Component rt = transform.root;

		id = transform.root.GetComponent<NetworkIdentity> ();



		//GetCom
		Color colour;
		if (id.isLocalPlayer) {
			colour = new Color (1, 0, 0);
			mesh1.material.color = colour;
		}

		if (!id.isLocalPlayer) {
			colour = new Color (0, 0, 1);
			mesh1.material.color = colour;
		}

		//mesh1.material.color = colour;
	}
	
	// Update is called once per frame
	void Update () {
		//mesh1.
		
	}
}
