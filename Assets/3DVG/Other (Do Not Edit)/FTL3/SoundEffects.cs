using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour {

	public GameObject myVillager;
	public bool silenceMusic;
	AudioSource myAudio;
	float myVolume;

	// Use this for initialization
	void Awake () {
		myAudio = gameObject.GetComponent<AudioSource> ();
		myVolume = myAudio.volume;
	}
	
	// Update is called once per frame
	void Update () {

		if (myVillager.GetComponent<VillagerSpeechScript> ().triggerTracker >= 1) {
			myAudio.volume = myVolume;
			if (silenceMusic) {
				myVillager.GetComponent<VillagerSpeechScript> ().bgAudio.volume = 0;
			}
		} else {
			myAudio.volume = 0;
			if (silenceMusic) {
				myVillager.GetComponent<VillagerSpeechScript> ().bgAudio.volume = 0.25f;
			}
		}
		
	}
}
