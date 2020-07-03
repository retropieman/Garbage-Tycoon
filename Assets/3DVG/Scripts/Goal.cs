using UnityEngine;
using UnityEngine.SceneManagement;

//add this to your "level goal" trigger
[RequireComponent(typeof(CapsuleCollider))]
public class Goal : MonoBehaviour 
{
	public float loadDelay;			//how long player must stay inside the goal, before the game moves onto the next level
	public string nextLevel;		//scene index of the next level

	public bool defeatEnemies;
	public bool collectCollectables;

	GameObject mainCam;



	private float counter;
	
	void Awake()
	{
		GetComponent<Collider>().isTrigger = true;
		mainCam = GameObject.FindGameObjectWithTag ("MainCamera");
		gameObject.GetComponent<Renderer> ().enabled = false;
		gameObject.GetComponent<Collider> ().enabled = false;
	}

	void Update(){
		if (defeatEnemies || collectCollectables) {
			if (defeatEnemies && collectCollectables) {
				if (mainCam.GetComponent<GUIManager> ().enemiesDefeated == mainCam.GetComponent<GUIManager> ().enemiesInLevel && mainCam.GetComponent<GUIManager> ().coinsCollected == mainCam.GetComponent<GUIManager> ().coinsInLevel) {
					gameObject.GetComponent<Renderer> ().enabled = true;
					gameObject.GetComponent<Collider> ().enabled = true;
				}
			} else {
				if (defeatEnemies) {
					if (mainCam.GetComponent<GUIManager> ().enemiesDefeated == mainCam.GetComponent<GUIManager> ().enemiesInLevel) {
						gameObject.GetComponent<Renderer> ().enabled = true;
						gameObject.GetComponent<Collider> ().enabled = true;
					}
				}
				if (collectCollectables) {
					if (mainCam.GetComponent<GUIManager> ().coinsCollected == mainCam.GetComponent<GUIManager> ().coinsInLevel) {
						gameObject.GetComponent<Renderer> ().enabled = true;
						gameObject.GetComponent<Collider> ().enabled = true;
					}
				}
			}
		} else {
			gameObject.GetComponent<Renderer> ().enabled = true;
			gameObject.GetComponent<Collider> ().enabled = true;
		}
	}
	
	//when player is inside trigger for enough time, load next level
	//also lift player upwards, to give the goal a magical sense
	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player") {
			counter += Time.deltaTime;
			if (counter > loadDelay && nextLevel != ""){
				SceneManager.LoadScene (nextLevel, LoadSceneMode.Single);
			}
		}
	}
	
	//if player leaves trigger, reset "how long they need to stay inside trigger for level to advance" timer
	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
			counter = 0f;
	}
}