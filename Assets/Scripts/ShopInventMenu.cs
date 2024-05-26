using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopInventMenu : MonoBehaviour
{
    [SerializeField] private GameObject shopButton;
    [SerializeField] private GameObject shopMenu;
    [SerializeField] private GameObject inventoryMenu;
    private bool pausedGame = false;

    private LivingRoomUIManager uIManager;



    private Vector3 originalInventoryMenuPosition;

    private void Start()
    {
        // Guardar la posici�n original del men� de inventario al inicio del juego
        originalInventoryMenuPosition = inventoryMenu.transform.position;
        uIManager = FindObjectOfType<LivingRoomUIManager>();
    }
    // M�todo p�blico que se llamar� cuando se presione el bot�n shopButton.
    public void OnShopButtonPressed()
    {
        if (pausedGame)
        {
            Reset();
        }
        else
        {
            Pause();
        }
    }public void OnBagButtonPressed()
    {
        if (pausedGame)
        {
            ResetBag();
            uIManager.ActivateButtons();
        }
        else
        {
            PauseBag();
            uIManager.DesactivateButtonsWthoutInventory();
        }
    }

    private void Pause()
    {
        pausedGame = true;
        shopMenu.SetActive(true);
        inventoryMenu.SetActive(true);
    }
    public void Reset()
    {
        pausedGame = false;
        Time.timeScale = 1f;
        shopButton.SetActive(true);
        shopMenu.SetActive(false);
        inventoryMenu.SetActive(false);
        inventoryMenu.transform.position = originalInventoryMenuPosition;
    }
    private void PauseBag()
    {
        pausedGame = true;
        
        inventoryMenu.SetActive(true);

    }
    public void ResetBag()
    {
        pausedGame = false;
        Time.timeScale = 1f;
        shopButton.SetActive(true);       
        inventoryMenu.SetActive(false);
        // Restaurar la posici�n original del men� de inventario
        inventoryMenu.transform.position = originalInventoryMenuPosition;
    }
}
