using UnityEngine;
using UnityEngine.UI;

public class DifficultyScript : MonoBehaviour {

	public Button normal;
	public Button hard;

	void Start () {
		normal.interactable = false;
	}

	public void changeDifficulty() {
		normal.interactable = !normal.interactable;
		hard.interactable = !hard.interactable;
		PersistenceScript.Instance.hardMode = !PersistenceScript.Instance.hardMode;
	}

}
