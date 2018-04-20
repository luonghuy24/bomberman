using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ExtraBomb : NetworkBehaviour {

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Character") {			
			collider.GetComponent<PlayerStats> ().maxBomb +=1;
			NetworkServer.Destroy (this.gameObject);
		}
	}
}
