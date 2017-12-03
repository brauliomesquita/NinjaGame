using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColectSkull : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == "Player") {
			Destroy (gameObject);
		}
	}
}
