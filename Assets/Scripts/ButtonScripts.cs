using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScripts : MonoBehaviour {

	float camSize;
	float btnSize;

	private Vector3 scale;
	Camera main;

	// Use this for initialization
	void Start () {
		camSize = Camera.main.orthographicSize;
		btnSize = camSize;
		scale = transform.localScale;
	}
	
	// Update is called once per frame
	void LateUpdate () {

		camSize = Camera.main.orthographicSize;
		transform.localScale = scale * camSize / btnSize;
		
	}
}

