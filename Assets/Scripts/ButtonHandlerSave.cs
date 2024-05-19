using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandlerSave : MonoBehaviour
{
    public LoveBar loveBar; // Referencia al objeto LoveBar en la escena
    public UIShopManager shopManager; // Referencia al objeto UIShopManager en la escena

    private void Start()
    {
        LoadMethod(); // Cargar datos automáticamente al entrar en la escena
    }

    public void LoadMethod()
    {
        PlayerData playerData = SaveManager.LoadPlayerData();
        if (playerData != null)
        {
            loveBar.actualLove = playerData.love;
            loveBar.actualHunger = playerData.hunger;
            shopManager.totalMoney = playerData.money + 20;
            loveBar.UpdateLoveImage();
            loveBar.UpdateHungerImage();
            shopManager.UpdateMoneyText();
            shopManager.LoadInventoryItems(playerData.inventoryItems);
            
            
            Debug.Log("Loaded data");
        }
        else
        {
            Debug.Log("Error saving data");
        }
    }

    public void SaveMethod()
    {
        SaveManager.SavePlayerData(loveBar, shopManager);
        Debug.Log("Data saved");
    }
}
