using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabsFTL : MonoBehaviour {
	//Villager 1
	public Animator v1Anim;
	public GameObject villager1;
	public GameObject[] bouncePads;
	public GameObject crossPad;
	public float upDown;
	int padCount;
	public Material fixedMat;

	//Villager 2
	public Animator v2Anim;
	public GameObject checkPoint;

	//Villager 3
	public Animator v3Anim;
	public GameObject villager3;
	public GameObject wayPointArea;

	//Villager 4
	public Animator v4Anim;
	public GameObject hotTubLava;

	//Villager 5
	public Animator v5Anim;
	public GameObject houseBuilder = null;

	// Use this for initialization
	void Start () {

		v1Anim.SetBool ("Fixed", false);
		v2Anim.SetBool ("Fixed", false);
		v3Anim.SetBool ("Fixed", false);
		v4Anim.SetBool ("Fixed", false);
		v5Anim.SetBool ("Fixed", false);

		houseBuilder = GameObject.FindGameObjectWithTag ("HouseBuilder");

		padCount = 0;

		for (var i = 0; i < bouncePads.Length; i++) {
			if (bouncePads [i].GetComponent<Hazard> () != null) {
				padCount++;
				bouncePads [i].GetComponent<MeshRenderer> ().material = fixedMat;
			} else {
				return;
			}
		}
	}

	// Update is called once per frame
	void Update () {

		if (padCount == 3) {
			villager1.transform.position = new Vector3 (10, (1 + Mathf.PingPong((upDown*Time.time), 7)), 6.2f);
			v1Anim.SetBool ("Fixed", true);
			crossPad.transform.position = new Vector3 (-6.03f, 0, 54.4f);
		}

		if (checkPoint.tag == "Respawn") {
			v2Anim.SetBool ("Fixed", true);
		}

		if (wayPointArea.GetComponent<WayPointArea>().playerCanCross == true) {
			villager3.transform.position = new Vector3 (-99, 0.254f, -37);
			v3Anim.SetBool ("Fixed", true);
		}

		if (hotTubLava.GetComponent<Hazard>().damage == 0 && hotTubLava.GetComponent<Hazard>().pushHeight == 0 && hotTubLava.GetComponent<Hazard>().pushForce == 0) {
			v4Anim.SetBool ("Fixed", true);
		}

		if (houseBuilder != null) {
			v5Anim.SetBool ("Fixed", true);
		}
	}
}
