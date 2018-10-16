using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEns : MonoBehaviour {
	public static GlobalEns instance;
//	public EnemyScript en0;

//	// Use this for initialization
//	void Start () {
//		
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		
//	}

	void Awake ()   
	{
		if (instance == null)
		{
			DontDestroyOnLoad(gameObject);
//			DontDestroyOnLoad(en0);
//			DontDestroyOnLoad(en1);
//			DontDestroyOnLoad(en2);
//			DontDestroyOnLoad(en3);


			instance = this;
		}
		else if (instance != this)
		{
			Destroy (gameObject);
		}
			
	}
}
