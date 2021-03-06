﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ExplosionExpander : NetworkBehaviour {

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Character") {			
			collider.GetComponent<PlayerStats> ().explosionRange +=1;
			NetworkServer.Destroy (this.gameObject);
		}
	}
}
