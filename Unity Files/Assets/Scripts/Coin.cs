using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	private gameMaster gm;

	void Start() {
		gm = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<gameMaster> ();
	}

	void OnTriggerEnter2D(Collider2D col) {
		if(col.CompareTag("Player")) {
			Destroy (gameObject);
			gm.points += 1;
		}
	}
}