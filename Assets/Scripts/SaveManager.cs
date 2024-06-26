using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveManager {


    public static void SavePlayerData(LoveBar player, UIShopManager uIShop)
    {
        PlayerData playerData = new PlayerData(player, uIShop);
        SavePlayerData(playerData); // Llamar al m�todo sobrecargado
    }

    public static void SavePlayerData(PlayerData playerData)
    {
        string dataPath = Application.persistentDataPath + "/player.save";
        FileStream fileStream = new FileStream(dataPath, FileMode.Create);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(fileStream, playerData);
        Debug.Log(playerData.inventoryItems);
        fileStream.Close();
    }

    public static PlayerData LoadPlayerData()
    {
        string dataPath = Application.persistentDataPath + "/player.save";
        if (File.Exists(dataPath))
        {
            FileStream fileStream = new FileStream(dataPath, FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            PlayerData playerData = (PlayerData)binaryFormatter.Deserialize(fileStream);
            fileStream.Close();
            return playerData;
        }
        else
        {
            Debug.Log("Error al encontrar archivo de guardado");
            return null;
        }
    }
}
