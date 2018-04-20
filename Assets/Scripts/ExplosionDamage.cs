using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ExplosionDamage : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Character") {
			collider.gameObject.GetComponent<PlayerLife> ().LoseLife ();
		} else if (collider.tag == "Bomb") {
			collider.gameObject.GetComponent<BombExplosion> ().CmdExplode ();
		}
	}
}