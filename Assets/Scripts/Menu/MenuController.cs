using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour {
	public Canvas MainMenu, LevelSelection, OptionsMenu;

	public void displayMenu(){//disable other canvas//
		MainMenu.gameObject.SetActive (true);
		LevelSelection.gameObject.SetActive (false);
		OptionsMenu.gameObject.SetActive (false);
	}

	public void displayOptions(){
		MainMenu.gameObject.SetActive (false);
		LevelSelection.gameObject.SetActive (false);
		OptionsMenu.gameObject.SetActive (true);
	}

	public void displaySelection(){
		MainMenu.gameObject.SetActive (false);
		LevelSelection.gameObject.SetActive (true);
		OptionsMenu.gameObject.SetActive (false);
	}

	public void loadSurvival(){
		SceneManager.LoadScene ("Scenes/Scene1");
	}

	public void loadStory(){
		SceneManager.LoadScene ("Scenes/Q_Alpha");
	}

	public void quit(){
		Application.Quit();
	}

}
