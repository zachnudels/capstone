using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MCSAnimationController : NetworkBehaviour {

	private Animator anim;
	private float walking;
	private float turning;
	private bool jump;
	public int turnSpeed;
	public float gravity;
	public float ground = 0.0f;

	public GameObject tp;
	private Rigidbody RB;

	private GameObject currentCam;
	public GameObject TPSloc;
	private int time;
	private bool inJump;
	private float jumpTime;
	private RaycastHit hit;


	//	private Vector3 idleGunPos;
	//	private Quaternion idleGunRot;
	//	private Vector3 movingGunPos;
	//	private Quaternion movingGunRot;
	private Vector3 velocity;
	//	private Transform idleTrans;
	// Use this for initialization

	public bool spawner = false;
	public GameObject SpawnObject;
	private float spawnx, spawny, spawnz;

	private NetworkIdentity id;
	public Camera cam;

	void Start () {
		currentCam = tp;
		anim = GetComponent<Animator> ();
		walking = 0.0f; 
		time = 0;
		turning = 0.0f;
		inJump = false;
		jump = false;
		spawner = false;
		Physics.gravity = new Vector3 (0, gravity, 0);
		RB = GetComponentInParent<Rigidbody> ();
		//id = GetComponent<NetworkIdentity> ();
		id = gameObject.transform.parent.gameObject.GetComponent<NetworkIdentity>();

		if (!id.isLocalPlayer) {
			cam.enabled = false;
		}

	}

	// Update is called once per frame
	void Update () {

		if (id.isLocalPlayer) {

			//transform.GetComponent<NetworkAnimator> ().GetParameterAutoSend (0);
			//transform.GetComponent<NetworkAnimator> ().GetParameterAutoSend (1);

			jumpTime += Time.unscaledDeltaTime;

			walking = Input.GetAxis ("Vertical");
			anim.SetFloat ("walking", walking);
			turning = Input.GetAxis ("Horizontal");
			transform.Rotate (new Vector3 (0.0f, turnSpeed * turning * Time.deltaTime));

			bool jumpHit = Input.GetKeyDown (KeyCode.Space);
			bool onGround = Physics.Raycast (transform.position + (new Vector3 (-0.1f, 0.0f, -0.1f)), (Vector3.down), out hit, 0.2f);
			if (onGround && hit.collider.tag == "spinPlat") {
				Debug.Log ("Hit");
				transform.parent.parent = hit.collider.gameObject.transform;

			} else {
				transform.parent.parent = null;
			}
			anim.SetBool ("onGround", onGround);

			jump = Input.GetKey (KeyCode.Space);
			anim.SetBool ("jump", jumpHit);
			if (jumpHit)
				//Debug.Log (jumpTime);

			if (jumpHit && jumpTime > 1.2f) {

				jumpTime = 0.0f;
				RB.mass = 0.1f;
				inJump = true;
			}
			if (inJump) {
				//			Debug.Log (time);
				//			transform.Translate (Vector3.forward*Time.deltaTime*2);
				if (time < 7) {
					RB.AddRelativeForce (new Vector3 (0.0f, 21.0f, 0.0f));
					//				RB.AddRelativeForce (transform.Find("M3DFemale").forward*6);



					//				transform.Translate (Vector3.up*Time.deltaTime*3);
					//				RB.mass = 0.05f;
				} else if (time > 7 || !jump) {
					//				RB.AddRelativeForce (new Vector3 (0.0f, -21.0f, 0.0f));
					//				transform.Translate (-Vector3.up*Time.deltaTime*3);
					//				RB.mass = 70.0f;
				}

				time++;
				if (time == 15) {
					//				transform.Translate (Vector3.forward*Time.deltaTime);
					time = 0;
					inJump = false;
				}
			}
			//		Debug.DrawRay (transform.position+(new Vector3(0.0f, 0.1f, 0.0f)), Vector3.down);
			//		Debug.Log (transform.position);
			if (!inJump) {
				bool fall = !Physics.Raycast (transform.position + (new Vector3 (0.0f, 0.1f, 0.0f)), (Vector3.down), out hit, 4.5f);
				anim.SetBool ("fall", fall);
			}

			if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Roll")) {
				Debug.Log ("Roll");
				RB.AddRelativeForce (new Vector3 (0.0f, -5.0f, 0.0f));
			}

			// Add Checkpoint to Game World with Key Press 'R'
			if (Input.GetKeyDown (KeyCode.R) && spawner==true) {
				Instantiate (SpawnObject, transform.position, transform.rotation);
				spawnx = transform.position.x;
				spawny = transform.position.y;
				spawnz = transform.position.z;
				spawner = false;

				//Debug.Log (SpawnObject.transform.position);
			}

			//Debug.Log (RB.velocity.y);

			// If falling, move back to Checkpoint
			if (RB.velocity.y < -55 && spawnx != 0 && spawny != 0 && spawnz != 0) {
				transform.position = new Vector3 (spawnx, spawny, spawnz);
			}

			if (Input.GetKeyDown (KeyCode.P)) {
				Debug.Log (spawnx);
				Debug.Log (spawny);
				Debug.Log (spawnz);
			}



			//		Debug.Log (fall);


		}

	}

}
