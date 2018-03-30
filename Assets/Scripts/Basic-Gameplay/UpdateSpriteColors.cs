using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSpriteColors : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float red = PlayerPrefs.GetFloat("RedColor");
		float green = PlayerPrefs.GetFloat("GreenColor");
		float blue = PlayerPrefs.GetFloat("BlueColor");
		this.GetComponent<SpriteRenderer> ().color = new Color (red/255, green/255, blue/255, 255);
	}
}
