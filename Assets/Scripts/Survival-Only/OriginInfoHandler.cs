using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OriginInfoHandler : MonoBehaviour {

    public string originScene;
	public string scoreText;

    private static GameObject instanceRef;

    void Awake()
    {
        if (instanceRef == null)
        {
            instanceRef = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        originScene = SceneManager.GetActiveScene().name;
    }

	void Update(){
		GameObject textParent = GameObject.Find("ScoreText");

		if (textParent) {
			scoreText = "";

			string score = GameObject.Find ("Text - Score").GetComponent<Text> ().text;
			string time = GameObject.Find ("Text - Time").GetComponent<Text> ().text;

			scoreText = scoreText + time + "   " + score;
		}
	}
}

