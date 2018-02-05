using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Q_Alpha_AlienA : MonoBehaviour {

	float distance;
	float proportion;

	public GameObject planet;
	private Q_Alpha_Spawner spawner;

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.tag == "Tool") {
			GameObject.FindGameObjectWithTag("Respawn").GetComponent<Q_Alpha_Spawner> ().addScore ();
			Destroy (this.gameObject);
			if (coll.gameObject.name=="missil")
				Destroy (coll.transform.parent.gameObject);
		}
	}
}