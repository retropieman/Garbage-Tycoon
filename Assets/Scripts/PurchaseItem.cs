using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace shopz
{
    public class PurchaseItem : MonoBehaviour
    {
        public GameObject Objecttosell;
        public int price;
        public bool notownedyet;
        public String title;


        // Start is called before the first frame update
        void Start()
        {
            Objecttosell.SetActive(!notownedyet);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public int Buy(int money)
        {
            if (money >= price && notownedyet)
            {
                Objecttosell.SetActive(true);
                notownedyet = false;
                return money - price;

            }
            else
            {
                return -1;
            }
        }
    }
}
