using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour {

	public float startSpeed= 10f;
	[HideInInspector]
	public float speed;

	public float startHealth = 100;
	public float health;
	public int moneyOnDeath = 100;
	public GameObject deathEffect;
	public Image healthBar;

	private bool isDead = false;

	void Start(){
		speed = startSpeed;
		health = startHealth;
	}

	public void TakeDamage(float damage){
		health -= damage;

		healthBar.fillAmount = health / startHealth;

		if (health <= 0 && !isDead) {
			Die ();
		}
	}

	public void Slow(float amount){
		speed = startSpeed * (1f - amount);
	}

	void Die(){

		isDead = true;
		PlayerStats.Money += moneyOnDeath;

		GameObject effect = (GameObject)Instantiate (deathEffect, transform.position, Quaternion.identity);
		Destroy (effect, 5);

		SpawnerScript.enemiesAlive--;

		Destroy (gameObject);
	}
}
