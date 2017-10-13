using UnityEngine;

public class EnemyScript : MonoBehaviour {

	public float startSpeed= 10f;
	[HideInInspector]
	public float speed;

	public float health = 100;
	public int moneyOnDeath = 100;
	public GameObject deathEffect;

	void Start(){
		speed = startSpeed;
	}

	public void TakeDamage(float damage){
		health -= damage;

		if (health <= 0) {
			Die ();
		}
	}

	public void Slow(float amount){
		speed = startSpeed * (1f - amount);
	}

	void Die(){
		PlayerStats.Money += moneyOnDeath;

		GameObject effect = (GameObject)Instantiate (deathEffect, transform.position, Quaternion.identity);
		Destroy (effect, 5);
		Destroy (gameObject);
	}
}
