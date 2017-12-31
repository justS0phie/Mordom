using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseControl : MonoBehaviour {

	public GamePhase phase;

	public GameObject enemyspawn;
	public GameObject planet;
	public GameObject startButton;

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
			gameObject.GetComponent<WeaponControl> ().ChangeWeapon ("none");
			startButton.SetActive (true);
			break;

		case GamePhase.Game:
			gameObject.GetComponent<ControleDeArraste> ().DesabilitarArraste ();
			Camera.main.GetComponent<CameraControl> ().Disable ();
			enemyspawn.SetActive (true);
			gameObject.GetComponent<WeaponControl> ().ChangeWeapon ("Cannon");
			startButton.SetActive (false);
			break;

		case GamePhase.Shop:
			gameObject.GetComponent<ControleDeArraste> ().DesabilitarArraste ();
			Camera.main.GetComponent<CameraControl> ().Disable ();
			gameObject.GetComponent<WeaponControl> ().ChangeWeapon ("none");
			enemyspawn.SetActive (false);
			startButton.SetActive (true);
			break;

		}
	}
}

public enum GamePhase {
	NONE, Prep, Game, Shop
}