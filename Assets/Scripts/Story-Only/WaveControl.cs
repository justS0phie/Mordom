using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveControl : MonoBehaviour {

	private int ENEMY_TYPES = 4;

	public int wave;
	public float waveTimer;
	private float initTimer;
	private int[][] waveData;
	private GameObject[] enemies;
	private PhaseControl control;

	void Start () {
		wave = 1;
		control = GetComponent<PhaseControl> ();
		initTimer = 0;
		waveTimer = 0;
		waveData = new int[ENEMY_TYPES][];
		waveData [0] = new int[] { 3, 0, 0, 1, 2, 2, 3, 3 };
		waveData [1] = new int[] { 3, 2, 3, 3, 4, 4, 5, 5 };
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
		spawn.turn = 0;
		control.ChangePhase(GamePhase.Prep);
	}

	public int[] getEnemyData(int turn){
		int[] enemies = new int[ENEMY_TYPES];
		for (int i=0; i<ENEMY_TYPES; i++)
			enemies[i] = waveData[wave-1][ENEMY_TYPES*turn + i];
		return enemies;
	}

	public int getWaveAmount(){
		int total = 0;
		for(var i = 0; i<waveData[wave-1].Length; i++)
			total += waveData[wave-1][i];
		return total;
	}
}
