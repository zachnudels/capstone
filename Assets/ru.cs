using UnityEngine;
using System.Collections;

public class ru : MonoBehaviour
{
	public float speed = 20f;


	void Update ()
	{
		transform.Rotate(Vector3.left, speed * Time.deltaTime);
	}
}
