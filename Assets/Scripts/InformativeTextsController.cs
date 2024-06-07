using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InformativeTextsController : MonoBehaviour
{
    public float inactivityThreshold = 60.0f; // Tiempo de inactividad antes de activar el texto (en segundos)
    public TextMeshProUGUI inactivityText; // Referencia al objeto de texto que se mostrará
    private float inactivityTimer = 0.0f;
    private bool inactivityTextShown = false;

    public Image handImage;
    public TextMeshProUGUI imformattiveHandText;

    public Image spongeImage;
    public TextMeshProUGUI imformativeShowerText;

    public GameObject walkObject;
    public TextMeshProUGUI imformativeWalkTextHunger;
    public TextMeshProUGUI imformativeWalkTextLove;

    public TextMeshProUGUI imformativeHandTextLove;

    private ShowerButton showerButton;

    void Start()
    {
        inactivityText.gameObject.SetActive(false); // Asegúrate de que el texto esté inicialmente desactivado
    }

    void Update()
    {
        // Actualizar el temporizador de inactividad
        InactivityMethod();
        // Verificar si la imagen está activa
        if (handImage != null && imformattiveHandText != null)
        {
            if (handImage.gameObject.activeSelf)
            {
                // Si la imagen está activa, activar el texto
                imformattiveHandText.gameObject.SetActive(true);
                imformativeHandTextLove.gameObject.SetActive(true);
            }
            else
            {
                // Si la imagen no está activa, desactivar el texto
                imformattiveHandText.gameObject.SetActive(false);
                imformativeHandTextLove.gameObject.SetActive(false);
            }
        }
        if (spongeImage != null && imformativeShowerText != null)
        {
            if (spongeImage != null && imformativeShowerText != null)
            {
                if (spongeImage.gameObject.activeSelf)
                {
                    // Si la imagen está activa, activar el texto
                    imformativeShowerText.gameObject.SetActive(true);
                }
                else
                {
                    // Si la imagen no está activa, desactivar el texto
                    imformativeShowerText.gameObject.SetActive(false);
                }
            }
        }
        if (walkObject != null && imformativeWalkTextLove != null && imformativeWalkTextHunger != null)
        {
            if (walkObject != null && imformativeWalkTextLove != null && imformativeWalkTextHunger != null)
            {
                if (walkObject.gameObject.activeSelf)
                {
                    // Si la imagen está activa, activar el texto
                    imformativeWalkTextLove.gameObject.SetActive(true);
                    imformativeWalkTextHunger.gameObject.SetActive(true);
                }
                else
                {
                    // Si la imagen no está activa, desactivar el texto
                    imformativeWalkTextLove.gameObject.SetActive(false);
                    imformativeWalkTextHunger.gameObject.SetActive(false);
                }
            }
        }

    }
   


    private void InactivityMethod()
    {
        inactivityTimer += Time.deltaTime;

        // Verificar si se ha superado el umbral de inactividad
        if (inactivityTimer >= inactivityThreshold)
        {
            inactivityText.gameObject.SetActive(true); // Mostrar el texto de inactividad
        }

        // Detectar la interacción del jugador (teclado, ratón, etc.)
        if (Input.anyKeyDown)
        {
            inactivityTimer = 0.0f; // Reiniciar el temporizador de inactividad
            inactivityText.gameObject.SetActive(false); // Ocultar el texto de inactividad
        }
    }
   
}
