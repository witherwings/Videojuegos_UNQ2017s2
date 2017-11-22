using UnityEngine;

[RequireComponent(typeof(EnemyScript))]
public class EnemyMovement : MonoBehaviour {

	private Transform target;
	private int nextPathPoint = 0;
	private float turnSpeed = 5.0f;

	private EnemyScript enemySc;

	void Start(){
		enemySc = GetComponent<EnemyScript> ();
		target = PathScript.pathPoints [0];
	}

	void Update(){
		Vector3 direction = target.position - transform.position;
		Canvas c = transform.gameObject.GetComponentInChildren<Canvas> ();

		transform.Translate (direction.normalized * enemySc.speed * Time.deltaTime, Space.World);
		Quaternion rotCanvas = c.transform.rotation;

		direction.y = 0;
		var rotation = Quaternion.LookRotation(direction);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * turnSpeed);
		c.transform.rotation = rotCanvas;

		if (Vector3.Distance (transform.position, target.position) <= 0.1f) {
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
		PlayerStats.Money -= enemySc.moneyOnDeath / 2;
		SpawnerScript.enemiesAlive--;
		Destroy (gameObject);
	}
}
