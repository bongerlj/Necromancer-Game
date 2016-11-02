using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tombstone5 : MonoBehaviour {

	private gameMaster gm;

	void Start () {
		gm = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<gameMaster> ();

	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag("Player")) {
			gm.TutorialText5.text = ("Pickups contain magical energy that augment the power of the enchantment\nWalk over them to pick them up");
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.CompareTag ("Player")) {
			gm.TutorialText5.text = (" ");
		}
	}

	void Update () {

	}
}