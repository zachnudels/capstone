using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour {

	public int speed;
	public bool checkpoint;

	HUDManager hud;


	// Use this for initialization
	void Start () {
		speed = 0;
		checkpoint = false;
		hud = transform.GetComponent<HUDManager> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.P)) {
			for (int i = 0; i < hud.p_ups.Count; i++) {
				if (hud.p_ups[i].name == "Speed") {
					speed--;
				}
				if (hud.p_ups[i].name == "Checkpoint") {
					checkpoint = false;

				}
			}

		}




		
	}
}
