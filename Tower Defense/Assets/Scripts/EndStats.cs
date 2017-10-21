using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndStats : MonoBehaviour {

	public Text wavesText;

	public void OnEnable(){
		StartCoroutine (AnimateText ());
	}

	IEnumerator AnimateText(){
		wavesText.text = "0";
		int wave = 0;

		yield return new WaitForSeconds (.7f);

		while (wave < PlayerStats.Waves) {
			wave++;
			wavesText.text = wave.ToString ();

			yield return new WaitForSeconds (.05f);
		}
	}
}
