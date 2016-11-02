using UnityEngine;
using System.Collections;

public class BossProjectile : MonoBehaviour {

	private Player player;

	void Start() {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}

	void OnTriggerEnter2D(Collider2D col) {
		//!= trigger because otherwise the collision with the firing cones or player attack trigger would affect it
		if(col.isTrigger != true) {
			//if it collides with Player
			if(col.CompareTag("Player")) {
				//add knockback effect, direction dependant on player's position relative to projectile
				if(player.transform.position.x > transform.position.x) {
					StartCoroutine (player.ProjectileKnockback(0.02f, 50, -player.transform.position));
				}
				if(player.transform.position.x < transform.position.x) {
					StartCoroutine (player.ProjectileKnockback(0.02f, 50, player.transform.position));
				}

				if (GameObject.Find ("Player").GetComponent<Player> ().blocking) {
					//col.GetComponent<Player> ().currentStamina -= 1;
					Player.currentStamina -= 2;
				}

				//deal 1 damage if player isn't blocking
				if (!GameObject.Find("Player").GetComponent<Player>().blocking) {
					col.GetComponent<Player> ().Damage (2);
				}

				//projectile dissapears after collision
				Destroy (gameObject);
			}
		}
	}
}
