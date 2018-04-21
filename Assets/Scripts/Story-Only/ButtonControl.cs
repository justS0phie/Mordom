using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour {

	public GameObject controller;
	public ControleDeFases script;
	public GameObject canvas;
    public Button Start;
    public Button Ok;
    public Image instruct;
    public Button next;
    public Image instruct2;

    public void buttonStart(){
		
		if (controller == null) {
			controller = GameObject.FindGameObjectWithTag ("GameController");
			script = controller.GetComponent ("ControleDeFases") as ControleDeFases;
		}
        Start.gameObject.SetActive(false);
        script.MudarDeFase (FaseDeJogo.Jogo);
	}

    public void buttonOk()
    {
   
        Ok.gameObject.SetActive(false);
        instruct.gameObject.SetActive(false);
        
    }

    public void buttonNext()
    {

     
        instruct2.gameObject.SetActive(false);
    }

    public void buttonRestart(){

		if (controller == null) {
			controller = GameObject.FindGameObjectWithTag ("GameController");
			script = controller.GetComponent ("ControleDeFases") as ControleDeFases;

			try
			{
				FileHandler file_handler = controller.GetComponent("FileHandler") as FileHandler;
				file_handler.save ();
			} catch {
				Q_Alpha_FileHandler file_handler = controller.GetComponent("Q_Alpha_FileHandler") as Q_Alpha_FileHandler;
				file_handler.save ();
			}

		}

		canvas.gameObject.SetActive (true);
		script.onPause ();
		Time.timeScale = 0;
	}
}
