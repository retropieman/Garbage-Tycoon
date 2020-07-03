using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerSpeechScript : MonoBehaviour {

	public string problemText;
	public string fixedText;
	float textWidth;
	float textHeight;
	float textHeightOffset;

	GameObject backgroundMusic;
	public AudioSource bgAudio;

	public Animator villagerAnim;
	public int triggerTracker;

	public GUISkin guiSkin;

	// Use this for initialization
	void Start () {
		if (villagerAnim == null) {
			villagerAnim = gameObject.GetComponent<Animator> ();
		}

		backgroundMusic = GameObject.FindGameObjectWithTag ("Music");
		bgAudio = backgroundMusic.GetComponent<AudioSource> ();
		triggerTracker = 0;
	}
	
	// Update is called once per frame
	void Update () {
		textWidth = (Screen.width / 50);
		textHeight = (0.75f * Screen.height);
		textHeightOffset = (Screen.height / 30);

		if (triggerTracker > 0 && villagerAnim.GetBool ("Fixed") == false) {
			bgAudio.pitch = 0.6f;
		}

		//Debug.Log (new Vector3 (textWidth, textHeight, textHeightOffset));
	}

	void OnTriggerEnter (Collider col){
		if (col.gameObject.tag == "Player") {
			triggerTracker++;
		}
	}

	void OnTriggerExit (Collider col){
		if (col.gameObject.tag == "Player") {
			triggerTracker--;
			NormalizeMusic ();
		}
	}

	void NormalizeMusic(){
		if (triggerTracker == 0) {
			bgAudio.pitch = 1f;
		}
	}

	void OnGUI(){
		GUI.skin = guiSkin;
		GUI.skin.box = guiSkin.box;
		if (textWidth < 22f || textHeight < 365f) {
			if (textWidth < 16f || textHeight < 284.5f) {
				if (textWidth < 10f || textHeight < 203f) {
					GUI.skin.box.fontSize = 15;
				} else {
					GUI.skin.box.fontSize = 18;
				}
			} else {
				GUI.skin.box.fontSize = 20;
			}
		} else {
			GUI.skin.box.fontSize = 25;
		}

		if (villagerAnim.GetBool ("Fixed") == false && triggerTracker == 2) {
			GUI.Box (new Rect (0 + textWidth, 0 + textHeight, Screen.width - (2 * textWidth), Screen.height - (textHeight + textHeightOffset)), problemText);
		} else if (triggerTracker == 2) {
			GUI.Box (new Rect (0 + textWidth, 0 + textHeight, Screen.width - (2 * textWidth), Screen.height - (textHeight + textHeightOffset)), fixedText);
		} else {
		}
	}
}
