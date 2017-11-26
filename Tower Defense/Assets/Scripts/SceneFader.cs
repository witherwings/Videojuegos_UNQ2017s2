﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour {
	public Image img;
	public AnimationCurve fadeCurve;

	void Start(){
		StartCoroutine (FadeIn ());
	}

	public void FadeTo(string scene){
		Time.timeScale = 1f;
		StartCoroutine (FadeOut (scene));

	}

	IEnumerator FadeIn(){
		float t = 1f;

		while (t > 0f){
			t -= Time.deltaTime;
			float a = fadeCurve.Evaluate (t);
			img.color = new Color (0f, 0f, 0f, a);
			yield return 0;
		}
	}

	IEnumerator FadeOut(string scene){
		float t = 0f;

		while (t < 1f){
			t += Time.deltaTime;
			float a = fadeCurve.Evaluate (t);
			img.color = new Color (0f, 0f, 0f, a);
			yield return 0;
		}

		SpawnerScript.enemiesAlive = 0;
		SceneManager.LoadScene (scene);
	}

}
