using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manage  {

	public event System.Action<PlayerC> playerJoined;
	private GameObject gameObject;

	public static Manage manager;

	public static Manage Instance{
		get {
			if (manager == null) {

				manager = new Manage();
				manager.gameObject = new GameObject("gameManager");
				manager.gameObject.AddComponent<InputC>();
			}
			return manager;
		}
	}

	private InputC inputC;
	public InputC InputControl {
		get{
			if (inputC == null) {
				inputC = gameObject.GetComponent<InputC> ();


			}
			return inputC;
		}
	}
	private PlayerC l_Player;
	public PlayerC LocalPlayer{
		get{ 
			return l_Player;
		}
		set{ 
			l_Player = value;
			if (playerJoined != null)
				playerJoined (l_Player);
		}
	}

}
