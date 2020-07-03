using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsFTL : MonoBehaviour {
	//Villager 1
	public Animator v1Anim;
	GameObject backgroundMusic;

	//Villager 2
	public Animator v2Anim;
	public GameObject musicBox;

	//Villager 3
	public Animator v3Anim;
	public GameObject doorBell;

	//Villager 4
	public Animator v4Anim;
	public GameObject[] soundMakers;
	public AudioClip[] clips;
	int clipCount;

	//Villager 5
	public Animator v5Anim;
	public GameObject boomBox;
	public GameObject FTL1;
	public GameObject FTL2;
	public GameObject FTL3;
	public GameObject platform;
	public GameObject[] currentVillagers;
	bool hideVillagers;

	// Use this for initialization
	void Start () {

		v1Anim.SetBool ("Fixed", false);
		v2Anim.SetBool ("Fixed", false);
		v3Anim.SetBool ("Fixed", false);
		v4Anim.SetBool ("Fixed", false);
		v5Anim.SetBool ("Fixed", false);

		backgroundMusic = GameObject.FindGameObjectWithTag ("Music");

		clipCount = 0;

		hideVillagers = false;

		if (soundMakers [0].GetComponent<Hazard> ().hitSound == clips [0]) {
			clipCount++;
		}
		if (soundMakers [1].GetComponent<Water> ().splashSound == clips [1]) {
			clipCount++;
		}
		if (soundMakers [2].GetComponent<Coin> ().collectSound == clips [2]) {
			clipCount++;
		}

		if (musicBox.GetComponent<AudioSource> ().volume >= 0.2f) {
			v2Anim.SetBool ("Fixed", true);
		}

	}

	// Update is called once per frame
	void Update () {

		if (v1Anim.GetBool ("Fixed") == true) {
			//asdf;
		}

		if (backgroundMusic.GetComponent<AudioSource> ().clip != null) {
			v1Anim.SetBool ("Fixed", true);
		}

		if (musicBox.GetComponent<AudioSource> ().volume >= 0.2f) {
			musicBox.GetComponent<AudioSource> ().volume = 0.2f;
			v2Anim.SetBool ("Fixed", true);
		}

		if (doorBell.GetComponent<AudioSource> ().loop == false && doorBell.GetComponent<AudioSource> ().playOnAwake == false) {
			v3Anim.SetBool ("Fixed", true);
		}

		if (clipCount == clips.Length) {
			v4Anim.SetBool ("Fixed", true);
		}

		if (boomBox.GetComponent<AudioSource> ().pitch <= 1.0f && boomBox.GetComponent<AudioSource> ().panStereo == 0) {
			v5Anim.SetBool ("Fixed", true);
			FTL1.transform.position = new Vector3 (-36, 98.651f, 47);
			FTL2.transform.position = new Vector3 (-36, 98.651f, 47);
			FTL3.transform.position = new Vector3 (-36, 98.651f, 47);

			platform.SetActive (true);

			if (hideVillagers == false) {
				for (var i = 0; i < currentVillagers.Length; i++) {
					currentVillagers [i].transform.position = new Vector3 (0, -1000, 0);
				}
				hideVillagers = true;
			}
		}
	}
}