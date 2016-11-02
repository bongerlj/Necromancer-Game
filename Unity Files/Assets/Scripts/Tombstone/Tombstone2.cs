using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tombstone2 : MonoBehaviour {

	private gameMaster gm;

	void Start () {
		gm = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<gameMaster> ();

	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag("Player")) {
			gm.TutorialText2.text = ("Press SPACE to jump, press it in midair to double jump");
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.CompareTag ("Player")) {
			gm.TutorialText2.text = (" ");
		}
	}

	void Update () {

	}
}