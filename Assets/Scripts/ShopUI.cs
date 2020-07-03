using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    public GameObject MenuObject;

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        MenuObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenThisScreen(bool opened)
    {
        MenuObject.SetActive(opened);
        if(opened)
        {
            PauseGame();
        }
        else 
        {
            ResumeGame();
        }
    }
    

}
