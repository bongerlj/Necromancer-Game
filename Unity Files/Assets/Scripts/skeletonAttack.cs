using UnityEngine;
using System.Collections;

public class skeletonAttack : MonoBehaviour {

	private Player player;
	//public int dmg = 1;

	//start off not attacking
	public bool attacking = false;

	//use these to make sure the player can't swing as fast as they can spam the button
	private float skeletonAttackTimer = 0;
	private float skeletonAttackCD = 1.0f;

	//need these for collision detection and playing damage animation
	public Collider2D skeletonAttackTrigger;
	private Animator anim;

	void Awake() {
		//initialize stuff
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		anim = gameObject.GetComponent<Animator> ();
		skeletonAttackTrigger.enabled = false;
		//player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}

	void Update() {
		//if player presses c and is not already attacking, attack, then start cooldown timer
		if(gameObject.GetComponent<SkeletonAI>().range < 1f && !attacking) { 
			attacking = true;
			skeletonAttackTimer = skeletonAttackCD;
			skeletonAttackTrigger.enabled = true;
		}

		//if attack timer is still going, decrease it
		if (attacking) {
			if(skeletonAttackTimer > 0) {
				skeletonAttackTimer -= Time.deltaTime;
			}
			//player is finished attacking and can now attack again
			else {
				attacking = false;
				skeletonAttackTrigger.enabled = false;
			}
		}

		/*if(attacking) {
			player.Damage (1);
		}*/

		//this plays the attack animation
		anim.SetBool ("Attacking", attacking);
	}
}