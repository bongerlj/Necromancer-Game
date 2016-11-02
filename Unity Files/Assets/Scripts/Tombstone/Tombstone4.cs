using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tombstone4 : MonoBehaviour {

	private gameMaster gm;

	void Start () {
		gm = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<gameMaster> ();

	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag("Player")) {
			gm.TutorialText4.text = ("The hearts represent your health for your current life\nThe number beside it shows how many lives you have left");
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.CompareTag ("Player")) {
			gm.TutorialText4.text = (" ");
		}
	}

	void Update () {

	}
}