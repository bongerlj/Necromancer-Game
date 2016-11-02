using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public GameObject PauseUI;

	private bool paused = false;

	void Start() {
		PauseUI.SetActive (false);
	}

	void Update() {
		if (Input.GetButtonDown ("Pause")) {
			//toggles the pause UI
			paused = !paused;
		}
		//if paused, make menu active, stop time
		if (paused) {
			PauseUI.SetActive (true);
			Time.timeScale = 0;
		}
		//if not paused, deactivate menu, resume game
		if (!paused) {
			PauseUI.SetActive (false);
			Time.timeScale = 1;
		}
	}

	public void Resume() {
		paused = false;
	}

	//loads current level
	public void Restart() {
		Application.LoadLevel (1);	
	}

	//loads scene in brackets, restarts level for now
	public void MainMenu() {
		Application.LoadLevel (0);
	}

	public void Quit() {
		Application.Quit ();
	}
}