using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour {

	private GameObject[] toolList;
	private string weapon;

	void Start () {
		toolList = GameObject.FindGameObjectsWithTag("Tool");
		foreach (GameObject tool in toolList)
			tool.SetActive (false);
		weapon = "";
	}

	void LateUpdate(){
		if (weapon != "") 
		{
			foreach (GameObject tool in toolList)
				if (tool.name == weapon && GetComponent<PhaseControl> ().phase == GamePhase.Game)
					tool.SetActive (true);
				else
					tool.SetActive (false);
			weapon = "";
		}
		if (weapon == "none")
			foreach (GameObject tool in toolList)
				tool.SetActive (false);
	}

	public void ChangeWeapon(string Wpn_Name)
	{
		weapon = Wpn_Name;
	}
}
