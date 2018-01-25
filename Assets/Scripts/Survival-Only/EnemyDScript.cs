using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDScript : MonoBehaviour {

	float distance;
	float proportion;
	float initD;
	float Timer;
	Vector2 speed;
	Vector2 newSpeed;
	public GameObject planet;

	void Start ()
	{
		float dx = planet.transform.position.x - transform.position.x;
		float dy = planet.transform.position.y - transform.position.y;
		initD = new Vector2(dx, dy).magnitude;
		speed = GetComponent<Rigidbody2D>().velocity;
		Timer = 0.0f;
	}

	// Update is called once per frame
	void Update () {
		Timer = Timer + Time.deltaTime;
		float dx = planet.transform.position.x - transform.position.x;
		float dy = planet.transform.position.y - transform.position.y;
		newSpeed = new Vector2 (dx, dy);
		distance = newSpeed.magnitude;
		proportion = (distance / initD) * 3;
		if (Timer > 0.25f) {
			speed = GetComponent<Rigidbody2D> ().velocity;
			speed.Normalize ();
			newSpeed.Normalize ();
			GetComponent<Rigidbody2D> ().velocity = (speed + newSpeed) * proportion;
		} else {
			GetComponent<Rigidbody2D> ().velocity = speed * proportion;
		}

	}
}
