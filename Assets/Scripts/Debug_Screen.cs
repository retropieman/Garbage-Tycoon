using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_Screen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Output the current screen window size in the console
        Debug.Log("Screen Height : " + Screen.height);
        Debug.Log("Screen Width : " + Screen.width);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
