using UnityEngine;

[RequireComponent(typeof(EnemyScript))]
public class EnemyMovement : MonoBehaviour {

	private Transform target;
	private int nextPathPoint = 0;

	private EnemyScript enemySc;

	void Start(){
		enemySc = GetComponent<EnemyScript> ();
		target = PathScript.pathPoints [0];
	}

	void Update(){
		Vector3 direction = target.position - transform.position;
		transform.Translate (direction.normalized * enemySc.speed * Time.deltaTime, Space.World);

		if (Vector3.Distance (transform.position, target.position) <= 0.4f) {
			NextPathPoint ();
		}

		enemySc.speed = enemySc.startSpeed;
	}

	void NextPathPoint(){

		if (nextPathPoint >= PathScript.pathPoints.Length - 1) {
			EndPath ();	
			return;
		}
		nextPathPoint++;
		target = PathScript.pathPoints [nextPathPoint];
	}

	void EndPath(){
		PlayerStats.Lives--;
		SpawnerScript.enemiesAlive--;
		Destroy (gameObject);
	}
}
