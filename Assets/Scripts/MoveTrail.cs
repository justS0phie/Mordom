using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrail : MonoBehaviour {

    public int moveSpeed =30;

    // Update is called once per frame
    void Update () {
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);

		if (this.transform.position.x < -50 || this.transform.position.x > 50)
			Destroy (this.gameObject);
		if (this.transform.position.y < -28 || this.transform.position.y > 28)
			Destroy (this.gameObject);
	}
}
