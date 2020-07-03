using UnityEngine;
using System.Collections;

public class FlipPad : MonoBehaviour {

	private Animator ani;

	public bool state = false;

	public bool delayedStart = false;

	public float delayTime = 0;

	public float flipTime = 4;

	private float timer;

	// Use this for initialization
	void Start () {
		ani = gameObject.GetComponent<Animator> ();
		state = false;
		timer = 0;
		if (delayTime > 0) {
			delayedStart = true;
		} else {
			delayedStart = false;
		}
	}
	
	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;
		if (timer >= delayTime && delayedStart == true) {
			timer = 0;
			delayedStart = false;
			ani.SetBool ("flip1", true);
			state = true;
		}

		if (timer >= flipTime && delayedStart == false) {
			if (state == false) {
				timer = 0;
				ani.SetBool ("flip1", true);
				state = true;
			}
			else if (state == true) {
				timer = 0;
				ani.SetBool ("flip1", false);
				state = false;
			}
		}

	}
}
