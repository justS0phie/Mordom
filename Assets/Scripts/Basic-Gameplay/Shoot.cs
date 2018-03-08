using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	public AudioSource source;
	public AudioClip shootSound;
	private float LowVol = 0.07f;
	private float HighVol = 0.1f;
	private float LowPitch = 0.75f;
	private float HighPitch = 1.25f;
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
		source.pitch = Random.Range (LowPitch, HighPitch);
		float vol = Random.Range (LowVol, HighVol);
		source.PlayOneShot (shootSound, vol);
		GameObject newBullet = Instantiate(BulletTrailPrefab, firePoint.position, firePoint.rotation);
		newBullet.SetActive (true);

    }
}
