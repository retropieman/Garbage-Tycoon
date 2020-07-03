using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneSwapper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Swap the scene
    public void swapScene(string SceneToChangeTo)
    {
        SceneManager.LoadScene(SceneToChangeTo);
    }
}
