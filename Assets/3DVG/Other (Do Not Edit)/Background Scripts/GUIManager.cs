using UnityEngine;
using System.Collections;

//ATTACH TO MAIN CAMERA, shows your health and coins
public class GUIManager : MonoBehaviour 
{	
	public GUISkin guiSkin;					//assign the skin for GUI display
	[HideInInspector]
	public int coinsCollected;
	public int enemiesDefeated;
	public int coinsInLevel;
	public int enemiesInLevel;

	private Health health;
	
	//setup, get how many coins are in this level
	void Start()
	{
		coinsInLevel = GameObject.FindGameObjectsWithTag("Coin").Length;
		enemiesInLevel = GameObject.FindGameObjectsWithTag("Enemy").Length;	
		health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
	}
	
	//show current health and how many coins you've collected
	void OnGUI()
	{
		GUI.skin = guiSkin;
		GUILayout.Space(5f);
		
		if(health)
			GUILayout.Label ("Health: " + health.currentHealth);
		if(coinsInLevel > 0)
			GUILayout.Label ("Collectables: " + coinsCollected + " / " + coinsInLevel);
		if(enemiesInLevel > 0)
			GUILayout.Label ("Enemies: " + enemiesDefeated + " / " + enemiesInLevel);
	}
}