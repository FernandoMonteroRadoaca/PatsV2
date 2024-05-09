using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Objecto : MonoBehaviour
{
    [SerializeField] Image objectImage;
    [SerializeField] TextMeshProUGUI objectText;
    [SerializeField] TextMeshProUGUI priceText;

    private int price;
    private Inventory inventory;

    private void Awake()
    {
        inventory = FindAnyObjectByType<Inventory>();
    }

    public void CreateObject(ObjectShopScheme objectData)
    {
        price = objectData.priceObject;
        objectImage.sprite = objectData.imageObject;
        objectText.text = objectData.textObject;
        priceText.text = objectData.priceObject.ToString();
    }
    public void BuyObject()
    {
        inventory.IcludeInInventory(price, objectImage);
    }

}
