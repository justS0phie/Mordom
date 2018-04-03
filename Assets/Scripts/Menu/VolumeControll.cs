using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeControll : MonoBehaviour {

	public AudioMixer audioMixer;
	public AudioSource audioSource;
	public void setMasterVolume(float volume){
		audioMixer.SetFloat ("masterVolume", volume-100);
		if(audioSource.isPlaying == false)
			audioSource.Play();
	}

	public void setMusicVolume(float volume){
		audioMixer.SetFloat ("musicVolume", volume-100);
	}

	public void setEffectVolume(float volume){
		audioMixer.SetFloat ("effectVolume", volume-100);
		if(audioSource.isPlaying == false)
			audioSource.Play();
	}
}