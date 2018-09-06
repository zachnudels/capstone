using UnityEngine;
using System.Collections;

public class rotateUp : MonoBehaviour
{
	public float speed;
	void makeRandomSpeed(){
		speed = Random.Range (3.0f, 15.0f);
	}



	void Update ()
	{
		makeRandomSpeed ();
		transform.Rotate(Vector3.left, speed * Time.deltaTime);
	}
}
