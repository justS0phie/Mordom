using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public float fireRate = 0;
    public float Damage = 10;
    //public LayerMask WhatToHit;
    public float distanceShoot = 90;
	public GameObject BulletTrailPrefab;

    float timeToFire = 0;
    Transform firePoint;

	// Use this for initialization
	void Start () {
        firePoint = transform.Find ("FirePoint");
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (fireRate == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shooting();
            }
        } else
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
		GameObject newBullet = Instantiate(BulletTrailPrefab, firePoint.position, firePoint.rotation);
		newBullet.SetActive (true);
    }
}
