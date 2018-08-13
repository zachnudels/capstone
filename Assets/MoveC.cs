using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveC : MonoBehaviour {

	public void Move(Vector2 dir){
		transform.position += transform.forward * dir.x * Time.deltaTime + transform.right * dir.y * Time.deltaTime;
	}
}
