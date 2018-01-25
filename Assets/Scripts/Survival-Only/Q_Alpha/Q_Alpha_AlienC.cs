using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Q_Alpha_AlienC : MonoBehaviour {

	float distance;
	float proportion;
	float initD;
	Vector2 initSpeed;

	public GameObject planet;
	public GameObject alien;
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
			if (coll.gameObject.name=="missil")
				Destroy (coll.transform.parent.gameObject);
			GameObject newEnemy = Instantiate (alien, this.GetComponent<Rigidbody2D>().position, this.transform.rotation);
			GameObject newEnemy2 = Instantiate (alien, this.GetComponent<Rigidbody2D>().position, this.transform.rotation);
			newEnemy.SetActive (true);
			newEnemy.GetComponent<Rigidbody2D> ().velocity = new Vector2 ((-initSpeed.y+initSpeed.x)/2, (initSpeed.x+initSpeed.y)/2);

			newEnemy2.SetActive (true);
			newEnemy2.GetComponent<Rigidbody2D> ().velocity = new Vector2 ((initSpeed.y+initSpeed.x)/2, (-initSpeed.x+initSpeed.y)/2);
			Destroy (this.gameObject);
		}
	}
}
