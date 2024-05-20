using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public float love;
    public float hunger;
    public int money;
    public List<string> inventoryItems; // Lista de nombres de los objetos en el inventario
    public string selectedDog;
    

    public PlayerData(LoveBar player, UIShopManager uIShop)
    {
        love = player.actualLove;
        hunger = player.actualHunger;
        money = uIShop.totalMoney;
        inventoryItems = uIShop.GetInventoryItems();
        
        
    }
}
