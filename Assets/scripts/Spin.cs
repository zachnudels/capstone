using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour
{
	//allows the platform to spin
	public float speed = 20f;


	void Update ()
	{
		transform.Rotate(Vector3.up, speed * Time.deltaTime);
	}
}
