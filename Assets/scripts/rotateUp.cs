using UnityEngine;
using System.Collections;

public class rotateUp : MonoBehaviour
{
	public float speed;
	public bool steady = true;
	public float time = 0.0f;
	public float steadyTime = 5.0f;
	public float startTime;
	public float rot;
	public float newRot;
	public float timer = 5.0f;

	void makeRandomSpeed(){
		speed = Random.Range (3.0f, 15.0f);
	}

	void Start(){
		rot = this.transform.eulerAngles.x;
		print ("this is" + rot);
		startTime = Time.time;
	}
		

//	float m_timer = 3.0f;
//
//	void Update()
//	{
//		m_timer -= Time.deltaTime;
//		if (m_timer <= 0.0f)
//		{
//			m_timer += 3.0f;
//			transform.Rotate(0.0f, 0.0f, 180.0f);
//		}
//	}

	void Update ()
	{

		timer -= Time.deltaTime;

		if (timer <= 0.0f) {
			//steady = false;
			//makeRandomSpeed ();
			newRot = this.transform.eulerAngles.x;
			float otherRot = newRot - 360;
			transform.Rotate(Vector3.left, 25.0f * Time.deltaTime);


			print ("old rot   " + rot);
			print ("other rot   " + otherRot);
			print("new rot   " + newRot);
				

			if (this.transform.eulerAngles.x == otherRot) {
				//steady == true;
				timer += 5.0f;

			}



		}
		
		//makeRandomSpeed ();
		//transform.Rotate(Vector3.left, speed * Time.deltaTime);
	}
}
