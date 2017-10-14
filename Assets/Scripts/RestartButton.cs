using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour {

	GameObject alienspawn;
	ControleDeFases script;
	public FileHandler handler;

	void OnMouseDown(){
		handler.save ();
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

}
