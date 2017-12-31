using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBtns : MonoBehaviour {

	public Save_Data handler;

	void OnMouseDown() {

		if (name == "StartButton") {
			GameObject controller = GameObject.FindGameObjectWithTag ("GameController");
			controller.GetComponent<PhaseControl>().ChangePhase(GamePhase.Game);
			controller.GetComponent<WaveControl> ().StartWave ();
		}

		if (name == "RestartButton") {
			handler.save ();
			SceneManager.LoadScene (SceneManager.GetActiveScene().name);    
		}
	}
}
