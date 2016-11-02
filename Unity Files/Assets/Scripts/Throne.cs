using UnityEngine;
using System.Collections;

public class Throne : MonoBehaviour {

	//references
	public int LevelToLoad; //you can change this in the unity editor, its the scene index of the scene you want to load
						   //you can find it by hitting ctrl+shift+b in the unity editor and selecting "add open scenes"
	private gameMaster gm; //this is what controls all my text that appears in game
	public bool bossAlive = true; //I use this bool because I only want the text to show up when the boss is dead
	private BossAI bossAI; //this is so I can use non static variables and methods from the BossAI script

	// Use this for initialization
	void Start () {
		gm = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<gameMaster> (); //this finds the gamemaster object in my scene and accesses its script
		bossAI = GetComponent<BossAI> (); //assigning the prefix used for accessing variables from the BossAI script
	}
	
	void Update () {
		if(!BossAI.isDead) {
			bossAlive = true; //if boss is not dead, he's alive
		}
		else {
			bossAlive = false; //otherwise he's dead
		}
		
	
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag ("Player") && !bossAlive) { //if the player collides and the boss is not alive dispolay the text
			gm.WinText.text = ("Press [E] to sit on throne"); //this variable is from my game master script
			if (Input.GetKey ("e")) { //if all the above is true and player presses 'e' 
				Application.LoadLevel (LevelToLoad); //load the level with the scene index indicated. This can be changed in the unity editor, or set
			}										 //to a specific value, ie: Application.LoadLevel(0) loads the level with index 0
		}
	}

	//this does the same as the method above, only if the player stays in contact with the throne
	void OnTriggerStay2D(Collider2D col) {
		if(col.CompareTag("Player")) {
			if(Input.GetKey("e")) {
				Application.LoadLevel (LevelToLoad);
			}
		}
	}

	//make sure that when the player is no longer contacting the object, remove the text by displaying an empty screen
	void OnTriggerExit2D(Collider2D col) {
		if (col.CompareTag ("Player")) {
			gm.WinText.text = (" ");
		}
	}

}