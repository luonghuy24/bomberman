using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BattleMap : NetworkBehaviour {

	[SerializeField]
	private GameObject boxPrefab;

	// Use this for initialization
	void Start () {
		if (isServer) {
			CmdGenerateBoxes ();
		} else {
			Debug.Log("I'm the client");
		}
	}
	
	[Command]
	void CmdGenerateBoxes() {
		if (NetworkServer.active) {
			GameObject box = Instantiate(boxPrefab, new Vector3(Mathf.RoundToInt(1), 
				Mathf.RoundToInt(2), 0),
				Quaternion.identity);
			NetworkServer.Spawn (box);

			GameObject box1 = Instantiate(boxPrefab, new Vector3(Mathf.RoundToInt(1), 
				Mathf.RoundToInt(-2), 0),
				Quaternion.identity);
			NetworkServer.Spawn (box1);
		}
	}
}
