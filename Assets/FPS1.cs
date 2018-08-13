using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS1 : MonoBehaviour {

	[SerializeField]Vector3 cameraOffset;
	[SerializeField]float damping;

	public bool thisIsOnFirst;
	public orbitCamera orbit;
	//public fpsCamera fps;


	Transform Ahead;
	GameObject cam;

	public Player localPlayer;
	// Use this for initialization
	void Awake () {
		Manager.Instance.playerJoined += HandleOnPlayerJoined;;
		cam = GameObject.Find ("FPS1");
	}

	void HandleOnPlayerJoined(Player player){
		localPlayer = player;
		Ahead = localPlayer.transform.Find ("AheadFPS");
		cam = GameObject.Find("FPS1");
		//cam = localPlayer.transform.Find ("Main Camera");


		if (Ahead == null)
			Ahead = localPlayer.transform;
	}

	// Update is called once per frame
	//Sets target position and adds transforms in front of player then moves camera behind player
	void Update () {
		Vector3 targPos = Ahead.position + localPlayer.transform.forward * cameraOffset.z
			+ localPlayer.transform.up * cameraOffset.y +
			localPlayer.transform.right * cameraOffset.x;

		//allows to change position of fps camera

		if (Input.GetKey(KeyCode.O)) {
			float holder = Ahead.transform.position.y;
			holder += 0.5f;

			Ahead.transform.position = new Vector3 (Ahead.transform.position.x, holder, Ahead.transform.position.z);
			//Ahead.transform.position.y += 1;
		}
		if (Input.GetKey(KeyCode.I)) {
			float holder = Ahead.transform.position.y;
			holder -= 0.5f;

			Ahead.transform.position = new Vector3 (Ahead.transform.position.x, holder, Ahead.transform.position.z);
			//Ahead.transform.position.y += 1;
		}
		float xHold = Ahead.transform.position.x;
		float yHold = Ahead.transform.position.y;

		if (Input.GetKey(KeyCode.L)) {
			float holder = Ahead.transform.position.z;

			holder += 0.5f;
			Ahead.transform.position = new Vector3 (xHold, yHold, holder);
			//isnt taking into account the change in rotation of y
		}
		if (Input.GetKey(KeyCode.K)) {
			float holder = Ahead.transform.position.z;
			holder -= 0.5f;
			Ahead.transform.position = new Vector3 (xHold, yHold, holder);
		}

		Quaternion tRot = Quaternion.LookRotation (Ahead.position - targPos, Vector3.up);

		transform.position = Vector3.Lerp (transform.position, targPos, damping + Time.deltaTime);
		transform.rotation = Quaternion.Lerp (transform.rotation,tRot, damping + Time.deltaTime);
	}
}
