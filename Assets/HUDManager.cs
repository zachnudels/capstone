using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {

	private string index_string;
	private int i;
	public Text platform_text;
	public List < GameObject > p_ups;
	private int list_indexer;




	// Use this for initialization
	void Start () {
		index_string = "";
		i = 0;
		list_indexer = 0;


	}


	
	// Update is called once per frame
	void Update () {

		for (int i = 0; i < p_ups.Count; i++) {
			p_ups [i].SetActive(false);
		}
		p_ups [list_indexer].SetActive(true);
		if (Input.GetKeyDown (KeyCode.Tab)) {
			list_indexer++;
			if (list_indexer == p_ups.Count) {
				list_indexer = 0;
			}
		}
		

	}
	void OnCollisionEnter (Collision col) {
		Debug.Log (col.transform.name);
		i = col.transform.GetComponent<indexFinder> ().index + 1;
		index_string = i.ToString ();
		platform_text.text = "Platform: " + index_string;
	}

}
