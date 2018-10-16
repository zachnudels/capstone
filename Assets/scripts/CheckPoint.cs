using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

	public GameObject particleEffect;

	IEnumerator OnTriggerEnter (Collider col) {

		if (col.CompareTag ("myPlayer")) {
			//Speed(col);
			Instantiate (particleEffect, transform.position, transform.rotation);

			MeshRenderer mesh = GetComponent<MeshRenderer> ();
			mesh.enabled = false;

			// Disable Mesh Collider here
			PowerUpManager pman = col.GetComponentInParent<PowerUpManager>();
			pman.checkpoint = true;



		}
		Destroy (particleEffect, 1.2f);

		yield return new WaitForSeconds (3);
		//anim.speed = 1;
		Destroy (gameObject);

	}
}
