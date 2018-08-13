using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager  {

	public event System.Action<Player> playerJoined;
	private GameObject gameObject;

	public static Manager manager;

	public static Manager Instance{
		get {
			if (manager == null) {
				
				manager = new Manager();
				manager.gameObject = new GameObject("gameManager");
				manager.gameObject.AddComponent<InputControl>();
			}
			return manager;
		}
	}

	private InputControl inputC;
	public InputControl InputControl {
		get{
			if (inputC == null) {
				inputC = gameObject.GetComponent<InputControl> ();

				
			}
			return inputC;
		}
	}
	private Player l_Player;
	public Player LocalPlayer{
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
