using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class WalkButton : MonoBehaviour
{
    public GameObject panel; // Panel que se va a mostrar y ocultar
    public RawImage rawImage; // RawImage que se va a mover
    public float displayDuration = 3f; // Duración en segundos que el panel estará visible
    public float scrollSpeed = 0.05f; // Velocidad del movimiento del RawImage en el eje X

    public Animator animator;
    private String dogName;
    private LoveBar loveBar;
    private bool showing = false;
    private UIShopManager uIShopManager;


    // Método que se llama cuando se hace clic en el botón

    public void OnWalkButtonClick()
    {
        showing = true;
        panel.SetActive(true);
        StartCoroutine(HidePanelAfterTime(displayDuration));
    }

    // Corrutina que oculta el panel después de un tiempo
    private IEnumerator HidePanelAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        panel.SetActive(false);
        showing = false;
        loveBar = GameObject.FindObjectOfType<LoveBar>();
        loveBar.IncreaseLove(10);
        loveBar.DecreaseHungerBy(10);
        uIShopManager = GameObject.FindAnyObjectByType<UIShopManager>();
        uIShopManager.IncreaseMoney(20);


    }

    // Método Update que se llama una vez por frame
    void Update()
    {
        // Mover el RawImage en el eje X
        if (rawImage != null)
        {
            Rect uvRect = rawImage.uvRect;
            uvRect.x += scrollSpeed * Time.deltaTime;
            rawImage.uvRect = uvRect;
        }

        if (showing)
        {
            dogName = PlayerPrefs.GetString("SelectedDog");
            switch (dogName)
            {
                case "Dog":
                    animator.SetBool("Dog", true);
                    break;
                case "Lab":
                    animator.SetBool("Lab", true);
                    break;
                case "Pug":
                    animator.SetBool("Pug", true);
                    break;
                default:
                    Debug.LogWarning("Dog name not recognized: " + dogName);
                    break;
            }
        }
    }
}
