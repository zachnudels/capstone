using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Shoot : MonoBehaviour {

	[SerializeField]float fireRate;
	//[SerializeField]Bullet bullet;

	[HideInInspector]
	public Transform muzzle;
	[SerializeField]AudioClip destroy;
	[SerializeField]AudioSource sourceOther;
	[SerializeField]AudioClip shoot;
	[SerializeField]AudioSource source;
	[SerializeField]AudioClip background;
	[SerializeField]AudioSource sourceSecondOther;

	bool canShoot;
	float nextShoot;
	public int range = 100;

	//allows the raycast to go out from the tip of the gun
	void Awake(){
		muzzle = transform.Find("Muzzle");
	}

	public virtual void ShootIt(){
		print ("shooting");
		source.PlayOneShot (shoot);

		//set up for raycasting
		RaycastHit hit;

		if (Physics.Raycast (muzzle.position, muzzle.transform.forward, out hit, range)) {
			Debug.Log (hit.transform.name + " found!");
			Destroy (hit.collider.gameObject);
			sourceOther.PlayOneShot (destroy);
		}

		canShoot = true;
	
	}

}
