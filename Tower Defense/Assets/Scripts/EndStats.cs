using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndStats : MonoBehaviour {

	public Text wavesText;
	public Text killCountRound;
	public Text killCountTotal;

	public void OnEnable(){
		StartCoroutine (AnimateText ());
		killCountRound.text = PlayerStats.KillCountRound.ToString();
		killCountTotal.text = PlayerStats.KillCountTotal.ToString();
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
