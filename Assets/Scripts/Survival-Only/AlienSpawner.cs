using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlienSpawner : MonoBehaviour {

    public GameObject alienA;
	public GameObject alienB;
	public GameObject alienC;
    public GameObject planet;
	public Text scoreTxt;
	public Text livesTxt;
    public GameObject LifeBar;

	float limx;
	float limy;
	float limxb;
	float limyb;

	int score = 0;
	float lives = 10;
    int max_hp = 10;
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

		if (lives <= 0)
		{
			SceneManager.LoadScene("GameOver");
		}

        GameObject[] alienList = GameObject.FindGameObjectsWithTag("Alien");

		foreach (GameObject alien in alienList)
        {
            Vector2 alienPos = new Vector2(alien.transform.position.x, alien.transform.position.y);
            Vector2 planetPosition = new Vector2(planet.transform.position.x, planet.transform.position.y);

            float dx = planetPosition.x - alienPos.x;
            float dy = planetPosition.y - alienPos.y;

            Vector2 move = new Vector2(dx, dy);

			if (move.magnitude < 2) {
				Destroy(alien);
				lives = lives - 1;
                livesTxt.text = "HP: " + lives;
                LifeBar.GetComponent<Image>().fillAmount = lives / max_hp;
			}
        }
    }

    void CreateAlien()
    {

		Camera camera = Camera.main;
		CameraControl script = camera.GetComponent("CameraControl") as CameraControl;

		Vector2 planetPosition = new Vector2(planet.transform.position.x, planet.transform.position.y);

		int side = Random.Range(1, 5);

		limx = 2*script.limx;
		limy = 2*script.limy;
		limxb = 2*script.limxb;
		limyb = 2*script.limyb;

		while (SideIsInvalid(planetPosition, side))
			side = Random.Range(1, 5);
		
		int type = Random.Range(1, 11);

        Vector2 move, alienPos;

        if (side == 1)
			alienPos = new Vector2(limx-2.5f, Random.Range(limy-2.5f,limyb+2.5f));
        else if (side == 2)
			alienPos = new Vector2(Random.Range(limx-2.5f,limxb+2.5f), limyb+2.5f);
        else if (side == 3)
			alienPos = new Vector2(limxb+2.5f, Random.Range(limy-2.5f,limyb+2.5f));
        else
			alienPos = new Vector2(Random.Range(limx-2.5f,limxb+2.5f), limy-2.5f);

        float dx = planetPosition.x - alienPos.x;
        float dy = planetPosition.y - alienPos.y;
        
        move = new Vector2(dx, dy);

        float speed = move.magnitude/4;

		if (move.magnitude < 5)
			return;

        move = move.normalized;

		if (type <= 2) {
			GameObject newAlien = Instantiate (alienB, alienPos, alienB.transform.rotation);
			newAlien.SetActive (true);
			newAlien.GetComponent<Rigidbody2D> ().velocity = move * speed;
		} else if (type <= 4) {
			GameObject newAlien = Instantiate(alienC, alienPos, alienC.transform.rotation);
			newAlien.SetActive (true);
			newAlien.GetComponent<Rigidbody2D>().velocity = move * speed;
		} else {
			GameObject newAlien = Instantiate(alienA, alienPos, alienB.transform.rotation);
			newAlien.SetActive (true);
			newAlien.GetComponent<Rigidbody2D>().velocity = move * speed;
		}

		spawnNumber++;
    }

	public void addScore(){
		score = score + 1;
		scoreTxt.text = "Pontos: " + score;
	}

	public void loseLife(){
		lives = lives - 1;
		livesTxt.text = "HP: " + lives;
        LifeBar.GetComponent<Image>().fillAmount = lives / max_hp;
    }

	private bool SideIsInvalid(Vector2 position, int side){
		
		float marginX = (limxb - limx)/4;
		float marginY = (limyb - limy)/4;

		if (position.x - marginX < limx && side == 1)
			return true;
		if (position.y + marginY < limy && side == 2)
			return true;
		if (position.x + marginX > limxb && side == 3)
			return true;
		if (position.y - marginY > limyb && side == 4)
			return true;
		return false;

	}
}
