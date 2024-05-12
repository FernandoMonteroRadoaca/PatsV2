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




    private Vector3 originalInventoryMenuPosition;

    private void Start()
    {
        // Guardar la posición original del menú de inventario al inicio del juego
        originalInventoryMenuPosition = inventoryMenu.transform.position;
    }
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
    }public void OnBagButtonPressed()
    {
        if (pausedGame)
        {
            ResetBag();
        }
        else
        {
            PauseBag();
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
        Vector3 newPos = new Vector3(Screen.width * 0.5f + inventoryMenu.GetComponent<RectTransform>().rect.width * 0.5f, inventoryMenu.transform.position.y, inventoryMenu.transform.position.z);
        inventoryMenu.transform.position = newPos;
        inventoryMenu.SetActive(true);

    }
    public void ResetBag()
    {
        pausedGame = false;
        Time.timeScale = 1f;
        shopButton.SetActive(true);       
        inventoryMenu.SetActive(false);
        // Restaurar la posición original del menú de inventario
        inventoryMenu.transform.position = originalInventoryMenuPosition;
    }
}
