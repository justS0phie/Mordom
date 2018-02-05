using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleQPause : MonoBehaviour {

	// Use this for initialization
	public Q_Alpha_FileHandler handler;
	public Canvas canvas;
	public ControleDeFases controle;

	void Start(){
		canvas.gameObject.SetActive (false);
	}

	public void Restart(){
		handler.save ();
		Time.timeScale = 1;
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);    
	}

	public void GoToMenu () {
		handler.save ();
		Time.timeScale = 1;
		SceneManager.LoadScene ("MenuScene");
	}

	public void Resume(){
		canvas.gameObject.SetActive (false);
		Time.timeScale = 1;
		controle.onResume();
	}
}
