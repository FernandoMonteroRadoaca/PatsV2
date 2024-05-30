using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InformativeTextsController : MonoBehaviour
{
    public float inactivityThreshold = 20.0f; // Tiempo de inactividad antes de activar el texto (en segundos)
    public TextMeshProUGUI inactivityText; // Referencia al objeto de texto que se mostrará
    private float inactivityTimer = 0.0f;

    public Image handImage;
    public TextMeshProUGUI imformattiveHandText;

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
            }
            else
            {
                // Si la imagen no está activa, desactivar el texto
                imformattiveHandText.gameObject.SetActive(false);
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
