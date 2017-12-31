using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour {

	private int lifes;

	void Start () {
		lifes = 5;
	}
	
	void Update () {
		
	}

	public void loseLife() {
		this.lifes--;
	}

}
