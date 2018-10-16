using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.ThirdPerson; 
using UnityEngine;
using UnityEngine.AI;

public class AIPowerup : MonoBehaviour {

	GameObject model;
	public GameObject AI;
	public GameObject particleEffect;
	public NavMeshSurface surface;
	//	public ThirdPersonCharacter modelControl;
	//	public MoveTo moveto;
	//	public NavMeshAgent agent;
	GameObject modelChild;
	Vector3 pos;
	Quaternion rot;


	// Use this for initialization
	void Start () {
		//		model = transform.Find ("ModelParent").gameObject;
		//		modelChild = transform.Find ("ModelChild").gameObject;

	}



	IEnumerator OnTriggerEnter (Collider col) {
		if (col.CompareTag ("myPlayer")) {
			Debug.Log ("Collision");
			model = col.gameObject.transform.gameObject;
			Debug.Log (model.name);
			pos = model.transform.position;
			rot = model.transform.rotation;

			Debug.Log ("Instantiating AI");


			//			
			//			Destroy (model);

			//			GameObject AI = AIModel;// model.GetComponentInParent<Sibling> ().sibling;

			//			
			//			Instantiate(AIModel, pos, rot);
			AI.GetComponent<MoveTo>().model = GameObject.FindWithTag ("myPlayer");

			//			Destroy(model);
			model.SetActive(false);

			//			yield return new WaitForSeconds (1);
			AI.SetActive (false);
			//			AI.transform.position = pos;
			//			surface.BuildNavMesh ();

			AI.GetComponent<NavMeshAgent> ().enabled = false;
			AI.GetComponent<NavMeshAgent> ().updatePosition = false;
			AI.GetComponent<MoveTo> ().enabled = false;

			//			AI.GetComponent<NavMeshAgent> ().Warp (pos);
//			AI.transform.rotation = rot;

			//			AI.GetComponent<NavMeshAgent> ().enabled = true;
			//			AI.GetComponent<MoveTo> ().enabled = true;
			AI.SetActive (true);

			AI.GetComponent<Agent> ().enabled = true;
			AI.GetComponent<NavMeshAgent> ().enabled = true;
			AI.GetComponent<MoveTo> ().enabled = true;
			AI.GetComponent<NavMeshAgent> ().updatePosition = true;
			//			Debug.Log (AI.GetComponent<NavMeshAgent> ().pathStatus);


			//			AI.transform.rotation = rot;

			//			Instantiate(AIModel, pos, rot);






			//			model.SetActive (false);

			//			

			//			AIModelO.GetComponent<MoveTo> ().enabled = true;
			//			AI.SetActive(false);
			//			AI.SetActive (true);



			//			model.GetComponent<NavMeshAgent> ().enabled = true;
			//			model.GetComponent<Animator> ().enabled = true;
			//			model.GetComponent<AgentLinkMover> ().enabled = true;
			//			model.GetComponent<MoveTo> ().enabled = true;


			//Speed(col);
			//			Instantiate (particleEffect, transform.position, transform.rotation);

			//			MeshRenderer mesh = GetComponent<MeshRenderer> ();
			//			mesh.enabled = false;

			// Disable Mesh Collider here


			//			anim = col.GetComponent<Animator> ();

			//			anim.speed = 2;

		}
		yield return new WaitForSecondsRealtime (1);

		Destroy (gameObject);
		//		Destroy (particleEffect, 1.2f);

		//		yield return new WaitForSeconds (3);
		//		anim.speed = 1;


	}

	// Update is called once per frame
	void Update () {

	}
}