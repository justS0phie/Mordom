using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunShoot : MonoBehaviour {

	public GameObject HitArea;
	bool reloading = false;
	float chargeBegin;
	float chargeTimer;
	Vector3 normalized;

	public float firerate;

	Transform firePoint;

	// Use this for initialization
	void Start () {
		firePoint = transform.Find ("ShotgunFirePoint");
	}

	// Update is called once per frame
	void LateUpdate () {
		if (Input.GetButtonDown("Fire1") && !reloading)
		{
			chargeBegin = Time.time;
			reloading = true;
			Shooting ();
		}
		float now = Time.time;
		chargeTimer = now - chargeBegin;
		if (chargeTimer > firerate && reloading) 
		{
			reloading = false;
		}

		if (reloading) {
			normalized = new Vector3 (255f*chargeTimer, 126f*chargeTimer, 255f-255f*chargeTimer).normalized;
		} else {
			normalized = new Vector3 (255f, 126f, 0f).normalized;
		}
		this.gameObject.GetComponent<SpriteRenderer> ().color = new Color (normalized.x, normalized.y, normalized.z);
	}

	void Shooting ()
	{
		Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
		GameObject newBullet = Instantiate(HitArea, firePointPosition, firePoint.rotation);
		newBullet.SetActive (true);
		newBullet.transform.position -= newBullet.transform.up*2;
	}
}

