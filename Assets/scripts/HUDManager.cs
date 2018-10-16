using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

public class HUDManager : NetworkBehaviour {

	private string index_string;
	private int i;
	public TextMeshProUGUI platform_text;
	public List < GameObject > p_ups;
	public GameObject canvas;
	private int list_indexer;
	public GameObject win_text;
	public GameObject lose_text;

	public GameObject Win;

	private NetworkIdentity id;



	// Use this for initialization
	void Start () {
		index_string = "";
		i = 0;
		list_indexer = 0;
		id = GetComponent<NetworkIdentity> ();
		platform_text = GetComponent<TextMeshProUGUI> ();

		if (!id.isLocalPlayer) {
			canvas.SetActive (false);
		}


	}


	
	// Update is called once per frame
	void Update () {

		for (int i = 0; i < p_ups.Count; i++) {
			p_ups [i].SetActive(false);
		}
		p_ups [list_indexer].SetActive(true);


		p_ups [0].GetComponentInChildren<TextMeshProUGUI> ().text = transform.GetComponent<PowerUpManager> ().speed.ToString ();

		if (transform.GetComponent<PowerUpManager> ().checkpoint == true) {
			p_ups [1].GetComponentInChildren<TextMeshProUGUI> ().text = "1";
		}
		if (transform.GetComponent<PowerUpManager> ().checkpoint == false) {
			p_ups [1].GetComponentInChildren<TextMeshProUGUI> ().text = "0";
		}

		if (Input.GetKeyDown (KeyCode.Tab)) {
			list_indexer++;
			if (list_indexer == p_ups.Count) {
				list_indexer = 0;
			}
		}

		if (Win.GetComponent<WinScript> ().win) {
			if (transform.GetComponent<WinnerCheck> ().win) {
				win_text.SetActive (true);
			}
			else {
				lose_text.SetActive (true);
			}
		}

		Win.GetComponent<WinScript> ().win = false;
	}
	void OnCollisionEnter (Collision col) {
		Debug.Log (col.transform.name);
		i = col.transform.GetComponent<indexFinder> ().index + 1;
		index_string = i.ToString ();
		platform_text.text = "Platform: " + index_string;
	}

}
