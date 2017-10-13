using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {

	public Text wavesText;

	void OnEnable(){
		wavesText.text = PlayerStats.Waves.ToString ();
	}

	public void Retry(){
		Time.timeScale = 1f;
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}

	public void Menu(){
		Debug.Log ("Menu");
	}
}
