using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {

    private GameObject origin;

    // Use this for initialization
    void Start () {
        origin = GameObject.Find("OriginInfo");
		GameObject.Find ("Score Text").GetComponent<Text> ().text = origin.GetComponent<OriginInfoHandler> ().scoreText;
    }

	public void Restart() {
		
		string originScene;

		if (origin)
			originScene = origin.GetComponent<OriginInfoHandler>().originScene;
		else
			originScene = "MenuScene";

		SceneManager.LoadScene(originScene); 
	}

	public void GoToMenu () {
		SceneManager.LoadScene ("MenuScene");
	}
}
