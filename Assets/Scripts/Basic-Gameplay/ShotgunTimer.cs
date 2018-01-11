using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunTimer : MonoBehaviour {

	float Timer;
	public float ShotDuration = 0.2f;
	float initTime;
	Color temp;

	void Start () {
		initTime = Time.time;
		Timer = initTime;
	}

	// Update is called once per frame
	void Update () {
		Timer = Timer + Time.deltaTime;
		if (Timer - initTime > ShotDuration)
			Destroy (this.gameObject);
		temp = this.GetComponent<SpriteRenderer> ().color;
		temp.a = 1-((Timer - initTime)/ShotDuration);
		this.GetComponent<SpriteRenderer> ().color = temp;
	}
}
