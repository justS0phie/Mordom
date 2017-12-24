using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseControl : MonoBehaviour {

	public GamePhase phase;

	public GameObject enemyspawn;
	public GameObject planet;

	void Start () {
		phase = GamePhase.NONE;
	}

	public void ChangePhase(GamePhase newphase) {

		phase = newphase;

		switch(phase) {

		case GamePhase.Prep:
			enemyspawn.SetActive (false);
			gameObject.GetComponent<ControleDeArraste> ().HabilitarArraste ();
			Camera.main.GetComponent<CameraControl> ().Enable ();
			break;

		case GamePhase.Game:
			gameObject.GetComponent<ControleDeArraste> ().DesabilitarArraste ();
			Camera.main.GetComponent<CameraControl> ().Disable ();
			enemyspawn.SetActive (true);
			gameObject.GetComponent<WeaponControl> ().ChangeWeapon ("Cannon");
			break;

		case GamePhase.Shop:
			break;

		}
	}

	void Update () {

		if (phase != GamePhase.Game) {
			GameObject[] enemyList = GameObject.FindGameObjectsWithTag("Alien");

			foreach (GameObject enemy in enemyList) {
				Destroy (enemy);
			}
		}
	}
}

public enum GamePhase {
	NONE, Prep, Game, Shop
}