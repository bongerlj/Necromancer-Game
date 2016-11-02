using UnityEngine;
using System.Collections;

public class Crystal : MonoBehaviour {

	private Player player;
	private static bool spawn = true;
	public AudioSource pickup;

	/*public static int timesTutorialLoaded = 0; //level 2
	public static int timesCourtyardLoaded = 0; //level 3
	public static int timesDungeonLoaded = 0; //level 4
	public static int timesArmouryLoaded = 0; //level 5
	public static int timesLibraryLoaded = 0; //level 6*/
	public static int timesLevelLoaded;

	void Start() {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();

		if(Application.loadedLevel == 1) 

		/*if (Application.loadedLevel == 2) {
			timesTutorialLoaded += 1;
		}
		if (Application.loadedLevel == 3) {
			timesCourtyardLoaded += 1;
			print ("courtyard loaded: " + timesCourtyardLoaded);
		}
		if (Application.loadedLevel == 4) {
			timesDungeonLoaded += 1;
		}
		if (Application.loadedLevel == 5) {
			timesArmouryLoaded += 1;
		}
		if (Application.loadedLevel == 2) {
			timesLibraryLoaded += 1;
		}

		if (timesTutorialLoaded <= 1) {
			spawn = true;
			print ("courtyard loaded: " + timesCourtyardLoaded);
		}
		if (timesCourtyardLoaded <= 1) {
			spawn = true;
		}
		if (timesDungeonLoaded <= 1) {
			spawn = true;
		}
		if (timesArmouryLoaded <= 1) {
			spawn = true;
		}
		if (timesLibraryLoaded <= 1) {
			spawn = true;
		}
		else {
			spawn = false;
		}*/
		print ("Spawn: " + spawn);
	}

	void OnTriggerEnter2D(Collider2D col) {
		if(col.CompareTag("Player")) {
			Destroy (gameObject);
			pickup.GetComponent<AudioSource>().volume = 0.05f;
			pickup.Play ();
			spawn = false;
			//Player.deathCount = 0;
			Player.livesRemaining = 3;
			Player.currentHealth = player.maxHealth;
			Player.currentStamina = player.maxStamina;
			//print ("Deaths: " + Player.deathCount);
			print("Lives: " + Player.livesRemaining);
		}
	}

	//make sure the player can only collect item once per game
	void Update() {
		if (spawn == false) {
			Destroy (gameObject);
		}
	}
}