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
        public bool Canbesold;
        public String title;


        // Start is called before the first frame update
        void Start()
        {
            Objecttosell.SetActive(!Canbesold);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public int Buy(int money)
        {
            if (money >= price && Canbesold)
            {
                Objecttosell.SetActive(true);
                return money - price;

            }
            else
            {
                return -1;
            }
        }
    }
}
