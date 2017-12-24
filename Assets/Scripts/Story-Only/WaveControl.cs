using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveControl : MonoBehaviour {

	public int wave;
	public float waveTimer;
	private float initTimer;
	private GameObject[] enemies;
	private PhaseControl control;

	void Start () {
		wave = 1;
		control = GetComponent<PhaseControl> ();
		initTimer = 0;
		waveTimer = 0;
	}
	
	void Update () {
		if (control.phase == GamePhase.Game) {
			waveTimer = Time.time - initTimer;
			enemies = GameObject.FindGameObjectsWithTag ("Alien");
			if (waveTimer > 3 && enemies.Length==0)
			{
				wave++;
				control.ChangePhase(GamePhase.Prep);
			}
		}
	}

	public void StartWave() {
		initTimer = Time.time;
	}
}
