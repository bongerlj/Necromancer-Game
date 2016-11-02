using UnityEngine;
using System.Collections;

public class Secret : MonoBehaviour {

	public int currentHealth;
	public int maxHealth;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
	
	}
	
	// Update is called once per frame
	void Update () {

		if(currentHealth <= 0) {
			Destroy (gameObject);
		}
	
	}

	public void Damage(int damage) {
		currentHealth -= (damage + Player.damageModifier);
		gameObject.GetComponent<Animation> ().Play ("Player_Damage");
	}
}
