using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalObject : MonoBehaviour {

	public static GlobalObject Instance;
	public float xScore;
	public float yScore;

	void Awake ()   
	{
		if (Instance == null)
		{
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy (gameObject);
		}
	}
	

}
