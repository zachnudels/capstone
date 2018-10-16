using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour {

	public int speed;
	public bool checkpoint;

	float time = 3;

	HUDManager hud;

	public GameObject SpawnObject;
	private float spawnx, spawny, spawnz;

	private Rigidbody RB;

	private Animator anim;

	private MCSAnimationController mcs;
	// Use this for initialization
	void Start () {
		speed = 0;
		checkpoint = false;
		hud = transform.GetComponent<HUDManager> ();

		RB = transform.GetComponent<Rigidbody> ();

		anim = transform.GetComponentInChildren<Animator> ();

		mcs = transform.GetComponentInChildren<MCSAnimationController> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.P)) {
			for (int i = 0; i < hud.p_ups.Count; i++) {
				if (hud.p_ups[i].name == "Speed" && (speed > 0) ) {
					speed--;
					mcs.anim_speed = 2;

					//int t = 3;
					time-= Time.deltaTime;
					/*if (time <= 0) {
						anim.speed = 1;
					}*/
				}


				if (hud.p_ups[i].name == "Checkpoint") {
					// Add Checkpoint to Game World with Key Press 'R'
					if (checkpoint==true) {
						Instantiate (SpawnObject, transform.position, transform.rotation);
						spawnx = transform.position.x;
						spawny = transform.position.y;
						spawnz = transform.position.z;
						checkpoint = false;

						//Debug.Log (SpawnObject.transform.position);
					}

					//Debug.Log (RB.velocity.y);

					// If falling, move back to Checkpoint
					if (RB.velocity.y < -55 && spawnx != 0 && spawny != 0 && spawnz != 0) {
						transform.position = new Vector3 (spawnx, spawny, spawnz);
					}
					//checkpoint = false;

				}
			}

		}




		
	}
}
