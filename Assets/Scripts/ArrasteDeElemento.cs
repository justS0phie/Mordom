using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrasteDeElemento : MonoBehaviour {

	private bool habilitado;

	public bool elementoSendoArrastado;

	void Start () {

		habilitado = false;
		objetoSendoArrastado = false;
	}
	
	void Update () {

		if(!habilitado) return;
	}

	public void HabilitarArraste() {
		habilitado = true;
	}

	public void DesabilitarArraste() {
		habilitado = false;
	}
}