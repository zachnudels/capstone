using UnityEngine;
using System.Collections;

public class yBackForth : MonoBehaviour
{
	public float speed = 25;
	public float rightLimit = 20f;
	public float leftLimit = 50f;
	private int direction = 1;


	void Start(){
		rightLimit = transform.position.z + 20f;
		leftLimit = transform.position.z + -20f;
	}
	void Update(){
		if (transform.position.z > rightLimit)
			direction = -1;
		else if (transform.position.z < leftLimit)
			direction = 1;

		//movement = Vector3.right * direction * speed * Time.deltaTime;
		transform.Translate (Vector3.forward * direction * speed * Time.deltaTime);
	}
		
}
