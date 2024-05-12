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

    // Método público que se llamará cuando se presione el botón shopButton.
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
    }
}
