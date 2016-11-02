using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tombstone3 : MonoBehaviour {

	private gameMaster gm;

	void Start () {
		gm = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<gameMaster> ();

	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag("Player")) {
			gm.TutorialText3.text = ("Press C to attack and hold V to block");
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.CompareTag ("Player")) {
			gm.TutorialText3.text = (" ");
		}
	}

	void Update () {

	}
}