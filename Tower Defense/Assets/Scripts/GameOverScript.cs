using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {

	public SceneFader sceneFader;
	public string menuSceneName = "Menu";
	public SpawnerScript spawner;
	public AudioClip audio;

	void Start(){
		Time.timeScale = 0f;
	}

	public void Retry(){
		spawner.retry (false);
		FindObjectOfType<AudioManager> ().changeMusic (audio);
		sceneFader.FadeTo (SceneManager.GetActiveScene ().name);
	}

	public void Menu(){
		spawner.retry (true);
		FindObjectOfType<AudioManager> ().changeMusic (audio);
		sceneFader.FadeTo (menuSceneName);
	}
}
