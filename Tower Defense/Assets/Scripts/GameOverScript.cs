using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {

	public SceneFader sceneFader;
	public string menuSceneName = "Menu";

	public void Start(){
		Time.timeScale = 0f;
	}

	public void Retry(){
		Time.timeScale = 1f;
		sceneFader.FadeTo (SceneManager.GetActiveScene ().name);
	}

	public void Menu(){
		Time.timeScale = 1f;
		sceneFader.FadeTo (menuSceneName);
	}
}
