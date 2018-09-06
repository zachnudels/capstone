using UnityEngine;
using System.Collections;

public class forwardBack : MonoBehaviour
{
	public float speed;
	public float rightLimit = 20f;
	public float leftLimit = 50f;
	public int direction = 1;

	void OnCollisionEnter(Collision collision){
		print ("trigger has hit " + collision.gameObject.tag);
		if (collision.gameObject.tag == "platform" || collision.gameObject.tag == "spinPlat" ) {
			print ("changed direction");
			direction = direction * -1;
		}
	}



	void Start(){
		rightLimit = transform.position.x + 20f;
		//change -20
		leftLimit = transform.position.x -20f;
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
