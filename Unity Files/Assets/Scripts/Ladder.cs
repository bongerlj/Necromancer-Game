using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ladder : MonoBehaviour {

	public int LevelToLoad;
	private gameMaster gm;

	void Start() {
		gm = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<gameMaster> ();
	}

	void OnTriggerEnter2D(Collider2D col) {
		if(col.CompareTag("Player")) {
			gm.promptText.text = ("[E] To Climb");
			if(Input.GetKey("e")) {
				Application.LoadLevel (LevelToLoad);
			}
		}

		//anim.SetBool ("Opening", opening);
	}



	void OnTriggerStay2D(Collider2D col) {
		if(col.CompareTag("Player")) {
			if(Input.GetKey("e")) {
				Application.LoadLevel (LevelToLoad);
			}
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.CompareTag ("Player")) {
			gm.promptText.text = (" ");
		}
	}
}