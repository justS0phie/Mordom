using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Q_Alpha_Spawner : MonoBehaviour {

	public GameObject[] alien;
	public GameObject planet;
	public Text scoreTxt;
	public Text livesTxt;

	public ControleDeFases control;

	float limx;
	float limy;
	float limxb;
	float limyb;

	int score = 0;
	int lives = 10;
	public int spawnNumber = 0;
	public float spawnRate = 1.0f;
	public float timer = 0.0f;

	void Start () {

		scoreTxt.text = "Pontos: " + score;
		livesTxt.text = "HP: " + lives;

	}

	void Update () {

		timer = timer + Time.deltaTime;

		if (timer > spawnRate) {
			timer = timer - spawnRate;
			spawnRate = spawnRate - 0.01f;
			CreateAlien ();
		}

		GameObject[] alienList = GameObject.FindGameObjectsWithTag("Alien");

		foreach (GameObject alien in alienList)
		{
			Vector2 alienPos = new Vector2(alien.transform.position.x, alien.transform.position.y);

			Camera camera = Camera.main;
			CameraControl script = camera.GetComponent("CameraControl") as CameraControl;

			limx = 2*script.limx - 2.5f;
			limy = 2*script.limy - 2.5f;
			limxb = 2*script.limxb + 2.5f;
			limyb = 2*script.limyb + 2.5f;

			if (alienPos.x > limxb || alienPos.x < limx || alienPos.y > limyb || alienPos.y < limy){
				Destroy(alien);
                lives = lives - 1;
                if (lives <= 0)
                {
                    SceneManager.LoadScene("GameOver");
                }
                livesTxt.text = "HP: " + lives;
            }
		}
	}

	void CreateAlien()
	{
		
		Vector2 planetPosition = new Vector2(planet.transform.position.x, planet.transform.position.y);
		int qnt = alien.Length;
		int type = Random.Range(0, (qnt));

		Vector2 move, alienPos;

		Camera camera = Camera.main;

		float angle = Random.Range (0f, 2*Mathf.PI);

		while (AngleIsInvalid(planetPosition, angle))
			angle = Random.Range (0f, 2*Mathf.PI);

		alienPos = new Vector2 (planetPosition.x, planetPosition.y);

		alienPos = alienPos + 2*(new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)));

		float dx = alienPos.x - planetPosition.x;
		float dy = alienPos.y - planetPosition.y;

		move = new Vector2(dx, dy);
		move = move.normalized;

		if (control.fase == FaseDeJogo.Jogo){
				GameObject newAlien = Instantiate (alien[type], alienPos, alien[0].transform.rotation);
				newAlien.SetActive (true);
				newAlien.GetComponent<Rigidbody2D> ().velocity = move * 5;
			
			spawnNumber++;
		}
	}

	public void addScore(){
		score = score + 1;
		scoreTxt.text = "Pontos: " + score;
	}

	private bool AngleIsInvalid(Vector2 position, float angle){

		Camera camera = Camera.main;
		CameraControl script = camera.GetComponent("CameraControl") as CameraControl;

		limx = 2*script.limx;
		limy = 2*script.limy;
		limxb = 2*script.limxb;
		limyb = 2*script.limyb;

		float marginX = (limxb - limx)/4;
		float marginY = (limyb - limy)/4;

		float quarter = Mathf.PI / 2;

		if (position.y - marginY < limy && angle >= quarter && angle < 3*quarter)
			return true;
		if (position.x + marginX > limxb && angle >= 0 && angle < 2*quarter)
			return true;
		if (position.y + marginY > limyb && (angle <= quarter || angle > 3*quarter))
			return true;
		if (position.x - marginX < limx && angle >= 2*quarter)
			return true;
		return false;

	}
}
