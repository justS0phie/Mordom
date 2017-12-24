using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBtns : MonoBehaviour {

	public PhaseControl p_control;
	public WeaponControl w_control;

	void OnMouseDown() {

		if (p_control.phase == GamePhase.Game) {
			string weapon = name.Remove (this.name.Length - 4);
			w_control.ChangeWeapon (weapon);
			print (weapon);
		}
	}
}
