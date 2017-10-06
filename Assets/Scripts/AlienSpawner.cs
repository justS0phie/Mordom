using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AlienSpawner : MonoBehaviour {

    public GameObject alienA;
	public GameObject alienB;
    public GameObject planet;
	public Text scoreTxt;
	public Text livesTxt;

	float limx;
	float limy;
	float limxb;
	float limyb;

	int score = 0;
	int lives = 5;

	void Start () {

        float spawnRate = 0.5f;

        InvokeRepeating("CreateAlien", 0, spawnRate);

		scoreTxt.text = "Score: " + score;
		livesTxt.text = "Lives: " + lives;

    }
	
	void Update () {

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
				livesTxt.text = "Lives: " + lives;
			}
        }
    }

    void CreateAlien()
    {

        Vector2 planetPosition = new Vector2(planet.transform.position.x, planet.transform.position.y);
        
		int side = Random.Range(1, 5);
		int type = Random.Range(1, 11);

        Vector2 move, alienPos;

		Camera camera = Camera.main;
		CameraControl script = camera.GetComponent("CameraControl") as CameraControl;

		limx = 2*script.limx;
		limy = 2*script.limy;
		limxb = 2*script.limxb;
		limyb = 2*script.limyb;

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
			GameObject newAlien = Instantiate (alienB, alienPos, alienA.transform.rotation);
			newAlien.GetComponent<Rigidbody2D> ().velocity = move * speed;
		} else {
			GameObject newAlien = Instantiate(alienA, alienPos, alienB.transform.rotation);
			newAlien.GetComponent<Rigidbody2D>().velocity = move * speed;
		}
    }

	public void addScore(){
		score = score + 1;
		scoreTxt.text = "Score: " + score;
	}
}
