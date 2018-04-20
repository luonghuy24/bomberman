using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Skull : NetworkBehaviour {

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Character") {		
		
			int i = Random.Range (0, 2);

			if (i == 0) {
				collider.GetComponent<PlayerStats> ().speed = 3;
			} 

			if (i == 1) {
				collider.GetComponent<PlayerStats> ().maxBomb =1;
			}

			if (i == 2) {
				collider.GetComponent<PlayerStats> ().explosionRange = 2;
			}

			NetworkServer.Destroy (this.gameObject);
		}
	}
}
