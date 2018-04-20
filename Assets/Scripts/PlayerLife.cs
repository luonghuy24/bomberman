using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour {

	[SerializeField]
	private int numberOfLives = 3;

	[SerializeField]
	private float invulnerabilityDuration = 2;

	private bool isInvulnerable = false;

	public void LoseLife() {
		if (!this.isInvulnerable) {
			this.numberOfLives--;
			if (this.numberOfLives == 0) {
				Destroy (this.gameObject);
			}
			this.isInvulnerable = true;
			Invoke ("BecomeVulnerable", this.invulnerabilityDuration); 
		}
	}

	private void BecomeVulnerable() {
		this.isInvulnerable = false;
	}
}
