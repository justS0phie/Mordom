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
		if (control.phase == GamePhase.Game)
			waveTimer = Time.time - initTimer;
	}

	public void StartWave() {
		initTimer = Time.time;
	}

	public void endWave() {
		wave++;
		EnemySpawn spawn = GameObject.FindGameObjectWithTag ("Respawn").GetComponent<EnemySpawn>();
		spawn.timer = 0;
		spawn.spawnNumber = 0;
		control.ChangePhase(GamePhase.Prep);
	}

	public int[] getEnemyData(int turn){
		return new int[] {0,5};
	}

	public int getWaveAmount(){
		return 20;
	}
}
