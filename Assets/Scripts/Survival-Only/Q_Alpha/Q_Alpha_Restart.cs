using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Q_Alpha_Restart : MonoBehaviour {

	GameObject alienspawn;
	public Q_Alpha_FileHandler handler;

	void Start(){}

	void OnMouseDown(){
		handler.save ();
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);    
	}

}
