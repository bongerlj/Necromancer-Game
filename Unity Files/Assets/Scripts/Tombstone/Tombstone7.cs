using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tombstone7 : MonoBehaviour {

	private gameMaster gm;

	void Start () {
		gm = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<gameMaster> ();

	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag("Player")) {
			gm.TutorialText7.text = ("The fewer lives you have the more damage you deal\nBalance your lives and damage modifier carefully");
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.CompareTag ("Player")) {
			gm.TutorialText7.text = (" ");
		}
	}

	void Update () {

	}
}