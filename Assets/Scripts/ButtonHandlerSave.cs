using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandlerSave : MonoBehaviour
{
    public LoveBar loveBar; // Referencia al objeto LoveBar en la escena
    public UIShopManager shopManager; // Referencia al objeto UIShopManager en la escena
   

    private void Start()
    {
        LoadMethod(); // Cargar datos autom�ticamente al entrar en la escena
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

            if (PlayerPrefs.HasKey("SelectedDog"))
            {
                playerData.selectedDog = PlayerPrefs.GetString("SelectedDog");
                SaveManager.SavePlayerData(playerData);
            }
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

        // Debug Log to display saved inventory items
        List<string> inventoryItems = shopManager.GetInventoryItems();
        string itemsString = string.Join(", ", inventoryItems);
        Debug.Log("Saved Inventory Items: " + itemsString);
    }

    
}