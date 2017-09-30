using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCannon : MonoBehaviour {

	// Use this for initialization
	/*void Start () {
		
	}*/
    public int rotationOffset = 90;

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0)) { 
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            difference.Normalize ();

            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler (0f, 0f, rotZ + rotationOffset);
        }
    }
}
