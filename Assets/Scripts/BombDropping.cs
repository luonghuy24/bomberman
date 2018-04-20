using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BombDropping : NetworkBehaviour {

	[SerializeField]
	private GameObject bombPrefab;


	private GameObject playerStats;
	// Update is called once per frame

	void Start(){
		
	}

	void Update () {
		if (this.isLocalPlayer && Input.GetKeyDown ("space")) {
			if (GetComponent<PlayerStats> ().currentBomb < GetComponent<PlayerStats> ().maxBomb) {
				GetComponent<PlayerStats> ().currentBomb += 1;
				CmdDropBomb ();
			}
		}
	}


	[Command]
	void CmdDropBomb() {
		if (NetworkServer.active) {
			GameObject bomb = Instantiate(bombPrefab, new Vector3(Mathf.RoundToInt(this.gameObject.transform.position.x), 
				Mathf.RoundToInt(this.gameObject.transform.position.y), this.gameObject.transform.position.z),
				Quaternion.identity);
			bomb.GetComponent<BombExplosion> ().explosionRange = GetComponent<PlayerStats> ().explosionRange;
			bomb.GetComponent<BombExplosion> ().player = this.gameObject;
			NetworkServer.Spawn (bomb);
		}
	}
}
