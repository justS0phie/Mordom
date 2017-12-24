using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrasteDeElemento : MonoBehaviour {

	public bool elementoSendoArrastado;
	private Vector2 initialPos;

	void Start () {
		elementoSendoArrastado = false;
	}
	
	public virtual void Update () {

		if(!elementoSendoArrastado) return;

		Vector3 posicaoDoMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		transform.position = new Vector3(posicaoDoMouse.x, posicaoDoMouse.y, transform.position.z);
	}

	public void IniciarArraste() {
		elementoSendoArrastado = true;
		initialPos = transform.position;
	}

	public void FinalizarArraste() {
		elementoSendoArrastado = false;

		foreach (GameObject button in GameObject.FindGameObjectsWithTag("Button")) {
			if (button != this.gameObject) {
				if (this.gameObject.GetComponent<Collider2D> ().IsTouching (button.GetComponent<Collider2D> ()))
					transform.position = initialPos;
			}
		}
		GameObject planeta = GameObject.Find ("Planet");
		if (this.gameObject.GetComponent<Collider2D> ().IsTouching (planeta.GetComponent<Collider2D> ()))
			transform.position = initialPos;
	}

	public void OnMouseEnter() {
		ControleDeArraste.instancia.EmpilharElemento(gameObject);
	}

	public void OnMouseExit() {
		ControleDeArraste.instancia.RetirarElemento(gameObject);
	}
}