using UnityEngine;
using UnityEngine.UI;

public class ShowerButton : MonoBehaviour
{
    public GameObject bubblePrefab;
    public Vector2 spawnPoint;
    public int numBubbles = 10;

    private bool canClick = true;
    public Texture2D spongeCursor;
    public LoveBar loveBar;

    public void OnShowerButtonClicked()
    {
        if (canClick)
        {
            Cursor.SetCursor(spongeCursor, Vector2.zero, CursorMode.Auto);
            canClick = false;
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
            // Incrementa el afecto por 20
            loveBar.IncreaseLove(10);

            // Resetea el estado del botón
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            canClick = true;
            // Reinicia el contador de burbujas
            numBubbles = 10;
        }
    }
}
