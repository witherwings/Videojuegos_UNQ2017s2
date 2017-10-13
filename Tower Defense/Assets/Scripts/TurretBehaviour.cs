using UnityEngine;

public class TurretBehaviour : MonoBehaviour {

	private Transform nearestTarget;
	private EnemyScript targetSc;

	[Header("DynamicAttr")]
	public float range = 10f;
	public float fireRate = 1f;
	private float fireCountdown = 0f;
	public GameObject bulletPfb;

	[Header("LaserConfig")]
	public bool useLaser = false;

	public int damageOverTime = 20;
	public float slowEnemy = .5f;

	public LineRenderer lineRenderer;
	public ParticleSystem impactEffect;
	public Light impactLight;

	[Header("UnityAttr")]
	public string enemyTag = "Enemy";

	public Transform rotator;
	public float rotateSpeed = 10f;

	public Transform firePoint;

	void Start(){
		InvokeRepeating ("UpdateTarget", 0f, 0.5f);
	}

	void UpdateTarget(){
		GameObject[] enemiesInRange = GameObject.FindGameObjectsWithTag (enemyTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;

		foreach (GameObject enemy in enemiesInRange) {
			float distance = Vector3.Distance (transform.position, enemy.transform.position);
			if (distance < shortestDistance) {
				shortestDistance = distance;
				nearestEnemy = enemy;
			}
		}

		if (nearestEnemy != null && shortestDistance <= range) {
			nearestTarget = nearestEnemy.transform;
			targetSc = nearestEnemy.GetComponent<EnemyScript> ();
		} else {
			nearestTarget = null;
		}
	}

	void Update(){
		if (nearestTarget == null) {
			if (useLaser) {
				if (lineRenderer.enabled) {
					lineRenderer.enabled = false;
					impactEffect.Stop ();
					impactLight.enabled = false;
				}
			}
			return;
		}

		LockOn();

		if (useLaser) {
			Laser ();
		} else {
			if (fireCountdown <= 0f) {
				Shoot ();
				fireCountdown = 1f / fireRate;
			}

			fireCountdown -= Time.deltaTime;
		}

	}

	void LockOn(){
		Vector3 dir = nearestTarget.position - transform.position;
		Quaternion dirRotation = Quaternion.LookRotation (dir);
		Vector3 rotation = Quaternion.Lerp(rotator.rotation, dirRotation,Time.deltaTime * rotateSpeed).eulerAngles;
		rotator.rotation = Quaternion.Euler (0f, rotation.y, 0f);
	}

	void Laser(){
		targetSc.TakeDamage (damageOverTime * Time.deltaTime);
		targetSc.Slow (slowEnemy);

		if (!lineRenderer.enabled) {
			lineRenderer.enabled = true;
			impactEffect.Play ();
			impactLight.enabled = true;
		}
		lineRenderer.SetPosition (0, firePoint.position);
		lineRenderer.SetPosition (1, nearestTarget.position);

		Vector3 dir = firePoint.position - nearestTarget.position;

		impactEffect.transform.position = nearestTarget.position + dir.normalized;
		impactEffect.transform.rotation = Quaternion.LookRotation (dir);
	}

	void Shoot(){
		GameObject bulletInit = (GameObject)Instantiate (bulletPfb, firePoint.position, firePoint.rotation);
		BulletScript bullet = bulletInit.GetComponent<BulletScript> ();

		if (bullet != null) {
			bullet.LockOn (nearestTarget);
		}
	}

	void OnDrawGizmosSelected(){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position,range);
	}
}
