using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBtn : MonoBehaviour {

	public GameObject OptionsScreen;
	public GameObject LevelSelect;
    public bool pressed;
    public bool idle_btn =true;
    void OnMouseDown(){
        pressed = true;
        idle_btn = false;
		string opt = this.name.Remove (this.name.Length - 3);

        GameObject originInfo = GameObject.Find("OriginInfo");

        if (originInfo)
            Destroy(originInfo.gameObject);

		if (opt == "Quit")
			Application.Quit();  
		if (opt == "Options") {
			OptionsScreen.SetActive (true);
			transform.parent.gameObject.SetActive (false);
		}
		if (opt == "Story") {
			//LevelSelect.SetActive (true);
			//transform.parent.gameObject.SetActive (false);
			SceneManager.LoadScene ("Scenes/Q_Alpha");
		}
		if (opt == "Survival")
			SceneManager.LoadScene ("Scenes/Scene1");
	}
}
