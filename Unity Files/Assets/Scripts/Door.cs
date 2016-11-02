using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Door : MonoBehaviour {

	public int LevelToLoad;
	private Animator anim;
	public bool opening = false;

	private gameMaster gm;

	void Start() {
		gm = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<gameMaster> ();
		anim = gameObject.GetComponent<Animator> ();
	}

	void OnTriggerEnter2D(Collider2D col) {
		if(col.CompareTag("Player")) {
			opening = true;
			//gameObject.GetComponent<Animation> ().Play ("Door");
			anim.SetBool ("Opening", opening);
			gm.promptText.text = ("[E] To Enter");
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
			//opening = false;
			//gameObject.GetComponent<Animation> ().Play ("Door_Closed");
		}

		//opening = false;
		anim.SetBool ("Opening", !opening);
	}
}