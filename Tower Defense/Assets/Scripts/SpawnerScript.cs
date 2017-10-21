using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnerScript : MonoBehaviour {

	public static int enemiesAlive = 0;

	public Wave[] waves;
	public Transform spawner;

	public float timeSpammer = 5.5f;
	private float countdown = 2f;

	private int waveLevel = 0;
	public Text waveCount;

	public GameManager gm;

	void Update(){
		if (enemiesAlive > 0) {
			return;
		}

		if (waveLevel == waves.Length) {
			Debug.Log ("LEVEL WON");
			gm.WinLevel ();
			this.enabled = false;
		}

		if (countdown <= 0) {
			StartCoroutine (SpawnWave ());
			countdown = timeSpammer;
			return;
		}

		countdown -= Time.deltaTime;
		countdown = Mathf.Clamp (countdown, 0f, Mathf.Infinity);

		waveCount.text = string.Format("{0:00.00}",countdown);
	}

	IEnumerator SpawnWave(){
		Debug.Log ("Wave Incoming!");
		PlayerStats.Waves++;

		Wave wave = waves [waveLevel];

		enemiesAlive = wave.count;

		for (int i = 0; i < wave.count; i++) {
			SpawnSingleEnemy (wave.enemyPfb);
			yield return new WaitForSeconds (1f / wave.rate);
		}
		waveLevel++;

	}

	void SpawnSingleEnemy(GameObject enemyPfb){
		Instantiate (enemyPfb, spawner.position, spawner.rotation);
	}
}
