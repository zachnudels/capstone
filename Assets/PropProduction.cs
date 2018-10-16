using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PropProduction : MonoBehaviour {

	public GameObject[] props;

	// Use this for initialization

	//Instantiate random props with random textures
	void Start () {
		for (int i = 0; i != 30; ++i) {
			Instantiate (props [(Random.Range (0, props.Length))], new Vector3 (Random.Range (-500, 490), Random.Range (0, 300), Random.Range (-500, 490)), Quaternion.identity);
		}
	
	}
	
	// Update is called once per frame
	//Instantiate new props to shoot every 3 seconds
	void Update () {
	}
}
