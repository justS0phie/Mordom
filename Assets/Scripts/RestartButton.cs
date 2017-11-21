using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour {

	GameObject alienspawn;
	ControleDeFases script;
	public FileHandler handler;
	public GameObject control;

	void Start(){
		control.SetActive (false);
	}

	void OnMouseDown(){
		handler.save ();
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
		control.SetActive (true);
	}

}
