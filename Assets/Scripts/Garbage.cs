using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour
{
    public GameObject Destroyer;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == Destroyer.name || collision.gameObject.name == "Plane")
        {
            Destroy(gameObject);
        }
    }

    
}
