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

    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] private GameObject inventoryPanel;

    // Lista interna para almacenar los nombres de los objetos en el inventario
    private List<string> inventoryItems = new List<string>();

    void Start()
    {
        UpdateMoneyText();
        Debug.Log(totalMoney);
        ClearInventory();
    }

    public void PriceObject(string price)
    {
        switch (price)
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
        if (priceObject <= totalMoney && totalObjects < 5)
        {
            totalObjects++;
            totalMoney -= priceObject;
            UpdateMoneyText();
            GameObject equipo = (GameObject)Resources.Load(article);
            if (equipo != null)
            {
                GameObject newItem = Instantiate(equipo, Vector3.zero, Quaternion.identity, inventoryPanel.transform);
                newItem.name = article; // Asignar el nombre del objeto para su identificaci�n
                inventoryItems.Add(article); // A�adir el nombre del objeto a la lista de inventario
            }
            else
            {
                Debug.LogError("No se pudo cargar el objeto: " + article);
            }
        }
    }
    public void decreaseMoney(int amount){
        totalMoney -= amount;
        UpdateMoneyText();
    }
    public void IncreaseMoney(int amount){
        totalMoney += amount;
        UpdateMoneyText();
    }

    public void RemoveObject(string article)
    {
        // Eliminar el objeto de la lista de inventario
        inventoryItems.Remove(article);

        // Destruir el objeto del inventario visual
        foreach (Transform child in inventoryPanel.transform)
        {
            if (child.name == article)
            {
                Destroy(child.gameObject);
                break;
            }
        }
    }

    public void UpdateMoneyText()
    {
        moneyText.text = totalMoney.ToString();
    }

    // M�todo para obtener la lista de objetos del inventario
    public List<string> GetInventoryItems()
    {
        return new List<string>(inventoryItems); // Devolver una copia de la lista de objetos del inventario
    }

    // M�todo para limpiar el inventario visual y la lista interna
    private void ClearInventory()
    {
        foreach (Transform child in inventoryPanel.transform)
        {
            Destroy(child.gameObject);
        }
        inventoryItems.Clear();
    }

    // M�todo para cargar los objetos en el inventario desde una lista de nombres
    public void LoadInventoryItems(List<string> items)
    {
        ClearInventory(); // Limpiar el inventario antes de cargar nuevos datos

        foreach (string item in items)
        {
            if (inventoryItems.Count >= 5)
            {
                Debug.LogWarning("El inventario est� lleno. No se puede a�adir m�s objetos.");
                break;
            }

            GameObject equipo = (GameObject)Resources.Load(item);
            if (equipo != null)
            {
                GameObject newItem = Instantiate(equipo, Vector3.zero, Quaternion.identity, inventoryPanel.transform);
                newItem.name = item; // Asignar el nombre del objeto para su identificaci�n
                inventoryItems.Add(item); // A�adir el objeto a la lista de inventario interna
            }
            else
            {
                Debug.LogError("No se pudo cargar el objeto: " + item);
            }
        }
    }

}
