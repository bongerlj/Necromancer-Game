using UnityEngine;
using System.Collections;

public class SkeletonAttackTrigger : MonoBehaviour {

	private Player player;
	public int dmg = 2;
	public AudioSource player_hit;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		player_hit.GetComponent<AudioSource>().volume = 0.0f;
	}

	void OnTriggerEnter2D(Collider2D col) {
		//player can only attack non trigger colliders labeled with "Enemy" tag
		if (col.isTrigger != true && col.CompareTag("Player") && !player.blocking) {
			//if above condition is true call damage fxn from NecromancerAI
			//player.Damage(dmg);
			col.SendMessageUpwards("Damage", dmg);
		}

		if(col.isTrigger != true && col.CompareTag("Player") && player.blocking) {
			player_hit.GetComponent<AudioSource>().volume = 0.05f;
			player_hit.Play ();
			Player.currentStamina -= 1;
		}
	}
}