using UnityEngine;
using System.Collections;

public class LibraryCrystal : MonoBehaviour {

	public static int timesLibraryLoaded;
	private static bool beenPickedUp = false;
	private bool spawn = true;
	public AudioSource pickup;
	private Player player;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();

		//keep track of number of times this level has been loaded
		if(Application.loadedLevel == 6) {
			timesLibraryLoaded += 1;
		}

		//spawn crystal if it hasn't been picked up this level or this level hasn't been loaded before
		if (timesLibraryLoaded == 1 || !beenPickedUp) {
			spawn = true;
		}

		//no crystal if its been picked up and the level has been loaded before
		if(timesLibraryLoaded > 1 && beenPickedUp) {
			spawn = false;
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		//when picked up, disable spawning of crystal, refill player lives, health, and stamina
		if(col.CompareTag("Player")) {
			Destroy (gameObject);
			pickup.GetComponent<AudioSource>().volume = 0.05f;
			pickup.Play ();
			beenPickedUp = true;
			Player.livesRemaining = 3;
			Player.currentHealth = player.maxHealth;
			Player.currentStamina = player.maxStamina;
			print("Lives: " + Player.livesRemaining);
		}
	}

	void Update () {
		if (spawn == false) {
			Destroy (gameObject);
		}
	}
}