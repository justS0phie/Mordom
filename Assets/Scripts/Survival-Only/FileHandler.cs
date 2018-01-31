using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using UnityEngine.UI;

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

	public Text timeText;

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
		timeText.text = "Tempo: " + ((int)time).ToString ();
	}

	public void save(){
		if (control.fase != FaseDeJogo.Jogo)
			return;
		string path = Application.persistentDataPath + "/Statistics.txt";
		if (!System.IO.File.Exists(path))
		{
			System.IO.FileStream file = null;
			file = new System.IO.FileStream(path, System.IO.FileMode.Create);
			file.Close();
		}
		string[] lines = System.IO.File.ReadAllLines(path);
		using (StreamWriter outfile = new StreamWriter(path))
		{
			outfile.WriteLine ("Estatísticas de Jogo:");
			foreach (string line in lines) {
				if (line == "Estatísticas de Jogo:")
					continue;
				outfile.WriteLine (line);
			}
			outfile.WriteLine ("");
			outfile.WriteLine ("Tempo de jogo: " + time.ToString ());
			outfile.WriteLine (score.ToString ());
			outfile.WriteLine (hit.ToString ());
			outfile.WriteLine ("Total de Aliens: " + spawn.ToString ());
			outfile.WriteLine ("Tamanho do planeta: " + (1/size).ToString () + "x");
			outfile.WriteLine ("Posição do planeta: (" + position.x.ToString () + "," + position.y.ToString () + ")");
			position = GameObject.Find ("Button1").transform.position;
			outfile.WriteLine ("Posição Button1: (" + position.x.ToString () + "," + position.y.ToString () + ")");
			position = GameObject.Find ("Button2").transform.position;
			outfile.WriteLine ("Posição Button2: (" + position.x.ToString () + "," + position.y.ToString () + ")");
		}
	}
}
