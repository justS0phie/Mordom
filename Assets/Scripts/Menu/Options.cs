using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour {
	
	public GameObject MenuScreen;

	void OnMouseDown(){
		string opt = this.name.Remove (this.name.Length - 3);

		if (opt == "Quit"){
			MenuScreen.SetActive (true);
			transform.parent.gameObject.SetActive (false);
		}
	}
}