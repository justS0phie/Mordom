using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MenuController : MonoBehaviour {
	public Canvas MainMenu, LevelSelection, OptionsMenu;
	public GameObject Objects;

	void Start(){
		PlayerPrefs.SetFloat("RedColor", 255);
		PlayerPrefs.SetFloat("GreenColor", 255);
		PlayerPrefs.SetFloat("BlueColor", 255);
	}

	void Update(){

	}

	public void displayMenu(){//disable other canvas//
		MainMenu.gameObject.SetActive (true);
		LevelSelection.gameObject.SetActive (false);
		OptionsMenu.gameObject.SetActive (false);
		Objects.SetActive (false);
	}

	public void displayOptions(){
		MainMenu.gameObject.SetActive (false);
		LevelSelection.gameObject.SetActive (false);
		OptionsMenu.gameObject.SetActive (true);
		Objects.SetActive (true);
	}

	public void displaySelection(){
		MainMenu.gameObject.SetActive (false);
		LevelSelection.gameObject.SetActive (true);
		OptionsMenu.gameObject.SetActive (false);
		Objects.SetActive (false);
	}

	public void updateRedPref(){
		float value = OptionsMenu.GetComponent<Transform> ().GetChild (1).GetComponent<Slider> ().value;
		PlayerPrefs.SetFloat("RedColor", value);
	}

	public void updateGreenPref(){
		float value = OptionsMenu.GetComponent<Transform> ().GetChild (2).GetComponent<Slider> ().value;
		PlayerPrefs.SetFloat("GreenColor", value);
	}

	public void updateBluePref(){
		float value = OptionsMenu.GetComponent<Transform> ().GetChild (3).GetComponent<Slider> ().value;
		PlayerPrefs.SetFloat("BlueColor", value);
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
