using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public static AudioManager Instance;

	public AudioSource audioS;

	void Awake ()   
	{
		if (Instance == null)
		{
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy (gameObject);
		}
	}

	public void changeMusic (AudioClip audio){
		if (audioS.clip.name == audio.name) {
			return;
		}
		audioS.Stop ();
		audioS.clip = audio;
		audioS.Play ();
	}
}
