using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GameObject MenuUI;

	void Update() {
	}

	public void Play() {
		Application.LoadLevel (1);
	}

	public void Quit() {
		Application.Quit ();
	}
}