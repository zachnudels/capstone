using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCSAnimationController : MonoBehaviour {

	private Animator anim;
	private float walking;
	private float turning;
	private bool jump;
	public int turnSpeed;
	public float gravity;
	public float ground = 0.0f;
	public GameObject fp;
	public GameObject tp;
	public GameObject orb;
	private GameObject currentCam;
	public GameObject TPSloc;
	private Vector3 forward;
	private Vector3 up;
	private int time;
	private bool inJump;


//	private Vector3 idleGunPos;
//	private Quaternion idleGunRot;
//	private Vector3 movingGunPos;
//	private Quaternion movingGunRot;
	private Vector3 velocity;
//	private Transform idleTrans;
	// Use this for initialization
	void Start () {
		forward = Vector3.zero;
		up = Vector3.zero;
		currentCam = tp;
		anim = GetComponent<Animator> ();
		walking = 0.0f; 
		time = 0;
		turning = 0.0f;
		inJump = false;
		jump = false;
		Physics.gravity = new Vector3 (0, gravity, 0);;


	}
	
	// Update is called once per frame
	void Update () {

		//Change the camera angle on key change
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			tp.SetActive (false);
			orb.SetActive (false);
			fp.SetActive (true);
			currentCam = fp;
		}
		if(Input.GetKeyDown(KeyCode.Alpha2)){
			tp.SetActive (true);
			orb.SetActive (false);
			fp.SetActive (false);
			currentCam = tp;
		}
		if(Input.GetKeyDown(KeyCode.Alpha3)){
			tp.SetActive (false);
			orb.SetActive (true);
			fp.SetActive (false);
			currentCam = orb;
		}


		//Change the camera position on key changes
		if (currentCam != fp) {
			if (Input.GetKey (KeyCode.J)) {
				currentCam.transform.position -= currentCam.transform.TransformDirection (Vector3.forward);
			} else if (Input.GetKey (KeyCode.L)) {
				currentCam.transform.position += currentCam.transform.TransformDirection (Vector3.forward);
			}
			if (Input.GetKey (KeyCode.I)) {
				currentCam.transform.position += currentCam.transform.TransformDirection (Vector3.up);
			} else if (Input.GetKey (KeyCode.K)) {
				currentCam.transform.position -= currentCam.transform.TransformDirection (Vector3.up);
			}
		} else {
			if (Input.GetKey (KeyCode.J)) {
				currentCam.transform.position -= currentCam.transform.TransformDirection (Vector3.right);
			} else if (Input.GetKey (KeyCode.L)) {
				currentCam.transform.position += currentCam.transform.TransformDirection (Vector3.right);
			}
			if (Input.GetKey (KeyCode.I)) {
				currentCam.transform.position += currentCam.transform.TransformDirection (Vector3.up);
			} else if (Input.GetKey (KeyCode.K)) {
				currentCam.transform.position -= currentCam.transform.TransformDirection (Vector3.up);
			}
		}

			
		walking = Input.GetAxis ("Vertical");
		anim.SetFloat ("walking", walking);
		turning = Input.GetAxis("Horizontal");
		transform.Rotate (new Vector3 (0.0f, turnSpeed*turning*Time.deltaTime));
		jump = Input.GetKeyDown (KeyCode.Space);
		if (jump) {
			inJump = true;
		}
		jump = Input.GetKey (KeyCode.Space);
		anim.SetBool ("jump", jump);

		if (inJump) {
//			Debug.Log (time);
			transform.Translate (Vector3.forward*Time.deltaTime*5);
			if (time < 7) {
				
				transform.Translate (Vector3.up*Time.deltaTime*6);
			} else {
				transform.Translate (-Vector3.up*Time.deltaTime*6);
			}

			time++;
			if (time == 15) {
				transform.Translate (Vector3.forward*Time.deltaTime*5);
				time = 0;
				inJump = false;
			}
		}



		}
			
}
