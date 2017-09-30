using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public float fireRate = 0;
    public float Damage = 10;
    public LayerMask notToHit;

    float timeToFire = 0;
    Transform firePoint;

	// Use this for initialization
	void Start () {
        firePoint = transform.Find ("FirePoint");
        if (firePoint == null)
        {
            Debug.LogError("No firePoint? WHAT!!!??");
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (fireRate == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shooting();
            }
        }else
        {
            if (Input.GetButton ("Fire1") && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shooting();
            }
        }
		
	}
    void Shooting ()
    {
        Debug.Log("Test");
    }
}
