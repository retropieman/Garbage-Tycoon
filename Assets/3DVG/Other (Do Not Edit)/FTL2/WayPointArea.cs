using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointArea : MonoBehaviour {

	public bool playerCanCross = false;

	void OnTriggerEnter(Collider col){
		if (col.tag == "MovingPlatform") {
			playerCanCross = true;
		}
	}
}
