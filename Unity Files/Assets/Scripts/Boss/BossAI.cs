using UnityEngine;
using System.Collections;

public class BossAI : MonoBehaviour {

	public int currentHealth;
	public int maxHealth;

	public float distance;
	public float wakeRange;
	public float shootInterval;
	public float projectileSpeed;
	public float projectileTimer;

	public bool awake = false;
	public bool lookingRight = true;
	public static bool isDead = false;

	public GameObject bossProjectile;
	public Transform target;
	public Animator anim;
	public Transform ShootPointRight;
	public Transform ShootPointLeft;

	void Awake() {
		anim = gameObject.GetComponent<Animator> ();
		currentHealth = maxHealth;
	}

	void Start () {
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("Awake", awake);
		anim.SetBool ("LookingRight", lookingRight);
		anim.SetBool ("Dead", isDead);

		RangeCheck ();

		//if target's x posistion is > turret position, look right
		if(target.transform.position.x > transform.position.x) {
			lookingRight = true;
		}

		//if target's x posistion is < turret position, look left
		if(target.transform.position.x < transform.position.x) {
			lookingRight = false;
		}

		//check to make sure its not dead. If its dead kill it
		if(currentHealth <= 0) {
			isDead = true;
			awake = false;
			//Destroy (gameObject);
			//bossAlive = false;
		}
	}

	void RangeCheck() {
		distance = Vector3.Distance (transform.position, target.transform.position);

		if (distance < wakeRange && lookingRight == true) {
			awake = true;
		}

		if (distance < wakeRange && lookingRight == false) {
			awake = true;
		}

		if (distance > wakeRange) {
			awake = false;
		}
	}

	public void Attack(bool attackingRight) {
		projectileTimer += Time.deltaTime;

		if(projectileTimer >= shootInterval) {
			Vector2 direction = target.transform.position - transform.position;
			direction.Normalize ();

			if(!attackingRight && !isDead) {
				//create projectile
				GameObject projectileClone;
				projectileClone = Instantiate (bossProjectile, ShootPointLeft.transform.position, ShootPointLeft.transform.rotation) as GameObject;
				//set vector of projectile clone
				projectileClone.GetComponent<Rigidbody2D> ().velocity = direction * projectileSpeed;

				//timer function so it doesn't shoot a thousand times per frame
				projectileTimer = 0;
			}

			if(attackingRight && !isDead) {
				//create projectile
				GameObject projectileClone;
				projectileClone = Instantiate (bossProjectile, ShootPointRight.transform.position, ShootPointRight.transform.rotation) as GameObject;
				//set vector of projectile clone
				projectileClone.GetComponent<Rigidbody2D> ().velocity = direction * projectileSpeed;

				//timer function so it doesn't shoot a thousand times per frame
				projectileTimer = 0;
			}
		}
	}

	public void Damage(int damage) {
		currentHealth -= (damage + Player.damageModifier);
		gameObject.GetComponent<Animation> ().Play ("Player_Damage");
	}
}