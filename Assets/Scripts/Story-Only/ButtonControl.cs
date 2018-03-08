using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour {

	public GameObject controller;
	public ControleDeFases script;
	public GameObject canvas;


	public void buttonStart(){
		
		if (controller == null) {
			controller = GameObject.FindGameObjectWithTag ("GameController");
			script = controller.GetComponent ("ControleDeFases") as ControleDeFases;
		}
		//gameObject.SetActive (false);
		script.MudarDeFase (FaseDeJogo.Jogo);
	}

	public void buttonRestart(){
		
		if (controller == null) {
			controller = GameObject.FindGameObjectWithTag ("GameController");
			script = controller.GetComponent ("ControleDeFases") as ControleDeFases;
		}

		canvas.gameObject.SetActive (true);
		script.onPause ();
		Time.timeScale = 0;
	}
}
