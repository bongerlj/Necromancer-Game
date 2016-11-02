using UnityEngine;
using System.Collections;

public class attackTrigger : MonoBehaviour {

	public int dmg = 20;
	public AudioSource hitEnemySound;

	void OnTriggerEnter2D(Collider2D col) {
		//player can only attack non trigger colliders labeled with "Enemy" tag
		if (col.isTrigger != true && col.CompareTag("Enemy") || col.CompareTag("Secret")) {
			hitEnemySound.GetComponent<AudioSource>().volume = 0.05f;
			hitEnemySound.Play ();
			//if above condition is true call damage fxn from NecromancerAI
			col.SendMessageUpwards ("Damage", dmg);
		}
	}
}