using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//this is just where I store my text variables you could also hardcode them as onjects in the unity editor or just put them in with the script
//that accesses them if you only have a few you need
public class gameMaster : MonoBehaviour {

	public int points;

	public Text pointsText;
	public Text promptText;
	public Text TutorialText1;
	public Text TutorialText2;
	public Text TutorialText3;
	public Text TutorialText4;
	public Text TutorialText5;
	public Text TutorialText6;
	public Text TutorialText7;
	public Text TutorialText8;
	public Text WinText;

	void Update() {
		//pointsText.text = ("Coins: " + points);
	}
}
