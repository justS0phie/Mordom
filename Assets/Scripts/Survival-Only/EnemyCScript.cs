using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCScript : MonoBehaviour {

	float distance;
	float proportion;
	float initD;
	Vector2 initSpeed;

	public GameObject planet;
	public GameObject alien;

	void Start(){
		initSpeed = GetComponent<Rigidbody2D>().velocity;
	}

	void Update(){
		float dx = planet.transform.position.x - transform.position.x;
		float dy = planet.transform.position.y - transform.position.y;

		Vector2 move = new Vector2(dx, dy).normalized;
		GetComponent<Rigidbody2D> ().velocity = move * 2.5f;
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.tag == "Planet") {
			Destroy(this.gameObject);
			GameObject.Find("Alien").GetComponent<AlienSpawner>().loseLife ();
			GameObject.Find("Alien").GetComponent<AlienSpawner>().loseLife ();
		}
		else if (coll.tag == "Tool") {	
			if (coll.gameObject.name == "missil") {
				Destroy (coll.transform.parent.gameObject);
			}
			GameObject.FindGameObjectWithTag("Respawn").GetComponent<AlienSpawner> ().addScore ();
			GameObject newEnemy = Instantiate (alien, this.GetComponent<Rigidbody2D>().position, this.transform.rotation);
			GameObject newEnemy2 = Instantiate (alien, this.GetComponent<Rigidbody2D>().position, this.transform.rotation);
			newEnemy.SetActive (true);
			newEnemy.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-initSpeed.y, initSpeed.x);

			newEnemy2.SetActive (true);
			newEnemy2.GetComponent<Rigidbody2D> ().velocity = new Vector2 (initSpeed.y, -initSpeed.x);
			Destroy (this.gameObject);
		}
	}
}
