using UnityEngine;
using UnityEngine.UI;

public class ShowerButton : MonoBehaviour
{
    public GameObject bubblePrefab;
    public Vector2 spawnPoint;
    public int numBubbles = 10;
    private LoveBar loveBar;
    public Image customCursor; // Referencia a la imagen UI que actuará como cursor
    public Texture2D spongeCursor; // Textura para el cursor
    private bool canClick = true;
    private LivingRoomUIManager uIManager;

    void Start()
    {
        // Asegúrate de que el cursor personalizado está inactivo al inicio
        customCursor.gameObject.SetActive(false);
        uIManager = FindObjectOfType<LivingRoomUIManager>();
    }

    private void Update()
    {
        if (!canClick && customCursor.gameObject.activeSelf)
        {
            // Actualiza la posición del cursor personalizado para que siga al cursor del ratón
            Vector2 cursorPosition = Input.mousePosition;
            customCursor.transform.position = cursorPosition;
        }
    }

    public void OnShowerButtonClicked()
    {
        if (canClick)
        {
            canClick = false;
            // Mostrar el cursor personalizado y ocultar el cursor del sistema
            uIManager.DesactivateButtons();
            Cursor.visible = false;
            customCursor.gameObject.SetActive(true);
            customCursor.sprite = Sprite.Create(spongeCursor, new Rect(0, 0, spongeCursor.width, spongeCursor.height), new Vector2(0.5f, 0.5f));
            SpawnBubbles();
        }
    }

    private void SpawnBubbles()
    {
        for (int i = 0; i < numBubbles; i++)
        {
            Vector2 randomOffset = Random.insideUnitCircle * 1.5f; // Ajusta el radio de spawn de las burbujas
            Vector3 spawnPosition = spawnPoint + randomOffset;
            GameObject bubble = Instantiate(bubblePrefab, spawnPosition, Quaternion.identity);
            bubble.GetComponent<Bubble>().SetRandomSprite();
        }
    }

    public void BubblePopped()
    {
        loveBar = GameObject.FindObjectOfType<LoveBar>();
        numBubbles--;
        if (numBubbles <= 0)
        {
            loveBar.IncreaseLove(10); // Incrementa el afecto por 20

            // Resetea el estado del botón
            Cursor.visible = true;
            customCursor.gameObject.SetActive(false);
            canClick = true;
            numBubbles = 10; // Reinicia el contador de burbujas
            uIManager.ActivateButtons();
        }
    }
}
