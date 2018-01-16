using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Q_Alpha_AlienB : MonoBehaviour {

	float distance;
	float proportion;
	float initD;
	Vector2 initSpeed;
	int phase;
	int side;
	float Timer;

	public GameObject planet;
	private Q_Alpha_Spawner parent;

	void Start ()
	{
		float dx = planet.transform.position.x - transform.position.x;
		float dy = planet.transform.position.y - transform.position.y;
		initD = new Vector2(dx, dy).magnitude;
		initSpeed = GetComponent<Rigidbody2D>().velocity;
		phase = 1;
		Timer = 0.0f;

		if (GameObject.FindGameObjectWithTag ("Respawn"))
			parent = GameObject.FindGameObjectWithTag ("Respawn").gameObject.GetComponent<Q_Alpha_Spawner> ();
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
