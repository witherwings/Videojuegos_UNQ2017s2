using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour {

	public SceneFader fader;
	public string menuSceneName = "Menu";


	public string nextLevel = "Level02";
	public int levelToUnlock = 2;

	public AudioClip winAudio;
	public AudioClip theme;

	void Start(){
		FindObjectOfType<AudioManager> ().changeMusic (winAudio);
	}

	public void Continue(){
		saveStats ();
		FindObjectOfType<AudioManager> ().changeMusic (theme);
		fader.FadeTo (nextLevel);
	}

	public void Menu(){
		FindObjectOfType<AudioManager> ().changeMusic (theme);
		fader.FadeTo (menuSceneName);
	}

	private void saveStats(){
		if (PersistenceScript.Instance.hardMode) {
			PersistenceScript.Instance.lives = PlayerStats.Lives;
			PersistenceScript.Instance.money = PlayerStats.Money + 500;
		}
		PersistenceScript.Instance.levelReached = levelToUnlock;
		PlayerStats.KillCountRound = 0;
	}
}
