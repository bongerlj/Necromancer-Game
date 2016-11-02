using UnityEngine;
using System.Collections;

public class Magic_Projectile : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		//!= trigger because otherwise the collision with the firing cones would affect it
		if(col.isTrigger != true) {
			//if it collides with Player
			if(col.CompareTag("Player")) {
				//deal 1 damage
				col.GetComponent<Player> ().Damage (1);
				//projectile dissapears after collision
				Destroy (gameObject);
			}

		}
	}

}