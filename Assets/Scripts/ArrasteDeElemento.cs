using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrasteDeElemento : MonoBehaviour {

	public bool elementoSendoArrastado;

	void Start () {

		elementoSendoArrastado = false;
	}
	
	void Update () {

		if(!elementoSendoArrastado) return;

		Vector3 posicaoDoMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		transform.position = new Vector3(posicaoDoMouse.x, posicaoDoMouse.y, -1);
	}

	public void IniciarArraste() {
		elementoSendoArrastado = true;
	}

	public void FinalizarArraste() {
		elementoSendoArrastado = false;
	}

	public void OnMouseEnter() {
		ControleDeArraste.instancia.EmpilharElemento(gameObject);
	}

	public void OnMouseExit() {
		ControleDeArraste.instancia.RetirarElemento(gameObject);
	}
}