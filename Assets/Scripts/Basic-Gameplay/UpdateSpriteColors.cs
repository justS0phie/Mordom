using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSpriteColors : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float hue = PlayerPrefs.GetFloat("Hue");
		float saturation = PlayerPrefs.GetFloat("Saturation");
		float value = PlayerPrefs.GetFloat("Value");
		this.GetComponent<SpriteRenderer> ().color = Color.HSVToRGB (hue, saturation, value);
	}
}
