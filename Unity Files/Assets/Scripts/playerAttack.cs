using UnityEngine;
using System.Collections;

public class playerAttack : MonoBehaviour {

	//start off not attacking
	public bool attacking = false;

	//use these to make sure the player can't swing as fast as they can spam the button
	private float attackTimer = 0;
	private float attackCD = 0.5f;

	//need these for collision detection and playing damage animation
	public Collider2D attackTrigger;
	private Animator anim;

	public AudioSource attackSound;
	//public float volume = 0.5f;

	void Awake() {
		//initialize stuff
		anim = gameObject.GetComponent<Animator> ();
		attackTrigger.enabled = false;
	}

	void Update() {
		//if player presses c and is not already attacking, attack, then start cooldown timer
		if(Input.GetKeyDown("c") && !attacking && !gameObject.GetComponent<Player>().blocking) {
			attacking = true;
			attackTimer = attackCD;
			attackTrigger.enabled = true;
			attackSound.GetComponent<AudioSource>().volume = 0.05f;
			attackSound.Play ();
		}

		//if attack timer is still going, decrease it
		if (attacking) {
			if(attackTimer > 0) {
				attackTimer -= Time.deltaTime;
			}
			//player is finished attacking and can now attack again
			else {
				attacking = false;
				attackTrigger.enabled = false;
			}
		}

		//this plays the attack animation
		anim.SetBool ("Attacking", attacking);
	}
}