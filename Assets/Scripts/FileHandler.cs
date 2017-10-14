using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;

public class FileHandler : MonoBehaviour {

	string score;
	Vector2 position;
	float size;
	float time;
	string hit;
	int spawn;
	bool startCount;

	float initSize;
	int initSpawn;

	public AlienSpawner alienSpawn;
	public ControleDeFases control;
	public GameObject planet;

	Camera mainCamera;
	Vector3 planetPosition;

	// Use this for initialization
	void Start () {
		mainCamera = Camera.main;
		planetPosition = planet.transform.position;
		initSize = mainCamera.orthographicSize;
		time = 0;
		startCount = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (control.activateCannon)
			startCount = true;
		if (startCount){
			time = time + Time.deltaTime;
			planetPosition = planet.transform.position;
			score = alienSpawn.scoreTxt.text;
			hit = alienSpawn.livesTxt.text;
			size = mainCamera.orthographicSize / initSize;
			position = new Vector2 (planetPosition.x - mainCamera.transform.position.x, planetPosition.y - mainCamera.transform.position.y);
			spawn = alienSpawn.spawnNumber - initSpawn;
		} else {
			initSpawn = alienSpawn.spawnNumber;
		}
	}

	public void save(){
		string path = "Assets/Statistics.txt";
		using (StreamWriter outfile = new StreamWriter(path))
		{
			outfile.WriteLine ("Estatísticas de Jogo:");
			outfile.WriteLine ("");
			outfile.WriteLine ("Tempo de jogo: " + time.ToString ());
			outfile.WriteLine ("Aliens mortos: " + score.ToString ());
			outfile.WriteLine ("Vidas Perdidas: " + hit.ToString ());
			outfile.WriteLine ("Total de Aliens: " + spawn.ToString ());
			outfile.WriteLine ("Tamanho do planeta: " + (1/size).ToString () + "x");
			outfile.WriteLine ("Posição do planeta: (" + position.x.ToString () + "," + position.y.ToString () + ")");
		}
	}
}
