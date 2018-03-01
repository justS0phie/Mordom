using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShoot : MonoBehaviour {

	public AudioSource source;
	public AudioClip shootSound;
	private float LowVol = 0.07f;
	private float HighVol = 0.1f;
	private float LowPitch = 0.75f;
	private float HighPitch = 1.5f;
	public GameObject LaserBeam;
	bool charging = false;
	float chargeBegin;
	float chargeTimer;
	Vector3 normalized;

	Transform firePoint;

	// Use this for initialization
	void Start () {
		firePoint = transform.Find ("LaserFirePoint");
	}

	// Update is called once per frame
	void LateUpdate () {
		if (Input.GetButtonDown("Fire1") && !charging)
		{
			chargeBegin = Time.time;
			charging = true;
		}
		float now = Time.time;
		chargeTimer = now - chargeBegin;
		if (chargeTimer > 0.3f && charging) 
		{
			Shooting();
			charging = false;
		}

		if (charging) {
			normalized = new Vector3 (154f-154f*chargeTimer, 255f*chargeTimer, 137f+118f*chargeTimer).normalized;
		} else {
			normalized = new Vector3 (154f, 0f, 137f).normalized;
		}
		this.gameObject.GetComponent<SpriteRenderer> ().color = new Color (normalized.x, normalized.y, normalized.z);
	}

	void Shooting ()
	{
		source.pitch = Random.Range (LowPitch, HighPitch);
		float vol = Random.Range (LowVol, HighVol);
		source.PlayOneShot (shootSound, vol);
		Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
		GameObject newBullet = Instantiate(LaserBeam, firePointPosition, firePoint.rotation);
		newBullet.SetActive (true);
	}
}
