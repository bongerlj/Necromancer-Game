using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tombstone8 : MonoBehaviour {

	private gameMaster gm;

	void Start () {
		gm = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<gameMaster> ();

	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag("Player")) {
			gm.TutorialText8.text = ("Blocking attacks drains stamina, which refills when you pick up green crystals\nIf you run out of stamina, you can't block");
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.CompareTag ("Player")) {
			gm.TutorialText8.text = (" ");
		}
	}

	void Update () {

	}
}