using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tombstone6 : MonoBehaviour {

	private gameMaster gm;

	void Start () {
		gm = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<gameMaster> ();

	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag("Player")) {
			gm.TutorialText6.text = ("The green potions refill your health\nThe orange crystals give you more lives");
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.CompareTag ("Player")) {
			gm.TutorialText6.text = (" ");
		}
	}

	void Update () {

	}
}