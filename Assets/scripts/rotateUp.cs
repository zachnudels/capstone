using UnityEngine;
using System.Collections;

public class rotateUp : MonoBehaviour
{

	//allows the platform to rotate
	public float speed = 20f;


	void Update ()
	{
		transform.Rotate(Vector3.left, speed * Time.deltaTime);
	}
}
