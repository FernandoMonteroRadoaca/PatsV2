using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIShopManager : MonoBehaviour
{
    public int totalMoney;
    public int totalObjects;
    private int priceObject;


    [SerializeField] private int moneyTotal = 100;
    [SerializeField] TextMeshProUGUI moneyText;

    [SerializeField] private GameObject inventoryPanel;
    void Start()
    {
        Debug.Log(totalMoney);
        totalMoney = moneyTotal;
        moneyText.text = moneyTotal.ToString();
    }


    public void PriceObject(string price)
    {
        switch(price)
        {
            case "ButtonBone":
                
                priceObject = 5; break;
            case "ButtonFillet":
                
                priceObject = 20; break;
            case "ButtonMeet":
               
                priceObject = 15; break;
            case "ButtonSausage":
               
                priceObject = 10; break;

        }
    }
    public void AdquirObject(string article)
    {
        PriceObject(article);
        LoveBar loveBar = GameObject.FindObjectOfType<LoveBar>();
        if(priceObject <= totalMoney && totalObjects < 5)
        {
            totalObjects++;
            totalMoney -= priceObject;
            moneyText.text = totalMoney.ToString();
            GameObject equipo = (GameObject)Resources.Load(article);
            Instantiate(equipo, Vector3.zero, Quaternion.identity, inventoryPanel.transform);
            
        }

        
    }



    //Save methods//////////////////////////////////////////////////////////////////////////////////////////

   

}
