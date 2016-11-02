using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {

	private Player player;
	private SkeletonAI skeleton;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}

	//if player collides with spikes, take 2 damage
	void OnTriggerEnter2D(Collider2D col) {
		
		if (col.CompareTag ("Player")) {
			player.Damage (2);
			StartCoroutine (player.Knockback(0.02f, 250, player.transform.position)); //call knockback function from player script
		}

		if (col.CompareTag("Enemy")) {
			//skeleton.Damage (50);
			skeleton.currentHealth -= 50;
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}