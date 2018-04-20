using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BombDropping : NetworkBehaviour {

	[SerializeField]
	private GameObject bombPrefab;

	// Update is called once per frame
	void Update () {
		if (this.isLocalPlayer && Input.GetKeyDown ("space")) {
			CmdDropBomb ();
		}
	}


	[Command]
	void CmdDropBomb() {
		if (NetworkServer.active) {
			GameObject bomb = Instantiate(bombPrefab, new Vector3(Mathf.RoundToInt(this.gameObject.transform.position.x), 
				Mathf.RoundToInt(this.gameObject.transform.position.y), this.gameObject.transform.position.z),
				Quaternion.identity);
			NetworkServer.Spawn (bomb);
		}
	}
}
