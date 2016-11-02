using UnityEngine;
using System.Collections;

public class Necro_AttackCone : MonoBehaviour {

	public NecromancerAI necromancerAI;

	//used to check if player is in right or left attack area
	public bool isLeft = false;

	void Awake() {
		necromancerAI = gameObject.GetComponentInParent<NecromancerAI> ();
	}

	void OnTriggerStay2D(Collider2D col) {
		//if object in collider trigger is Player
		if(col.CompareTag("Player")) {
			//if player is in left cone
			if(isLeft) {
				necromancerAI.Attack (false);
				//gameObject.GetComponent<Animation> ().Play ("Attack_Left"); 
			} else {
				necromancerAI.Attack (true);
				//gameObject.GetComponent<Animation> ().Play ("Attack_Right"); 
			}
		}
	}

	void Start () {}

	void Update () {}
}