using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour {

	private GameObject planet;

	void Start () {
		planet = GameObject.Find ("Planet");
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.tag == "Planet") {
			Destroy(this.gameObject);
			planet.GetComponent<GameStatus>().loseLife ();
		}
		if (coll.tag == "Tool") {
			this.atDestroy(this.name);
			Destroy (this.gameObject);
			if (coll.gameObject.name=="missil")
				Destroy (coll.transform.parent.gameObject);
		}
	}

	private void atDestroy(string alienName){
		
	}
}
