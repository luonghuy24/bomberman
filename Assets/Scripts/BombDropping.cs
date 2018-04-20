using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDropping : MonoBehaviour {

	[SerializeField]
	private GameObject bombPrefab;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			DropBomb ();
		}
	}

	void DropBomb() {
		//Instantiate (bombPrefab, this.gameObject.transform.position, Quaternion.identity);

		Instantiate(bombPrefab, new Vector3(Mathf.RoundToInt(this.gameObject.transform.position.x), 
			Mathf.RoundToInt(this.gameObject.transform.position.y), this.gameObject.transform.position.z),
			Quaternion.identity);
	}
}
