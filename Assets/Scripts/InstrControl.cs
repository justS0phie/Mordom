using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrControl : MonoBehaviour {

	ControleDeFases control;
	
	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
		if (FindObjectsOfType (GetType ()).Length > 1) {
			Destroy (gameObject);
			Destroy (GameObject.Find ("Instrucao").gameObject);
		}
	}

	void Update () {
		control = GameObject.Find ("Controladores").GetComponent<ControleDeFases>();
		if (control.fase == FaseDeJogo.Instructions) {
			control.prep = true;
			control.page = 2;
			control.MudarDeFase (FaseDeJogo.Preparacao);
		}
	}
}
