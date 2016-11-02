using UnityEngine;
using System.Collections;

public class Boss_AttackCone : MonoBehaviour {

	public BossAI bossAI;
	public bool isLeft = false;

	void Awake() {
		bossAI = gameObject.GetComponentInParent<BossAI> ();
	}

	void OnTriggerStay2D(Collider2D col) {
		//if object in collider trigger is Player
		if(col.CompareTag("Player")) {
			//if player is in left cone
			if(isLeft) {
				bossAI.Attack (false);
				//gameObject.GetComponent<Animation> ().Play ("Attack_Left"); 
			} else {
				bossAI.Attack (true);
				//gameObject.GetComponent<Animation> ().Play ("Attack_Right"); 
			}
		}
	}


	void Start () {}

	void Update () {}
}
