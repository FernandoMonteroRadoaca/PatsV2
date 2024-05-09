using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] GameObject prefabObjetoTienda;
    [SerializeField] int maxNumberObjectsShop;
    [SerializeField] ObjectShopScheme[] listShop;

    private Objecto objeto;

    void Start()
    {
        GameObject[] shopObjects = GameObject.FindGameObjectsWithTag("Shop");

        if (shopObjects.Length > 0)
        {
            int shopIndex = 0; // Variable para llevar un seguimiento del índice del objeto de la tienda
            for (int i = 0; i < maxNumberObjectsShop; i++)
            {
                if (shopIndex < listShop.Length)
                {
                    GameObject shop = GameObject.Instantiate(prefabObjetoTienda, Vector2.zero, Quaternion.identity, shopObjects[0].transform);
                    objeto = shop.GetComponent<Objecto>();
                    objeto.CreateObject(listShop[shopIndex]);
                    shopIndex++; // Incrementa el índice del objeto de la tienda para seleccionar el siguiente en la lista
                }
                else
                {
                    // Si hemos agotado los objetos en listShop, salimos del bucle
                    break;
                }
            }
        }
        else
        {
            Debug.LogError("No se encontró ningún objeto con el tag 'Shop'");
        }
    }


}
