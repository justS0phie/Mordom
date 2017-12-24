using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour {

	public GameObject MenuScreen;

	void OnMouseDown(){
		string opt = this.name.Remove (this.name.Length - 3);

		if (opt == "Quit") {
			MenuScreen.SetActive (true);
			transform.parent.gameObject.SetActive (false);
		} else {
			SceneManager.LoadScene ("S-Level-" + opt [opt.Length-1]);
		}
	}
}
