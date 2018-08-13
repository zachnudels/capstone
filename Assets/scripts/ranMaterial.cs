using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ranMaterial : MonoBehaviour {
	
	public Material mat1;
	public Material mat2;
	public Material mat3;
	public Material mat4;
	public Material mat5;
	public Material mat6;
	public Material mat7;
	public Material mat8;
	public Material mat9;
	public Material mat10;


	Material [] matHold = new Material[10];


	Material makeRanMat(){

		matHold [0] = mat1;
		matHold [1] = mat2;
		matHold [2] = mat3;
		matHold [3] = mat4;
		matHold [4] = mat5;
		matHold [5] = mat6;
		matHold [6] = mat7;
		matHold [7] = mat8;
		matHold [8] = mat9;
		matHold [9] = mat10;

		int ranNum = Random.Range (0, 10);
		Material ranOne = matHold [ranNum];
		return ranOne;


	
	}

	// Use this for initialization
	void Start () {
		Material prefMaterial = makeRanMat ();
		this.GetComponent <Renderer>().material = prefMaterial;

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
