using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinCubeCollid : MonoBehaviour {

	bool onSpin;
	public GameObject Player;
	private RaycastHit hit;


	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag("Player").gameObject;
		
	}

	// Update is called once per frame
	void Update () {
		string hitThing = "";
		Ray ray = new Ray (Player.transform.position + (new Vector3 (-0.1f, 0.2f, -0.1f)), (Vector3.down));
		onSpin = Physics.Raycast (ray, out hit, 1 );
		if (hit.collider != null) {
			hitThing = hit.collider.tag;
			Debug.Log ("Tag:" +hit.collider.tag);
		}

//		Debug.Log (Player == null);
		Debug.DrawRay (Player.transform.position + (new Vector3 (-0.1f, 0.2f, -0.1f)), Vector3.down, Color.green);
		if (onSpin && hitThing == "spinPlat") {
			Player.transform.parent.parent = transform;
		} else if (!onSpin) {
			Player.transform.parent.parent = null;
		}

		
	}
}
