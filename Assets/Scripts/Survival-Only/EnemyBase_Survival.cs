using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase_Survival : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.tag == "Planet") {
			Destroy(this.gameObject);
			GameObject.Find("Alien").GetComponent<AlienSpawner>().loseLife ();
		}
		if (coll.tag == "Tool") {
			Destroy (this.gameObject);
			GameObject.FindGameObjectWithTag("Respawn").GetComponent<AlienSpawner> ().addScore ();
			if (coll.gameObject.name=="missil")
				Destroy (coll.transform.parent.gameObject);
		}
	}

}
