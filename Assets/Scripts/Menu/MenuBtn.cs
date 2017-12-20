using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBtn : MonoBehaviour {

	void OnMouseDown(){
		string opt = this.name.Remove (this.name.Length - 3);

		if (opt == "Quit")
			Application.Quit();  
		if (opt == "Options")
			//Options aqui
			print ("Options");
		if (opt == "Story")
			//Seleção de fase
			print ("Story");
		if (opt == "Survival")
			SceneManager.LoadScene ("Scenes/Scene1");
	}
}
