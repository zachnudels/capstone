using UnityEngine;
using System.Collections;

public class forwardBack : MonoBehaviour
{
	public float speed = 2;
	public float rightLimit = 0;
	public float leftLimit = 0;
	private int direction = 1;


	//right and left limits are set -- the bounds where the platform can move
	void Start(){
		rightLimit = transform.position.x + 20f;
		leftLimit = transform.position.x + -20f;
	}

	//Checks if the platform has hit these bounds, and if so reverses the direction
	void Update(){
		if (transform.position.x > rightLimit)
			direction = -1;
		else if (transform.position.x < leftLimit)
			direction = 1;
		
		//movement = Vector3.right * direction * speed * Time.deltaTime;
		transform.Translate (Vector3.right * direction * speed * Time.deltaTime);
	}
		
}
