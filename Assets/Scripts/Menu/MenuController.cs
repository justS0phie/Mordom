using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MenuController : MonoBehaviour {
	public Canvas MainMenu, LevelSelection, OptionsMenu;
	public GameObject Objects;

	void Start(){
		PlayerPrefs.SetFloat("Hue", 1);
		PlayerPrefs.SetFloat("Saturation", 0);
		PlayerPrefs.SetFloat("Value", 1);
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

	public void updateHuePref(){
		float value = OptionsMenu.GetComponent<Transform> ().GetChild (1).GetComponent<Slider> ().value;
		PlayerPrefs.SetFloat("Hue", value);
	}

	public void updateSaturationPref(){
		float value = OptionsMenu.GetComponent<Transform> ().GetChild (2).GetComponent<Slider> ().value;
		PlayerPrefs.SetFloat("Saturation", value);
	}

	public void updateValuePref(){
		float value = OptionsMenu.GetComponent<Transform> ().GetChild (3).GetComponent<Slider> ().value;
		PlayerPrefs.SetFloat("Value", value);
	}

	public void loadSurvival(){
		SceneManager.LoadScene ("Scenes/Scene1");
	}

	public void loadStory(){
		SceneManager.LoadScene ("Scenes/Q_Alpha");
	}

	public void loadMenu(){
		SceneManager.LoadScene ("Scenes/MenuScene");
	}

	public void loadLastScene(){
        
		string scene = "";
		SceneManager.LoadScene (scene);
	}

	public void quit(){
		Application.Quit();
	}

}
