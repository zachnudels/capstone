using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {

	private string index_string;
	private int i;
	public Text platform_text;




	// Use this for initialization
	void Start () {
		index_string = "";
		i = 0;

		
	}


	
	// Update is called once per frame
	void Update () {

	}
	void OnCollisionEnter (Collision col) {
		Debug.Log (col.transform.name);
		i = col.transform.GetComponent<indexFinder> ().index + 1;
		index_string = i.ToString ();
		platform_text.text = "Platform: " + index_string;
	}

}
