using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTimer : MonoBehaviour {

	float Timer;
	public float LaserDuration = 0.5f;
	float initTime;
	Color temp;

	void Start () {
		initTime = Time.time;
		Timer = initTime;
	}
	
	// Update is called once per frame
	void Update () {
		Timer = Timer + Time.deltaTime;
		if (Timer - initTime > LaserDuration)
			Destroy (this.gameObject);
		temp = this.GetComponent<SpriteRenderer> ().color;
		temp.a = 1-((Timer - initTime)/LaserDuration);
		this.GetComponent<SpriteRenderer> ().color = temp;
		
	}
}
