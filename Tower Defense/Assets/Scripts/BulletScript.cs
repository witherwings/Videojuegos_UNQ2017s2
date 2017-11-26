using UnityEngine;

public class BulletScript : MonoBehaviour {

	private Transform target;
	public float speed = 70f;
	public float explosionRadius = 0f;
	public int damageBullet = 50;
	public GameObject impactEffect;

	private GameObject turretOrigin;

	public void LockOn (Transform lockon){
		target = lockon;
	}

	void Update () {
		if (target == null) {
			Destroy (gameObject);
			return;
		}

		Vector3 dir = target.position - transform.position;
		float distanceFrame = speed * Time.deltaTime;

		if (dir.magnitude <= distanceFrame) {
			HitTarget ();
			return;
		}

		transform.Translate (dir.normalized * distanceFrame, Space.World);
		transform.LookAt (target);
	}

	void HitTarget(){
		GameObject effect = (GameObject)Instantiate (impactEffect, transform.position, transform.rotation);
		Destroy (effect, 5f);	

		Damage (target, 1.0f);
		if (explosionRadius > 0f) {
			Explode ();
		}

		turretOrigin.GetComponent<AudioSource> ().Stop ();
		target.GetComponent<AudioSource> ().Play ();

		Destroy (gameObject);
	}

	void Explode(){
		Collider[] colliders = Physics.OverlapSphere (transform.position, explosionRadius);
		foreach (Collider col in colliders) {
			if (col.tag == "Enemy" && col.transform != target) {
				Damage (col.transform, 0.5f);
			}
		}
	}

	void Damage(Transform enemy, float multiplier){
		EnemyScript e = enemy.GetComponent<EnemyScript>();
		if (e != null) {
			e.TakeDamage (damageBullet * multiplier);
		}
	}

	public void setTurret(GameObject t){
		turretOrigin = t;
	}
}
