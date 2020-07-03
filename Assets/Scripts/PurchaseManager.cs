using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using shopz;

using UnityEngine.UI;
using TMPro;
using dangit;

namespace storez {
    public class PurchaseManager : MonoBehaviour
    {
        public int balance;
        public GameObject tScore;
    
        public bool isControl;

    
    

        // Start is called before the first frame update
        void Start()
        {
            tScore.GetComponent<TMPro.TextMeshProUGUI>().text = "$" + balance.ToString();
            if(balance < -1)
            {
                balance = 0;
            }
        
        }

        
        public void UpScore()
        {
            tScore.GetComponent<TMPro.TextMeshProUGUI>().text = "$" + balance.ToString();
        }

        public void BuyItem(GameObject ShopBtn)
        {
            
            GameObject tSell = ShopBtn.GetComponent<dangit.ShopBuy>().toSell;
            if (balance >= tSell.GetComponent<shopz.PurchaseItem>().price)
            {
                balance = tSell.GetComponent<shopz.PurchaseItem>().Buy(balance);
                UpScore();
                ShopBtn.SetActive(false);
            }
        

        }

        public void addScore(int score)
        {
            balance += score;
        }
        
        


    }
}
