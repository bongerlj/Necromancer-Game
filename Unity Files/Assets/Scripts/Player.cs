using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	//floats
	public float speed = 50f;
	public float maxSpeed = 3f;
	public float jumpPower = 500f;
	public float lastGroundedPosition;
	public static float playerPower = 1.0f;
	public static float deathPenalty = 0.0f;

	//bools
	public bool grounded;
	public bool canDoubleJump;
	public bool blocking = false;
	public bool onIce = false;
	private bool playFootsteps = false;

	//ints
	public static int currentHealth = 5;
	public static int currentStamina = 10;
	public int maxHealth;
	public int maxStamina;
	public int LevelToLoad;
	public static int damageModifier = 0;
	public static int livesRemaining = 3;
	public static int deathCount = 0;
	//public int carwait = 1;


	//references
	private Rigidbody2D rb2d;
	private Animator anim;
	private gameMaster gm;
	public AudioSource footstep_wood;
	public AudioSource jump;
	public AudioSource player_hit;

	// Use this for initialization
	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();

		jump.GetComponent<AudioSource>().volume = 0.0f;
		player_hit.GetComponent<AudioSource>().volume = 0.0f;

		currentHealth = currentHealth;
		currentStamina = currentStamina;
		//gm = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<gameMaster> ();
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag ("Ice")) {
			onIce = true;
		}
	}

	void onTriggerExit2D(Collider2D col) {
		if (col.CompareTag("Ice")) {
			onIce = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		//set animation conditions to variables in the script
		anim.SetBool ("Grounded", grounded);
		anim.SetFloat ("Speed", Mathf.Abs (rb2d.velocity.x));
		anim.SetBool ("Blocking", blocking);

		//flip character so he's facing the right way
		if (Input.GetAxis ("Horizontal") < -0.1f) {
			//footstep_wood.Play ();
			transform.localScale = new Vector3 (-1, 1, 1);
		}

		if (Input.GetAxis ("Horizontal") > 0.1f) {
			//footstep_wood.Play ();
			transform.localScale = new Vector3 (1, 1, 1);
		}

		/*if(rb2d.velocity.x >= 0.1|| rb2d.velocity.x <= -0.1) {
			if (grounded) {
				footstep_wood.loop = true;
				footstep_wood.GetComponent<AudioSource>().volume = 0.0f;
				footstep_wood.Play ();
			}


		}
		else {
			footstep_wood.GetComponent<AudioSource>().volume = 1.0f;
			footstep_wood.Play ();
		}*/

		//if (!gameObject.GetComponent<playerAttack>().attacking)

		if (Input.GetKey("v") && !gameObject.GetComponent<playerAttack>().attacking && grounded && currentStamina > 0) {
			blocking = true;
			//speed = 25f * playerPower;
			speed = 25f - deathPenalty;
			//gameObject.GetComponent<Animation> ().Play ("Player_Block"); //play damage animation
		}
		else {
			blocking = false;
			//speed = 50.0f * playerPower;
			speed = 50f /*- deathPenalty*/;
		}

		if (grounded) {
			lastGroundedPosition = transform.position.y;
		}

		//if grounded and press space, player jumps
		if (Input.GetButtonDown ("Jump") && !onIce) {
			if (grounded) {
				jump.GetComponent<AudioSource>().volume = 0.25f;
				jump.Play ();
				rb2d.AddForce (Vector2.up * jumpPower);
				canDoubleJump = true;
			} else {
				if (canDoubleJump) {
					canDoubleJump = false;
					jump.GetComponent<AudioSource>().volume = 0.25f;
					jump.Play ();
					rb2d.velocity = new Vector2 (rb2d.velocity.x, 0);
					rb2d.AddForce (Vector2.up * jumpPower / 1.75f);
				}
			}
		}

		//make sure current health can't exceed max health
		if (currentHealth > maxHealth) {
			currentHealth = maxHealth;
		}

		if (currentStamina > maxStamina) {
			currentStamina = maxStamina;
		}

		//if current health is 0, kill player
		if (currentHealth <= 0) {
			//deathCount++;
			livesRemaining--;
			print ("Lives: " + livesRemaining);
			currentHealth = maxHealth;
			currentStamina = maxStamina;
			//playerPower -= 0.2f;
			//speed = speed * playerPower;
			//maxSpeed = maxSpeed * playerPower;
			//jumpPower = jumpPower * playerPower;
			//deathPenalty += 5;
			//speed = speed - deathPenalty;
			//maxSpeed = maxSpeed - (deathPenalty/15);
			//print ("Deaths: " + deathCount);
			//print ("Power Level: " + playerPower);
			//print ("Speed: " + speed);
			//print ("Max Speed: " + maxSpeed);
			//print ("Jump Power: " + jumpPower);
			Die ();
		}

		if(livesRemaining <= 0) {
			Application.LoadLevel (10);
		}

		if(livesRemaining == 3) {
			damageModifier = 0;
			//print (damageModifier);
		}

		if(livesRemaining == 2) {
			damageModifier = 10;
			//print (damageModifier);
		}

		if(livesRemaining == 1) {
			damageModifier = 40;
			//print (damageModifier);
		}			
	}

	void FixedUpdate() {
		float h = Input.GetAxis ("Horizontal");

		Vector3 easeVelocity = rb2d.velocity; //ease velocity = current velocity
		easeVelocity.y = rb2d.velocity.y; //y component = current velocity so doesn't affect  vertical movement
		easeVelocity.z = 0.0f; //don't need to worry about 3rd dimension
		easeVelocity.x *= 0.75f; //reduce x velocity to compensate for no friction
		//gameObject.GetComponent<Slip>().onIce;

		Vector3 easeVelocityIce = rb2d.velocity;
		easeVelocityIce.y = rb2d.velocity.y;
		easeVelocityIce.z = 0.0f;
		easeVelocityIce.x *= 1.5f;

		//fake friction to ease x speed of player
		if (grounded && !onIce) {
			rb2d.velocity = easeVelocity;
		}

		if(grounded && onIce) {
			rb2d.velocity = easeVelocityIce;
		}

		else {
			rb2d.velocity = easeVelocity;
		}

		if(Input.GetKey("left") || Input.GetKey("right")) {
			rb2d.AddForce ((Vector2.right * speed) * h);
			playFootsteps = true;
			if (grounded /*&& playFootsteps*/) {
				//footstep_wood.pitch = Time.timeScale = 0.5f;
				//footstep_wood.Play ();
				//StartCoroutine(PlaySteps());
				//playFootsteps = false;
				//InvokeRepeating ("PlaySteps", 0.001f, 2f);
			}

		}
		else {
			playFootsteps = false;
		}

		//move the player horizontally when arrow keys are pressed
		//rb2d.AddForce ((Vector2.right * speed) * h);
		//footstep_wood.Play ();

		//limits speed in the right direction (positive)
		if (rb2d.velocity.x > maxSpeed) {
			rb2d.velocity = new Vector2 (maxSpeed, rb2d.velocity.y);
		}

		//limits speed in the left direction (negative)
		if (rb2d.velocity.x < -maxSpeed) {
			rb2d.velocity = new Vector2 (-maxSpeed, rb2d.velocity.y);
		}
}

	void Die() {
		//Application.LoadLevel (Application.loadedLevel);

		//Application.LoadLevel ("scene2");
		Application.LoadLevel (Application.loadedLevel);
		/*deathCount++;
		print (deathCount);*/
	}

	//damage function, subtracts int dmg from currentHealth
	public void Damage(int dmg) {
		player_hit.GetComponent<AudioSource>().volume = 0.05f;
		player_hit.Play ();
		currentHealth -= dmg;
		gameObject.GetComponent<Animation> ().Play ("Player_Damage"); //play damage animation
	}

	public void gainHealth(int gain) {
		currentHealth += gain;
	}

	//knockback function for heavy attacks and traps
	public IEnumerator Knockback(float knockBackTime, float knockBackPower, Vector3 knockBackDirection) {
		
		float timer = 0; //initialize timer

		while (knockBackTime > timer) {
			//for every frame where knockBackTimer is larger than timer, increment timer until the knockBackTime = timer
			timer += Time.deltaTime;
			//knockback horizontally in opposite direction of travel, vertically proportional to knockBackPower
			rb2d.AddForce (new Vector3 (knockBackDirection.x * -100, knockBackDirection.y * knockBackPower, transform.position.z));
		}

		//when above condition isn't true, stop loop
		yield return 0;
	}

	public IEnumerator ProjectileKnockback(float knockBackTime, float knockBackPower, Vector2 knockBackDirection) {

		float timer = 0; //initialize timer

		while (knockBackTime > timer) {
			//for every frame where knockBackTimer is larger than timer, increment timer until the knockBackTime = timer
			timer += Time.deltaTime;
			//knockback horizontally in opposite direction of travel, vertically proportional to knockBackPower
			rb2d.AddForce (new Vector2 (knockBackDirection.x * -100, knockBackDirection.y * knockBackPower));
		}

		//when above condition isn't true, stop loop
		yield return 0;
	}

	/*void PlaySteps() {
		if (playFootsteps) {
			footstep_wood.Play ();
		}

	}*/

	/*public IEnumerator PlaySteps() {
		while (playFootsteps) {
			audio.PlayOneShot (footstep_wood);
			yield return new WaitForSeconds (carwait);
		}
	}*/

	/*public IEnumerator DamageSpecial(float dmgTimer, int dmg) {
		float timer = 0;

		while (dmgTimer > timer) {
			timer += Time.deltaTime;
			Damage (dmg);
		}
		yield return 0;
	}*/

	/*void OnTriggerEnter2D(Collider2D col) {
		if(col.CompareTag("Coin")) {
			Destroy (col.gameObject);
			gm.points += 1;
			currentHealth += 1;
		}
	}*/
}