using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour {

	void OnMouseDown() {
		
		GameObject controller = GameObject.FindGameObjectWithTag ("GameController");
		ControleDeFases script = controller.GetComponent ("ControleDeFases") as ControleDeFases;
		gameObject.SetActive (false);
		script.MudarDeFase (FaseDeJogo.Jogo);
	}
}
