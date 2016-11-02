using UnityEngine;
using System.Collections;

public class NecromancerAI : MonoBehaviour {

	//integers
	public int currentHealth;
	public int maxHealth = 40;

	//floats
	public float distance;
	public float wakeRange;
	public float shootInterval;
	public float projectileSpeed;
	public float projectileTimer;

	//bools
	public bool awake = false;
	public bool lookingRight = true;

	//references
	public GameObject projectile;
	public Transform target;
	public Animator anim;
	public Transform ShootPointLeft;
	public Transform ShootPointRight;

	void Awake() {
		anim = gameObject.GetComponent<Animator> ();
		currentHealth = maxHealth;
	}

	void Start () {
		currentHealth = maxHealth;
	}

	void Update () {
		anim.SetBool ("Awake", awake);
		anim.SetBool ("LookingRight", lookingRight);

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
			Destroy (gameObject);
		}
	}

	//set turret either awake or asleep depending on player distance
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

			if(!attackingRight) {
				//create projectile
				GameObject projectileClone;
				projectileClone = Instantiate (projectile, ShootPointLeft.transform.position, ShootPointLeft.transform.rotation) as GameObject;
				//set vector of projectile clone
				projectileClone.GetComponent<Rigidbody2D> ().velocity = direction * projectileSpeed;

				//timer function so it doesn't shoot a thousand times per frame
				projectileTimer = 0;
			}

			if(attackingRight) {
				//create projectile
				GameObject projectileClone;
				projectileClone = Instantiate (projectile, ShootPointRight.transform.position, ShootPointRight.transform.rotation) as GameObject;
				//set vector of projectile clone
				projectileClone.GetComponent<Rigidbody2D> ().velocity = direction * projectileSpeed;

				//timer function so it doesn't shoot a thousand times per frame
				projectileTimer = 0;
			}
		}
	}

	//when this fxn is called, damage unit and play damage animation
	public void Damage(int damage) {
		currentHealth -= (damage + Player.damageModifier);
			gameObject.GetComponent<Animation> ().Play ("Player_Damage");
	}
}