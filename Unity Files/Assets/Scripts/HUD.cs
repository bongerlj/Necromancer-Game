using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

	public Sprite[] HeartSprites;
	public Sprite[] StaminaSprites;

	public Image HeartUI;
	public Image StaminaUI;
	private Player player;

	void Start() {
		//get player script
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}

	void Update() {
		HeartUI.sprite = HeartSprites[Player.currentHealth];
		StaminaUI.sprite = StaminaSprites [Player.currentStamina];
	}


}