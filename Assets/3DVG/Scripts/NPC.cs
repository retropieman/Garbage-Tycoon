#pragma warning disable 0414

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

	Animator anim;

	//Animation Conditions
	public bool clap;
	public bool dance;
	public bool cry;
	public bool talk;
	public bool wave;
	public bool headShake;
	public bool headNod;
	public bool jump;
	int boolCount;

	//Supplement variables
	bool functionComplete = false;
	string animationName;
	bool hasObjective = false;
	[HideInInspector]
	public GameObject objective;
	[HideInInspector]
	public string objectiveText;

	//Speech Options
	public GUISkin guiSkin;
	public string talkText;
	public bool noAnimation = false;
	bool isTalking;
	float textWidth;
	float textHeight;
	float textHeightOffset;

	void Awake(){

		if (objective != null) {
			hasObjective = true;
		}

		if (noAnimation == false) {
			anim = gameObject.GetComponent<Animator> ();

			if (clap) {
				anim.SetBool ("Clap", true);
				animationName = "Clap";
				boolCount++;
			}
			if (dance) {
				anim.SetBool ("Dance", true);
				animationName = "Dance";
				boolCount++;
			}
			if (cry) {
				anim.SetBool ("Cry", true);
				animationName = "Cry";
				boolCount++;
			}
			if (talk) {
				anim.SetBool ("Talk", true);
				animationName = "Talk";
				boolCount++;
			}
			if (wave) {
				anim.SetBool ("Wave", true);
				animationName = "Wave";
				boolCount++;
			}
			if (headShake) {
				anim.SetBool ("Head Shake", true);
				animationName = "Head Shake";
				boolCount++;
			}
			if (headNod) {
				anim.SetBool ("Head Nod", true);
				animationName = "Head Nod";
				boolCount++;
			}
			if (jump) {
				anim.SetBool ("Jump", true);
				animationName = "Jump";
				boolCount++;
			}
		}
	}

	// Use this for initialization
	void Start () {
		if (boolCount > 1) {
			DebugBreak ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		textWidth = (Screen.width / 50);
		textHeight = (0.75f * Screen.height);
		textHeightOffset = (Screen.height / 30);
	}

	void OnTriggerEnter (Collider col){
		if (col.gameObject.tag == "Player") {
			isTalking = true;

			//Write your if statement here

		}
	}


	//Write your function here


	void OnTriggerExit (Collider col){
		if (col.gameObject.tag == "Player") {
			isTalking = false;
		}
	}

	void DebugBreak () {
		Debug.LogError ("NPC (Script) Settings: There are too many animation types selected. You must have only one selected.");
		Debug.Break ();
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

		if (isTalking) {
			if (functionComplete == false) {
				GUI.Box (new Rect (0 + textWidth, 0 + textHeight, Screen.width - (2 * textWidth), Screen.height - (textHeight + textHeightOffset)), talkText);
			} else {
				GUI.Box (new Rect (0 + textWidth, 0 + textHeight, Screen.width - (2 * textWidth), Screen.height - (textHeight + textHeightOffset)), objectiveText);
			}
		}
	}
}
