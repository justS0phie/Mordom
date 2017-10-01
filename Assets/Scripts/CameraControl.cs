using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	private Camera cam;

	void Start()
	{
		cam = Camera.main;
	}

	void Update()
	{
		if (Input.GetKey("space"))
		{
			// choose the margin randomly
			float margin = Random.Range(0.0f, 0.3f);
			// setup the rectangle
			cam.rect = new Rect(margin, 0.0f, 1.0f - margin * 2.0f, 1.0f);
		}
	}
}
