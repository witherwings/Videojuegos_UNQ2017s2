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
		levelName.text = SceneManager.GetActiveScene ().name.Insert(5," ");
	}

	void Update () {
		if (GameIsOver) {
			return;
		}
		if (PlayerStats.Lives <= 0) {
			EndGame ();
		}
	}

	private void EndGame(){
		GameIsOver = true;
		gameOverUI.SetActive (true);
		//Time.timeScale = 0f;
	}

	public void WinLevel(){
		GameIsOver = true;
		completeLevelUI.SetActive (true);
	}
}
