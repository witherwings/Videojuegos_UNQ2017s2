using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour {

	public SceneFader fader;
	public string menuSceneName = "Menu";


	public string nextLevel = "Level02";
	public int levelToUnlock = 2;

	public void Continue(){
		saveStats ();
		fader.FadeTo (nextLevel);
	}

	public void Menu(){
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
