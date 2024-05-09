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

    public void CreateObject(ObjectShopScheme objectData)
    {
        objectImage.sprite = objectData.imageObject;
        objectText.text = objectData.textObject;
        priceText.text = objectData.priceObject.ToString();
    }

}
