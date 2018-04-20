using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BattleMap : NetworkBehaviour {

	[SerializeField]
	private GameObject boxPrefab;

	[SerializeField]
	private GameObject item;


	private List<Vector2> boxPositions;

	// Use this for initialization
	void Start () {
		if (isServer) {

			boxPositions = new List<Vector2>();

			for (int y = 1; y > -8; y = y - 2) {				
				for (int x = -7; x < 6; x = x + 1) {	
					Vector2 p = new Vector2 (x, y);
					boxPositions.Add (p);
				}
			}

			for (int y = 0; y > -7; y = y - 2) {				
				for (int x = -7; x < 6; x = x + 2) {	
					Vector2 p = new Vector2 (x, y);
					boxPositions.Add (p);
				}
			}
				
			for (int i = -5; i < 4; i++) {				
				boxPositions.Add (new Vector2 (i, 3));
				boxPositions.Add (new Vector2 (i, -9));
			}

			for (int i = -5; i < 4; i=i+2) {				
				boxPositions.Add (new Vector2 (i, 2));
				boxPositions.Add (new Vector2 (i, -8));
			}


			CmdGenerateBoxes ();
		} else {
			Debug.Log("I'm the client");
		}
	}
	
	[Command]
	void CmdGenerateBoxes() {
		if (NetworkServer.active) {


			GameObject item = Instantiate(boxPrefab, new Vector3(Mathf.RoundToInt(-6), 
				Mathf.RoundToInt(3), 0),
				Quaternion.identity);
			NetworkServer.Spawn (item);

			for (int i = 0; i < 100; i++) {

				int index = Random.Range (0, boxPositions.Count);

				Vector2 v = boxPositions [index];
			
				GameObject box = Instantiate(boxPrefab, new Vector3(Mathf.RoundToInt(v.x), 
					Mathf.RoundToInt(v.y), 0),
					Quaternion.identity);
				NetworkServer.Spawn (box);

				boxPositions.Remove (v);
			}
		}
	}
}
