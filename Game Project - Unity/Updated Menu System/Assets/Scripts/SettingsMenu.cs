using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour {

	public AudioMixer audioMixer;

	public void SetMasterVolume (float volume)
	{
		
		audioMixer.SetFloat("volumeMaster", volume);
	}

	public void SetMusicVolume (float volume)
	{
		audioMixer.SetFloat("volumeMusic", volume);
	}

	public void SetSFXVolume (float volume)
	{
		audioMixer.SetFloat("volumeSFX", volume);
	}
}
