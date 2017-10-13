using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnerScript : MonoBehaviour {

	public Transform enemyPfb;
	public Transform spawner;

	public float timeSpammer = 5.5f;
	private float countdown = 2f;

	private int waveLevel = 0;
	public Text waveCount;

	void Update(){
		if (countdown <= 0) {
			StartCoroutine (SpawnWave ());
			countdown = timeSpammer;
		}

		countdown -= Time.deltaTime;
		countdown = Mathf.Clamp (countdown, 0f, Mathf.Infinity);

		waveCount.text = string.Format("{0:00.00}",countdown);
	}

	IEnumerator SpawnWave(){
		Debug.Log ("Wave Incoming!");
		waveLevel++;
		PlayerStats.Waves++;

		for (int i = 0; i < waveLevel; i++) {
			SpawnSingleEnemy ();
			yield return new WaitForSeconds (0.5f);
		}
	}

	void SpawnSingleEnemy(){
		Instantiate (enemyPfb, spawner.position, spawner.rotation);
	}
}
