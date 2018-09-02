using UnityEngine;
using System.Collections;

public class forwardBack : MonoBehaviour
{
	public float speed;
	public float rightLimit = 20f;
	public float leftLimit = 50f;
	private int direction = 1;


	void Start(){
		rightLimit = transform.position.x + 35f;
		//change -20
		leftLimit = transform.position.x;
		speed = Random.Range(2.0f, 20.0f);
	}
	void Update(){
		if (transform.position.x > rightLimit)
			direction = -1;
		else if (transform.position.x < leftLimit)
			direction = 1;
		
		//movement = Vector3.right * direction * speed * Time.deltaTime;
		transform.Translate (Vector3.right * direction * speed * Time.deltaTime);
	}
		
}
