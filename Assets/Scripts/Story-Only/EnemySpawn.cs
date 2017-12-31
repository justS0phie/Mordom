using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

	public GameObject[] Enemy;
	public GameObject planet;
	private WaveControl waveControl;

	float limx;
	float limy;
	float limxb;
	float limyb;

	public float timer;

	public int spawnNumber = 0;
	public float spawnRate = 0.5f;

	void Start () {
		waveControl = GameObject.Find("Controladores").GetComponent<WaveControl>();
	}


	void Update() {
		timer = waveControl.waveTimer - (spawnNumber * spawnRate);

		if (timer > spawnRate && waveControl.getWaveAmount() > spawnNumber) {
			int[] data = waveControl.getEnemyData (1);
			for (int i=0; i<data[1]; i++)
				CreateEnemy (data [0]);
		}

		if (waveControl.getWaveAmount () <= spawnNumber && timer > 5) {
			GameObject[] enemyList = GameObject.FindGameObjectsWithTag("Alien");
			if (enemyList.Length == 0)
				waveControl.endWave ();
		}
	}

	void CreateEnemy(int type)
	{

		Vector2 planetPosition = new Vector2(planet.transform.position.x, planet.transform.position.y);

		int side = Random.Range(1, 5);

		Vector2 move, enemyPos;

		Camera camera = Camera.main;
		CameraControl script = camera.GetComponent("CameraControl") as CameraControl;

		limx = 2*script.limx;
		limy = 2*script.limy;
		limxb = 2*script.limxb;
		limyb = 2*script.limyb;

		if (side == 1)
			enemyPos = new Vector2(limx-2.5f, Random.Range(limy-2.5f,limyb+2.5f));
		else if (side == 2)
			enemyPos = new Vector2(Random.Range(limx-2.5f,limxb+2.5f), limyb+2.5f);
		else if (side == 3)
			enemyPos = new Vector2(limxb+2.5f, Random.Range(limy-2.5f,limyb+2.5f));
		else
			enemyPos = new Vector2(Random.Range(limx-2.5f,limxb+2.5f), limy-2.5f);

		float dx = planetPosition.x - enemyPos.x;
		float dy = planetPosition.y - enemyPos.y;

		move = new Vector2(dx, dy);

		float speed = move.magnitude/4;

		if (move.magnitude < 5) {
			this.CreateEnemy (type);
			return;
		}
			
		move = move.normalized;
		
		GameObject newEnemy = Instantiate (Enemy[type], enemyPos, Enemy[type].transform.rotation);
		newEnemy.SetActive (true);
		newEnemy.GetComponent<Rigidbody2D> ().velocity = move * speed;

		spawnNumber++;
	}
}
