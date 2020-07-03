using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TexturingFTL : MonoBehaviour {

	//Villager 1
	public Animator v1Anim;
	public GameObject farmerDirt;
	public GameObject crops;
	public GameObject deadCrops;

	public Material dirtMat;

	//Villager 2
	public Animator v2Anim;
	public Material crateMat;
	public Texture crateTexture;

	//Villager 3
	public Animator v3Anim;
	public GameObject villager3Home;
	int colorChecker = 1;
	int differentColors;

	//Villager 4
	public Animator v4Anim;
	public Material iceSculptureMat;

	//Villager 5
	public Animator v5Anim;
	public GameObject villager5Mountain;
	public Material shinyMat;

	// Use this for initialization
	void Start () {

		v1Anim.SetBool ("Fixed", false);
		v2Anim.SetBool ("Fixed", false);
		v3Anim.SetBool ("Fixed", false);
		v4Anim.SetBool ("Fixed", false);
		v5Anim.SetBool ("Fixed", false);
		differentColors = 0;

		shinyMat = villager5Mountain.GetComponent<MeshRenderer> ().sharedMaterial;

		for (var i = 0; i < villager3Home.GetComponent<MeshRenderer> ().sharedMaterials.Length; i++) {
			while(colorChecker < 6) {
				if (villager3Home.GetComponent<MeshRenderer> ().sharedMaterials [i] == villager3Home.GetComponent<MeshRenderer> ().sharedMaterials [colorChecker]) {
					return;
				} else {
					colorChecker++;
				}
			}
			colorChecker = i + 2;
			differentColors++;
		}

	}
	
	// Update is called once per frame
	void Update () {

		if (farmerDirt.GetComponent<MeshRenderer>().sharedMaterial == dirtMat) {
			v1Anim.SetBool ("Fixed", true);
			deadCrops.transform.position = new Vector3 (0, -5, 0);
			crops.transform.position = new Vector3 (0, 0, 0);
		}

		if (crateMat.mainTexture == crateTexture) {
			v2Anim.SetBool ("Fixed", true);
		}

		if (differentColors == 6) {
			v3Anim.SetBool ("Fixed", true);
		}

		if (iceSculptureMat.GetFloat("_Mode") == 3f && iceSculptureMat.color.a <= 100f) {
			v4Anim.SetBool ("Fixed", true);
		}

		if (shinyMat.name == "Shiny Mountain" && shinyMat.GetFloat ("_Metallic") >= 0.7f && shinyMat.GetFloat ("_Glossiness") >= 0.7f) {
			v5Anim.SetBool ("Fixed", true);
		}
	}
}
