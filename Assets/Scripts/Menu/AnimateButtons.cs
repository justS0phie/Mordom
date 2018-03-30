using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateButtons : MonoBehaviour {
	private bool scale;
	// Use this for initialization
	void Start () {
		scale = true;
	}
	
	// Update is called once per frame
	void Update () {
		//rotating the buttons//
		this.GetComponent<RectTransform> ().Rotate (0, 0, 1.25f);
		//scaling the buttons//
		if (scale && this.GetComponent<RectTransform> ().localScale.x < 1.6f) {
			this.GetComponent<RectTransform> ().localScale = this.GetComponent<RectTransform> ().localScale * 1.0025f;
		} 
		else if (scale && this.GetComponent<RectTransform> ().localScale.x >= 1.6f) {
			scale = false;
		}
		else if (!scale && this.GetComponent<RectTransform> ().localScale.x >= 1.4f) {
			this.GetComponent<RectTransform> ().localScale =this.GetComponent<RectTransform> ().localScale * 0.9975f;
		}
		else {
			scale = true;
		}
	}
}
