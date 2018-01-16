using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Q_Alpha_AlienA : MonoBehaviour {

	float distance;
	float proportion;
	float initD;
	Vector2 initSpeed;

	public GameObject planet;
	private Q_Alpha_Spawner spawner;

	void Start ()
	{
		float dx = planet.transform.position.x - transform.position.x;
		float dy = planet.transform.position.y - transform.position.y;
		initD = new Vector2(dx, dy).magnitude;
		initSpeed = GetComponent<Rigidbody2D>().velocity;

		if (GameObject.FindGameObjectWithTag ("Respawn"))
			spawner = GameObject.FindGameObjectWithTag ("Respawn").gameObject.GetComponent<Q_Alpha_Spawner> ();
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.tag == "Tool") {
			spawner.addScore ();
			Destroy (this.gameObject);
			if (coll.gameObject.name=="missil")
				Destroy (coll.transform.parent.gameObject);
		}
	}
}