using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionBoost : MonoBehaviour {

	public GameObject particleEffect;

	void OnTriggerEnter (Collider col) {
		if (col.CompareTag ("myPlayer")) {
			yBoost(col);
		}
	}

	IEnumerator ExecuteAfterTime(float time) {
		yield return new WaitForSeconds (time);
	}

	void yBoost(Collider player) {
		Instantiate (particleEffect, transform.position, transform.rotation);
		Destroy (particleEffect, 2);
		Destroy (gameObject);

		//Animator anim = player.GetComponent<Animator> ();
		//if (anim.getAnimat
		player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 10.0f, player.transform.position.z);

		//ExecuteAfterTime (3);

		//anim.speed = 1;

		//WaitForSeconds(5);

		//anim.speed = 1;
	}
}
