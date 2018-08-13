using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveC))]
public class PlayerC : MonoBehaviour {


	[System.Serializable]
	public class mInput{
		public Vector2 Damping;
		public Vector2 Sensitivty;

	}
	[SerializeField]float speed;
	[SerializeField]mInput mouseControl;

	private MoveC moveC;
	public MoveC MoveControl {
		get{ 
			if (moveC == null) {
				moveC = GetComponent<MoveC> ();
			}

			return moveC;
		}
	}




	void Awake () {
		Manage.Instance.LocalPlayer = this;
	}

	// Update is called once per frame
	void Update () {
		Vector2 direction = new Vector2 (Manage.Instance.InputControl.Vertical * speed, Manage.Instance.InputControl.Horizontal * speed);
		MoveControl.Move(direction);
	}

}
