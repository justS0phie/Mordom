using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShoot : MonoBehaviour {

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
		if (chargeTimer > 1f && charging) 
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
		Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
		Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
		GameObject newBullet = Instantiate(LaserBeam, firePointPosition, firePoint.rotation);
		newBullet.SetActive (true);
		Debug.DrawLine(firePointPosition, (mousePosition - firePointPosition) * 120, Color.yellow);
	}
}
