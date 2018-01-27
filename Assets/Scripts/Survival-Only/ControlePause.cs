using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlePause : MonoBehaviour {

	public FileHandler handler;
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
	// Update is called once per frame
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