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
	public bool activateShotgun;

	private bool[] activateArmas;

	private GameObject Cannon;
	private GameObject LaserCannon;
	private GameObject Shotgun;

	private GameObject alienspawn;
	private GameObject[] toolList;

	public GameObject planeta;

	void Start () {
		fase = FaseDeJogo.NONE;

		prep = false;

		Cannon = GameObject.Find ("Cannon");
		LaserCannon = GameObject.Find ("LaserCannon");
		Shotgun = GameObject.Find ("Shotgun");

		objetosInstanciados = false;
		alienspawn = GameObject.FindGameObjectWithTag ("Respawn");
		alienspawn.SetActive (false);
		toolList = GameObject.FindGameObjectsWithTag("Tool");
		activateArmas = new bool[3];
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
			break;

		case FaseDeJogo.Jogo:
			gameObject.GetComponent<ControleDeArraste> ().DesabilitarArraste ();
			Camera.main.GetComponent<CameraControl>().Disable();
			alienspawn.SetActive (true);
			activateCannon = true;
			break;

		}
	}

	public void onPause(){

		activateArmas [0] = Cannon.activeInHierarchy ;
		activateArmas [1] = LaserCannon.activeInHierarchy;
		activateArmas [2] = Shotgun.activeInHierarchy;
		Cannon.SetActive(false);
		LaserCannon.SetActive(false);
		Shotgun.SetActive(false);
	}

	public void onResume(){
		activateCannon  = activateArmas [0];
		activateLaser   = activateArmas [1];
		activateShotgun = activateArmas [2];
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
			Shotgun.SetActive(false);
        }

		if (activateLaser && !Input.GetMouseButtonDown(0)){
			LaserCannon.SetActive(true);
			activateLaser = false;
            Cannon.SetActive(false);
			Shotgun.SetActive(false);
        }

		if (activateShotgun && !Input.GetMouseButtonDown(0)){
			Shotgun.SetActive(true);
			activateShotgun = false;
			Cannon.SetActive(false);
			LaserCannon.SetActive(false);
		}

		if (fase != FaseDeJogo.Jogo) {
			GameObject[] alienList = GameObject.FindGameObjectsWithTag ("Alien");

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
		
}

public enum FaseDeJogo {
	NONE,
	Preparacao,
	Jogo,
}