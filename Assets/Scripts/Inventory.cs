using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{


    [SerializeField] private int moneyTotal = 50;
    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] TextMeshProUGUI moneyText2;
    [SerializeField] GameObject inventoryObject;


    private int numMaxObjects = 0;
    void Start()
    {
        moneyText.text = moneyTotal.ToString();
        moneyText2.text = moneyTotal.ToString();
    }
    public void IcludeInInventory(int money, Image imageBag)
    {
        GameObject[] shopObjects = GameObject.FindGameObjectsWithTag("Inventory");

        if (money <= moneyTotal && numMaxObjects <=3) 
        {
            moneyTotal -= money;
            numMaxObjects++;
            GameObject bag = GameObject.Instantiate(inventoryObject, Vector2.zero, Quaternion.identity, shopObjects[0].transform);
            Image image = bag.GetComponent<Image>();
            image.sprite = imageBag.sprite;
            moneyText.text = moneyTotal.ToString();
            moneyText2.text = moneyTotal.ToString();
        }
    }
}
