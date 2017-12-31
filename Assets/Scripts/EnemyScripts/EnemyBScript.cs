using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBScript : MonoBehaviour {

	float distance;
	float proportion;
	float initD;
	Vector2 initSpeed;
	int phase;
	int side;
	float Timer;

	public GameObject planet;

	void Start ()
	{
		float dx = planet.transform.position.x - transform.position.x;
		float dy = planet.transform.position.y - transform.position.y;
		initD = new Vector2(dx, dy).magnitude;
		initSpeed = GetComponent<Rigidbody2D>().velocity;
		phase = 1;
		Timer = 0.0f;
	}

	// Update is called once per frame
	void Update () {
		if (phase == 1) {
			float dx = planet.transform.position.x - transform.position.x;
			float dy = planet.transform.position.y - transform.position.y;

			distance = new Vector2 (dx, dy).magnitude;
			if (distance < 3) {
				phase++;
				side = Random.Range (1, 3);
				return;
			}
			proportion = ((distance-1) / initD) * 3;
			GetComponent<Rigidbody2D> ().velocity = initSpeed * proportion;
		} else if (phase == 2) {
			float dx = planet.transform.position.x - transform.position.x;
			float dy = planet.transform.position.y - transform.position.y;

			if (side == 1) {
				GetComponent<Rigidbody2D> ().velocity = new Vector2(-dy,dx);
			} else {
				GetComponent<Rigidbody2D> ().velocity = new Vector2(dy,-dx);
			}

			Timer = Timer + Time.deltaTime;
			if (Timer > 5.0f) {
				initSpeed = initSpeed.magnitude * (new Vector2 (dx, dy).normalized);
				phase = 3;
			}

		} else if (phase == 3) {
			float dx = planet.transform.position.x - transform.position.x;
			float dy = planet.transform.position.y - transform.position.y;

			distance = new Vector2 (dx, dy).magnitude;
			proportion = (distance / initD) * 3;
			GetComponent<Rigidbody2D> ().velocity = initSpeed * proportion;
		}
	}
		
}
