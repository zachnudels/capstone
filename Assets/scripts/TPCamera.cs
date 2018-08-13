using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPCamera : MonoBehaviour {

	// The target we are following
	[SerializeField]
	private Transform target;


	[SerializeField]
	private float rotationDamping;

	[SerializeField]
	private Vector3 targetOffset;

	[SerializeField]
	private Vector3 rotationOffset;

	private float turning;
	public int turnSpeed = 100;



//	private Quaternion rotOffset;

	// Use this for initialization
	void Start () {
		turning = 0.0f;
		targetOffset.Set (targetOffset.x * target.transform.lossyScale.x,
			targetOffset.y * target.transform.lossyScale.y,	
			targetOffset.z * target.transform.lossyScale.z);
//		rotOffset = Quaternion.Euler (rotationOffset);
//		rotationOffset.Set(rotationOffset.x * target.transform.lossyScale.x,
//			rotationOffset.y,	
//			rotationOffset.z * target.transform.lossyScale.z);
	}

	// Update is called once per frame
	void Update () {
		Vector3 targetPos = new Vector3 (target.position.x, target.position.y, target.position.z);
		if (Input.GetKey (KeyCode.Space)) {
			targetPos.y = transform.position.y;
			
//			target.position.Set(target.position.x,transform.position.y,target.position.z);

//			transform.rotation = target.rotation;
//			return;
		}
		transform.position = targetPos;
		transform.rotation = target.rotation;

//		turning = Input.GetAxis("Horizontal");
//		transform.RotateAround (target.transform.position, target.transform.TransformDirection(Vector3.up) , turnSpeed*turning*Time.deltaTime);

//		transform.rotation = Quaternion.Euler(target.rotation.eulerAngles+rotationOffset);
//		transform.LookAt(target);
//		Debug.Log(transform.position + " " + transform.rotation.eulerAngles);
//		Debug.Log(target.position);
		
	}
}
