using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AlienSpawner : MonoBehaviour {

    public GameObject alien;
    public GameObject planet;
	public Text scoreTxt;

	int score = 100;

	// Use this for initialization
	void Start () {

        float spawnRate = 0.5f;

        InvokeRepeating("CreateAlien", 0, spawnRate);

		scoreTxt.text = "Score: " + score;

    }
	
	// Update is called once per frame
	void Update () {

        GameObject[] alienList = GameObject.FindGameObjectsWithTag("Alien");


        for (int i=0; i< alienList.Length; i++)
        {
            alien = alienList[i];

            Vector2 alienPos = new Vector2(alien.transform.position.x, alien.transform.position.y);
            Vector2 planetPosition = new Vector2(planet.transform.position.x, planet.transform.position.y);

            float dx = planetPosition.x - alienPos.x;
            float dy = planetPosition.y - alienPos.y;

            Vector2 move = new Vector2(dx, dy);

			if (move.magnitude < 2) {
				Destroy(alien);
				score = score - 1;
				scoreTxt.text = "Score: " + score;
			}
        }
    }

    void CreateAlien()
    {

        Vector2 planetPosition = new Vector2(planet.transform.position.x, planet.transform.position.y);
        int side = Random.Range(1, 5);
        Vector2 move, alienPos;
        if (side == 1)
            alienPos = new Vector2(-10.0f, Random.Range(-6.0f,6.0f));
        else if (side == 2)
            alienPos = new Vector2(Random.Range(-10.0f, 10.0f), 6.0f);
        else if (side == 3)
            alienPos = new Vector2(10.0f, Random.Range(-6.0f, 6.0f));
        else
            alienPos = new Vector2(Random.Range(-10.0f, 10.0f), -6.0f);

        float dx = planetPosition.x - alienPos.x;
        float dy = planetPosition.y - alienPos.y;
        
        move = new Vector2(dx, dy);

        float angle = Mathf.Atan(dx/dy); 

        move = move.normalized;

        GameObject alien1 = Instantiate(alien, alienPos, alien.transform.rotation);
        alien1.GetComponent<Rigidbody2D>().velocity = move * 3;

    }
}
