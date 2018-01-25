using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Q_Alpha_AlienB : MonoBehaviour {

	float distance;
	float proportion;
	float initD;
	Vector2 initSpeed;
	Vector2 perpendicular;
	float initMagnitude;
	int phase;
	int side;
	float Timer;
	float TimerChange;

	public GameObject planet;
	private Q_Alpha_Spawner parent;

	void Start ()
	{
		float dx = planet.transform.position.x - transform.position.x;
		float dy = planet.transform.position.y - transform.position.y;
		initD = new Vector2(dx, dy).magnitude;
		initSpeed = GetComponent<Rigidbody2D>().velocity;
		initMagnitude = initSpeed.magnitude;
		initSpeed.Normalize();
		perpendicular.x = (GetComponent<Rigidbody2D>().velocity.y)*(-1);
		perpendicular.y = (GetComponent<Rigidbody2D>().velocity.x);
		perpendicular.Normalize();
		phase = 1;
		Timer = 0.0f;
		TimerChange = 0.25f;
		if (Random.Range (1, 3)==1)
			perpendicular *= -1;
		if (GameObject.FindGameObjectWithTag ("Respawn"))
			parent = GameObject.FindGameObjectWithTag ("Respawn").gameObject.GetComponent<Q_Alpha_Spawner> ();
	}

	void Update () {
		Timer = Timer + Time.deltaTime;
		if (Timer > TimerChange) {
			GetComponent<Rigidbody2D> ().velocity = (initSpeed+perpendicular) * initMagnitude;
			perpendicular = (perpendicular * (-1));
			Timer = 0.0f;
			TimerChange *= 2;
		}

	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.tag == "Tool") {
			parent.addScore ();
			Destroy (this.gameObject);
			if (coll.gameObject.name == "missil")
				Destroy (coll.transform.parent.gameObject);
		}
	}
}
