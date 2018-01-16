using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {

    private GameObject origin;

    // Use this for initialization
    void Start () {
        origin = GameObject.Find("OriginInfo");
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            string originScene = origin.GetComponent<OriginInfoHandler>().originScene;
            SceneManager.LoadScene(originScene);
        }
    }
}
