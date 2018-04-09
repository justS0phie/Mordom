using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AjusteContraste : MonoBehaviour {
	public Slider SliderHue;
	public Slider SliderSaturacao;
	public Slider SliderBrilho;

	public float hue;
	public float saturacao;
	public float brilho;

	// Use this for initialization
	public void SetContrast () {
		SliderHue.value = hue;
		SliderSaturacao.value = saturacao;
		SliderBrilho.value = brilho; 
	}
}
