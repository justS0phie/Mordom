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

	void Start ()
	{
		planet = GameObject.Find ("Planet");
		float dx = planet.transform.position.x - transform.position.x;
		float dy = planet.transform.position.y - transform.position.y;
		initD = new Vector2(dx, dy).magnitude;
		initSpeed = GetComponent<Rigidbody2D>().velocity;
	}

	// Update is called once per frame
	void Update () {
		float dx = planet.transform.position.x - transform.position.x;
		float dy = planet.transform.position.y - transform.position.y;

		distance = new Vector2(dx, dy).magnitude;
		proportion = (distance / initD) * 3;
		GetComponent<Rigidbody2D>().velocity = initSpeed*proportion ;
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
			this.atDestroy(this.name);
			Destroy (this.gameObject);
		}
	}

	private void atDestroy(string alienName){

	}
}
