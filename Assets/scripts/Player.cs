using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveControl))]
[RequireComponent(typeof(AudioSource))]
public class Player : MonoBehaviour {


	[System.Serializable]
	public class mInput{
		public Vector2 Damping;
		public Vector2 Sensitivty;
	
	}
	AudioClip walk;

	[SerializeField]float speed = 0.4f;
	[SerializeField]mInput mouseControl;
	[SerializeField]AudioClip steps;
	[SerializeField]AudioSource source;

	public float jumpSpeed;
	public float jumpStrength = 10;
	public float gravity = 14;



	bool isGrounded = false;


	//finds a move controller
	private MoveControl moveC;
	public MoveControl MoveControl {
		get{ 
			if (moveC == null) {
				moveC = GetComponent<MoveControl> ();
			}
				
			return moveC;
		}
	}

	Vector2 mouseIn;


	//my attempt of trying to make the player jump
	void onCollisionEnter(Collision other){
		if (other.gameObject.name == "floor") {
			isGrounded = true;
		}
	}

	void onCollisionExit(Collision other){
		
		if (other.gameObject.name == "floor") {
			isGrounded = false;
		}
	}

	void Start () {
		source = GetComponent<AudioSource> ();
		//canPlay = true;
	}




	void Awake () {
		Manager.Instance.LocalPlayer = this;
	}

	public float timeBetween = 5;
	float time;
	float lastTime = 0;

	// Update is called once per frame
	void Update () {

		//moves the player in certain direction
		time = Time.deltaTime;
		
		Vector2 direction = new Vector2 (Manager.Instance.InputControl.Vertical * speed, Manager.Instance.InputControl.Horizontal);


		//my attempt at making the footsteps sound work 
		if(Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0){
			if (time - lastTime < timeBetween) {
				source.PlayOneShot(steps);
			}

		}


		MoveControl.Move(direction);

		mouseIn.x = Mathf.Lerp (mouseIn.x, Manager.Instance.InputControl.Horizontal * speed, 1f / mouseControl.Damping.x);

		transform.Rotate (Vector3.up * mouseIn.x * mouseControl.Sensitivty.x);
	}

}
