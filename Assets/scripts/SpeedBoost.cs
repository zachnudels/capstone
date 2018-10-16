using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour {

	// Use this for initialization
	public GameObject particleEffect;
	public float mytime;
	Animator anim;


	IEnumerator OnTriggerEnter (Collider col) {
		if (col.CompareTag ("myPlayer")) {
			//Speed(col);
			Instantiate (particleEffect, transform.position, transform.rotation);

			MeshRenderer mesh = GetComponent<MeshRenderer> ();
			mesh.enabled = false;

			// Disable Mesh Collider here

			col.GetComponentInParent<PowerUpManager> ().speed++;
			/*
			anim = col.GetComponent<Animator> ();

			anim.speed = 2;
			*/
		}
		Destroy (particleEffect, 1.2f);

		yield return new WaitForSeconds (3);
		//anim.speed = 1;

		Destroy (gameObject);

	}

	/*
	void Speed(Collider player) {
		Instantiate (particleEffect, transform.position, transform.rotation);
//		Destroy (particleEffect, 2);
		//Destroy (gameObject);

		anim = player.GetComponent<Animator> ();

		//if (anim.getAnimat
		//anim.speed = 2;
		//if (anim.GetCurrentAnimatorStateInfo (0).IsName("Walking")) {
			anim.speed = 2;


	}
*/
}
