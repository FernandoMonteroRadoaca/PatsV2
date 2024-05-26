using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonHandlerSave : MonoBehaviour
{
    public LoveBar loveBar; // Referencia al objeto LoveBar en la escena
    public UIShopManager shopManager; // Referencia al objeto UIShopManager en la escena
    public TextMeshProUGUI notificationText; //Referencia al texto guardando..

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
            shopManager.totalMoney = playerData.money;
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
        // Llama a la corrutina para mostrar la notificación
        StartCoroutine(ShowNotification());
    }
    IEnumerator ShowNotification()
    {
        notificationText.gameObject.SetActive(true);  // Activa el TextMeshPro
        yield return new WaitForSeconds(1.0f);  // Espera 1 segundo
        notificationText.gameObject.SetActive(false);  // Desactiva el TextMeshPro
    }

}
