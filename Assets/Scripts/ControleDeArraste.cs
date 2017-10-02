using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDeArraste : MonoBehaviour {

	//garante uma e uma unica instancia de ControleDeArraste
	//ao chamar funcoes do componente, usar ControleDeArraste.instancia.[ChamadaDoMetodo];

	public static ControleDeArraste instancia = null;

	void Awake() {

        if (instancia == null)
            instancia = this;
        else if (instancia != this)
            Destroy(gameObject);
    }


    public bool habilitado;
	public List<GameObject> pseudoPilhaDeArraste;
	public GameObject objetoSendoArrastado;

	void Start() {

		habilitado = false;
		pseudoPilhaDeArraste = new List<GameObject>();
		objetoSendoArrastado = null;
	}

	void Update() {

		if(!habilitado) return;

		//se o mouse for pressionado e a pilha nao estiver vazia e nao houver objeto sendo arrastado
		//comecar o arraste do ultimo objeto empilhado
		if(Input.GetMouseButtonDown(0) && pseudoPilhaDeArraste.Count > 0 && objetoSendoArrastado == null) {

			objetoSendoArrastado = pseudoPilhaDeArraste[pseudoPilhaDeArraste.Count-1];
			objetoSendoArrastado.GetComponent<ArrasteDeElemento>().IniciarArraste();
		}

		//se o botao do mouse for solto e algum objeto estiver sendo arrastado
		//este objeto para de ser arrastado
		if(Input.GetMouseButtonUp(0) && objetoSendoArrastado != null) {

			objetoSendoArrastado.GetComponent<ArrasteDeElemento>().FinalizarArraste();
			objetoSendoArrastado = null;
		}
	}

	public void HabilitarArraste() {
		habilitado = true;
	}

	public void DesabilitarArraste() {
		habilitado = false;

		if(objetoSendoArrastado != null) {

			objetoSendoArrastado.GetComponent<ArrasteDeElemento>().FinalizarArraste();
			objetoSendoArrastado = null;
		}
	}

	public void EmpilharElemento(GameObject elemento) {

		pseudoPilhaDeArraste.Add(elemento);
	}

	public void RetirarElemento(GameObject elemento) {

		if(pseudoPilhaDeArraste.Contains(elemento))
			pseudoPilhaDeArraste.Remove(elemento);

	}
}
