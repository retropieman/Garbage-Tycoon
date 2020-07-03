using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveScript : MonoBehaviour {

	public GameObject cavePrefab = null;
	GameObject currentHouse;
	GameObject[] houseSpots;
	Vector3 caveSpot;


	void Awake (){
		//caveHouse = gameObject;
		houseSpots = GameObject.FindGameObjectsWithTag ("CaveHouse");

		if (cavePrefab != null) {
			gameObject.tag = "HouseBuilder";

			for (var i = 0; i < houseSpots.Length; i++) {
				currentHouse = houseSpots [i];
				GameObject newCave = (GameObject)Instantiate (cavePrefab, currentHouse.transform);
				for (var k = 0; k < newCave.GetComponent<MeshRenderer> ().materials.Length; k++) {
					newCave.GetComponent<MeshRenderer> ().materials [k].color = new Color (Random.value, Random.value, Random.value, 1f);
				}
			}
		}
	}

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}
}
