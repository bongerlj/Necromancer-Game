using UnityEngine;
using System.Collections;

public class Potion : MonoBehaviour {

	private Player player;
	public AudioSource pickup;
	void Start() {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}

	void OnTriggerEnter2D(Collider2D col) {
		if(col.CompareTag("Player")) {
			Destroy (gameObject);
			pickup.GetComponent<AudioSource>().volume = 0.05f;
			pickup.Play ();
			//Add one health to player when they pick up the object
			//GameObject Player = GameObject.Find ("Player");
			//Player playerScript = Player.GetComponent<Player> ();
			Player.currentHealth += 1;
			//Player.currentStamina += 1;
		}
	}
}