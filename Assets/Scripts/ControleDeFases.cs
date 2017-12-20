using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDeFases : MonoBehaviour {

	public FaseDeJogo fase;

	public bool objetosInstanciados;
	public bool prep;
	public int page = 0;

	public bool activateCannon;
	public bool activateLaser;

	private GameObject Cannon;
	private GameObject LaserCannon;

	private GameObject alienspawn;
	private GameObject[] toolList;
	private GameObject startButton;
	private GameObject resetButton;
	private GameObject page1;
	private GameObject page2;

	public GameObject planeta;

	void Start () {
		fase = FaseDeJogo.NONE;

		prep = false;

		Cannon = GameObject.Find ("Cannon");
		LaserCannon = GameObject.Find ("LaserCannon");

		objetosInstanciados = false;
		alienspawn = GameObject.FindGameObjectWithTag ("Respawn");
		alienspawn.SetActive (false);

		toolList = GameObject.FindGameObjectsWithTag("Tool");

		foreach (GameObject tool in toolList)
			tool.SetActive (false);

		planeta = null;
	}

	public void MudarDeFase(FaseDeJogo novaFase) {

		fase = novaFase;

		switch(fase) {

		case FaseDeJogo.Preparacao:
			alienspawn.SetActive (false);
			gameObject.GetComponent<ControleDeArraste> ().HabilitarArraste ();
			Camera.main.GetComponent<CameraControl> ().Enable ();
			if (startButton)
				startButton.SetActive (true);
			if (resetButton)
				resetButton.SetActive (true);
			break;

		case FaseDeJogo.Jogo:
			gameObject.GetComponent<ControleDeArraste> ().DesabilitarArraste ();
			Camera.main.GetComponent<CameraControl>().Disable();
			alienspawn.SetActive (true);
			activateCannon = true;
			break;

		}
	}
		
	void Update () {
		//se os objetos a serem manipulados ainda nao estiverem instanciados, procurar na hierarquia pela tag
		if (!objetosInstanciados)
			ProcurarObjetos ();
		else if (!prep) {
			MudarDeFase (FaseDeJogo.Preparacao);
			prep = true;
		}

		if (activateCannon && !Input.GetMouseButtonDown(0)){
			Cannon.SetActive(true);
			activateCannon = false;
            LaserCannon.SetActive(false);
        }

		if (activateLaser && !Input.GetMouseButtonDown(0)){
			LaserCannon.SetActive(true);
			activateLaser = false;
            Cannon.SetActive(false);
        }

		if (fase != FaseDeJogo.Jogo) {
			GameObject[] alienList = GameObject.FindGameObjectsWithTag("Alien");

			foreach (GameObject alien in alienList) {
				Destroy (alien);
			}
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

	private void setPage(int pageNumber){
		if (page1)
			page1.SetActive (false);
		if (page2)
			page2.SetActive (false);
		if (page1 && pageNumber==0)
			page1.SetActive (true);
		if (page2 && pageNumber==1)
			page2.SetActive (true);
	}
}

public enum FaseDeJogo {
	NONE,
	Preparacao,
	Jogo,
}