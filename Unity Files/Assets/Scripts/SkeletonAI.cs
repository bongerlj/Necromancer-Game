using UnityEngine;
using System.Collections;

public class SkeletonAI : MonoBehaviour {

	public Transform target;
	public Animator anim;
	private Player player;
	public Vector2 playerPosition;

	public int currentHealth;
	public int maxHealth = 40;

	public float speed = 3f;
	public float wakeRange = 3f;
	public float range;
	public float yRange;
	public float difference;

	public bool moving = false;
	public bool attacking = false;
	public bool chasing = false;
	//public bool inYRange = false;

	void Start() {
		anim = gameObject.GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		currentHealth = maxHealth;
		//skeletonAttackTrigger.enabled = false;
		//currentHealth = maxHealth;
	}

	void Update() {
		//used so skeleton doesn't just slide around on the y axis after the player, he can't jump
		playerPosition = new Vector2 (player.transform.position.x, player.lastGroundedPosition);
		range = Vector2.Distance (transform.position, target.position);
		Vector2 difference = transform.position - target.position;
		yRange = Mathf.Abs(difference.y);

		if(target.transform.position.x > transform.position.x) {
			transform.localScale = new Vector3 (1, 1, 1);
		}
			
		if(target.transform.position.x < transform.position.x) {
			transform.localScale = new Vector3 (-1, 1, 1);
		}

		/*if(Mathf.Abs(Vector2.Distance (transform.position.y, target.position.y)) <= 0.2) {
			inYRange = true;
		}
		else {
			inYRange = false;
		}*/


		if (range <= wakeRange && range >= 0.5f && yRange <= 0.2) {
			moving = true;
			chasing = true;
			transform.position = Vector2.MoveTowards (transform.position, playerPosition, speed * Time.deltaTime);
		}

		if (range > wakeRange && !chasing) {
			moving = false;
		}

		if (range <= 1f) {
			attacking = true;
			speed = 0f;
		}

		if (range > 1f) {
			attacking = false;
			speed = 3f;
		}

		if(currentHealth <= 0) {
			Destroy (gameObject);
		}

		anim.SetBool ("Moving", moving);
		anim.SetBool ("Attacking", attacking);

	}

	public void Damage(int damage) {
		currentHealth -= (damage + Player.damageModifier);
		gameObject.GetComponent<Animation> ().Play ("Player_Damage");
	}
}