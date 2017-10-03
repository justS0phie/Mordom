using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedControl : MonoBehaviour {

    float distance;
    float proportion;

    public GameObject planet;

    void Start ()
    {
        float dx = planet.transform.position.x - transform.position.x;
        float dy = planet.transform.position.y - transform.position.y;
        float initD = new Vector2(dx, dy);
        float initSpeed = GetComponent<Rigidbody2D>().velocity.magnitude;
    }
	
	// Update is called once per frame
	void Update () {
        float dx = planet.transform.position.x - transform.position.x;
        float dy = planet.transform.position.y - transform.position.y;

        distance = new Vector2(dx, dy).magnitude;
        proportion = initD / distance;
        GetComponent<Rigidbody2D>().velocity = initSpeed * proportion;
    }
}
