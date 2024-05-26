using UnityEngine;
using UnityEngine.UI;

public class PetButton : MonoBehaviour
{
    public Image customCursorImage; // Imagen UI que actúa como cursor personalizado
    public Button startPettingButton; // Botón para empezar a acariciar
    public Image pettingArea; // Área UI donde acariciar (perro)
    private LoveBar loveBar;

    public float pettingTimeRequired = 2.0f; // Tiempo necesario para acariciar
    private float pettingTime = 0.0f;
    private bool isPetting = false;

    void Start()
    {
        startPettingButton.onClick.AddListener(StartPetting);
        customCursorImage.gameObject.SetActive(false); // Inicialmente desactivar la imagen del cursor personalizado
        pettingArea.gameObject.SetActive(false); // Inicialmente desactivar el área de acariciamiento
        Cursor.visible = true; // Asegurarse de que el cursor del sistema esté visible al inicio
    }

    void Update()
    {
        if (isPetting)
        {
            Vector2 mousePos = Input.mousePosition;
            customCursorImage.transform.position = mousePos;

            if (Input.GetMouseButton(0))
            {
                if (IsPointerOverUIObject(pettingArea.rectTransform, mousePos))
                {
                    pettingTime += Time.deltaTime;
                    Debug.Log("Estas acariciando.");
                    if (pettingTime >= pettingTimeRequired)
                    {
                        StopPetting();
                    }
                }
                else
                {
                    pettingTime = 0.0f; // Reiniciar tiempo si el mouse sale del área
                }
            }
            else
            {
                pettingTime = 0.0f; // Reiniciar tiempo si no se mantiene el clic
            }
        }
    }

    void StartPetting()
    {
        Cursor.visible = false; // Hacer invisible el cursor del sistema
        customCursorImage.gameObject.SetActive(true); // Activar la imagen del cursor personalizado
        pettingArea.gameObject.SetActive(true); // Activar el área de acariciamiento
        isPetting = true;
    }

    void StopPetting()
    {
        loveBar = GameObject.FindObjectOfType<LoveBar>();
        Cursor.visible = true; // Hacer visible el cursor del sistema
        customCursorImage.gameObject.SetActive(false); // Desactivar la imagen del cursor personalizado
        pettingArea.gameObject.SetActive(false); // Desactivar el área de acariciamiento
        isPetting = false;
        pettingTime = 0.0f;
        loveBar.IncreaseLove(10);
        Debug.Log("Has dejado de acariciar al perro.");
    }

    private bool IsPointerOverUIObject(RectTransform rectTransform, Vector2 screenPosition)
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, screenPosition, null, out localPoint);
        return rectTransform.rect.Contains(localPoint);
    }
}