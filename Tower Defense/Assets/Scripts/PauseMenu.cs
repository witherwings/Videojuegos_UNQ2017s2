using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public GameObject ui;
	public SceneFader sceneFader;
	public SpawnerScript spawner;
	public string menuSceneName = "Menu";

	public void Update () {
		if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown (KeyCode.P)) {
			Toggle ();
		}
	}

	public void Toggle(){
		ui.SetActive (!ui.activeSelf);

		if (ui.activeSelf) {
			Time.timeScale = 0f;
		} else {
			Time.timeScale = 1f;
		}
	}

	public void Retry(){
		Toggle ();
		spawner.retry (false);
		sceneFader.FadeTo (SceneManager.GetActiveScene ().name);
	}

	public void Menu(){
		Toggle ();
		spawner.retry (true);
		sceneFader.FadeTo (menuSceneName);
	}
}
