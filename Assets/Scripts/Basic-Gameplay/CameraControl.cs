using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	Camera cam;
	float orthoZoomSpeed;
	float x;
	float y;

	public float limx;
	public float limy;
	public float limxb;
	public float limyb;

	private bool isenabled;

	void Start()
	{
		cam = Camera.main;
		orthoZoomSpeed = cam.orthographicSize/200;
		x = 0;
		y = 0;

		isenabled = true;
	}

	void Update()
	{
		if(!isenabled) return;

		orthoZoomSpeed = cam.orthographicSize/200;

		limy = -cam.orthographicSize;
		limx = -(cam.orthographicSize * Screen.width / Screen.height);

        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            if ((deltaMagnitudeDiff < 0) && (cam.orthographicSize > 5))
            {
                cam.orthographicSize -= (2 * orthoZoomSpeed);
            }
            else if ((deltaMagnitudeDiff > 0) && (cam.orthographicSize < 10))
            {
                cam.orthographicSize += (2 * orthoZoomSpeed);
            }

        }

        if (Input.GetKey("down") && cam.orthographicSize < 10)
			cam.orthographicSize += orthoZoomSpeed;
		if (Input.GetKey("up") && cam.orthographicSize > 5)
			cam.orthographicSize -= orthoZoomSpeed;

		if (Input.GetKey("w"))
			y = y + 0.1f;
		if (Input.GetKey("s"))
			y = y - 0.1f;
		if (Input.GetKey("d"))
			x = x + 0.1f;
		if (Input.GetKey("a"))
			x = x - 0.1f;

		limxb = (-limx + x)/2;
		limyb = (-limy + y)/2;
		limx = (limx + x)/2;
		limy = (limy + y)/2;

		while (limx < -23) {
			x = x + 0.1f;
			limx = limx + 0.05f;
		}
		while (limy < -13) {
			y = y + 0.1f;
			limy = limy + 0.05f;
		}
		while (limxb > 23) {
			x = x - 0.1f;
			limxb = limxb - 0.05f;
		}
		while (limyb > 13) {
			y = y - 0.1f;
			limyb = limyb - 0.05f;
		}

		transform.position = new Vector3 (x, y, -30);
	}

	public void Enable() {
		isenabled = true;
	}

	public void Disable() {
		isenabled = false;
	}
}
