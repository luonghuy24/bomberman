using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Accelerator : NetworkBehaviour {

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Character") {			
			collider.GetComponent<PlayerStats> ().speed += 2;
			NetworkServer.Destroy (this.gameObject);
		}
	}
}
