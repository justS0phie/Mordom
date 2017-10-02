using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDeFases : MonoBehaviour {

	public FaseDeJogo fase;

	public bool objetosInstanciados;
	bool prep;
	private GameObject alienspawn;

	public GameObject planeta;

	void Start () {
		fase = FaseDeJogo.NONE;

		prep = false;

		objetosInstanciados = false;
		alienspawn = GameObject.FindGameObjectWithTag ("Respawn");
		alienspawn.SetActive (false);

		planeta = null;
	}

	void MudarDeFase(FaseDeJogo novaFase) {

		fase = novaFase;

		switch(fase) {

		case FaseDeJogo.Preparacao:
			gameObject.GetComponent<ControleDeArraste> ().HabilitarArraste ();
			break;

		case FaseDeJogo.Jogo:
			gameObject.GetComponent<ControleDeArraste>().DesabilitarArraste();
			alienspawn.SetActive (true);
			break;

		}
	}
	
	void Update () {
		//se os objetos a serem manipulados ainda nao estiverem instanciados, procurar na hierarquia pela tag
		if (!objetosInstanciados)
			ProcurarObjetos ();
		else if (!prep) {
			MudarDeFase(FaseDeJogo.Preparacao);
			prep = true;
		}

		if (Input.GetKey("space")){
			MudarDeFase(FaseDeJogo.Jogo);
		}
			
	}

	private void ProcurarObjetos() {

		//aqui vem a lista de objetos a serem buscados
		//para cada um, se for null, buscar na hierarquia pela tag
		if(planeta == null)
			planeta = GameObject.FindGameObjectsWithTag("Planet")[0];

		//quando todos os objetos necessarios para iniciar forem instanciados
		//definir objetosInstanciados como true
		if(planeta != null)
			objetosInstanciados = true;
	}
}

public enum FaseDeJogo {

	NONE,
	Preparacao,
	Jogo,
}