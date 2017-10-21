using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {

	public SceneFader sceneFader;
	public string menuSceneName = "Menu";

	public void Retry(){
		sceneFader.FadeTo (SceneManager.GetActiveScene ().name);
	}

	public void Menu(){
		sceneFader.FadeTo (menuSceneName);
	}
}
