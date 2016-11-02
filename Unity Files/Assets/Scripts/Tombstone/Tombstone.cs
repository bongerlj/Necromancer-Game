using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tombstone : MonoBehaviour {

	private gameMaster gm;

	void Start () {
		gm = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<gameMaster> ();

	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag("Player")) {
			gm.TutorialText1.text = ("Use the arrow keys to move");
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.CompareTag ("Player")) {
			gm.TutorialText1.text = (" ");
		}
	}

	void Update () {

	}
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                