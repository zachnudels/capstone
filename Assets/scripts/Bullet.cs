using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour {

	[SerializeField]float speed;
	[SerializeField]float timeToLive;
	[SerializeField]float damage;

	//make a bullet shoot, did this before raycasting

	void Start(){
		Destroy(gameObject, timeToLive);
	}

	void Update(){

		transform.Translate (Vector3.forward * speed * Time.deltaTime);

	}
		
	void onTriggerEnter(Collider other){
		print ("Hit something" + other.name);
	}
}
