using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScripts : MonoBehaviour {

	float camSize;
	float btnSize;

	private Vector3 scale;
	private Vector3 pos;
	Camera main;

	// Use this for initialization
	void Start () {
		camSize = Camera.main.orthographicSize;
		btnSize = camSize;
		scale = transform.localScale;
		pos = Camera.main.WorldToViewportPoint (transform.position);
	}
	
	// Update is called once per frame
	void LateUpdate () {

		camSize = Camera.main.orthographicSize;
		transform.localScale = scale * camSize / btnSize;
		
	}
}

