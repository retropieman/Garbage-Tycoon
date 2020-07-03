using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using storez;
using UnityEngine.UI;
using TMPro;

public class Clicker : MonoBehaviour
{
    public GameObject mainscores;
    public GameObject tScore;
    public GameObject prefab;


    void OnMouseDown()
    {

        mainscores.GetComponent<storez.PurchaseManager>().addScore(1);
        mainscores.GetComponent<storez.PurchaseManager>().UpScore();
        Instantiate(prefab, new Vector3(18.68f, 5.646f, 498.42f), Quaternion.identity);

    }


}
