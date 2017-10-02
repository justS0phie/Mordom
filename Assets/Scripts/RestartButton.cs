using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour {

	GameObject alienspawn;
	ControleDeFases script;

	void OnMouseDown(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

}
