using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static bool GameIsOver;

	public GameObject gameOverUI;
	public GameObject completeLevelUI;
	public Text levelName;

	void Start(){
		GameIsOver = false;
		SetLevelName ();
	}

	void Update () {
		if (GameIsOver) {
			return;
		}
		if (PlayerStats.Lives <= 0) {
			EndGame ();
		}
	}

	public void EndGame(){
		GameIsOver = true;
		gameOverUI.SetActive (true);
	}

	public void WinLevel(){
		GameIsOver = true;
		completeLevelUI.SetActive (true);
	}

	private void SetLevelName(){
		if (SceneManager.GetActiveScene ().name == "LevelFinalBoss") {
			levelName.text = "Final Level";
		} else {
			levelName.text = SceneManager.GetActiveScene ().name.Insert (5, " ");
		}
	}
}
