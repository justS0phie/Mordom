using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedControl : MonoBehaviour {

    float distance;
    float speed;

    public GameObject planet;
	
	// Update is called once per frame
	void Update () {
        float dx = planet.transform.position.x - transform.position.x;
        float dy = planet.transform.position.y - transform.position.y;

        //distance = new Vector2(dx, dy).magnitude;
        //Vector2 actual = GetComponent<Rigidbody2D>().velocity;
        //speed = actual / distance;
        //GetComponent<Rigidbody2D>().velocity = actual * speed;
    }
}
