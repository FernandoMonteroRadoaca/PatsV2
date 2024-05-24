using UnityEngine;

public class Bubble : MonoBehaviour
{
    private bool popped = false;
    private ShowerButton showerButton;
    public Sprite[] sprites;

    private void Start()
    {
        // Encuentra la referencia al ShowerButton
        showerButton = FindObjectOfType<ShowerButton>();
    }

    private void OnMouseDown()
    {
        // Si la burbuja no ha sido reventada todavía
        if (!popped)
        {
            // Destruye la burbuja
            Destroy(gameObject);
            // Llama al método para indicar que una burbuja ha sido reventada
            showerButton.BubblePopped();
            // Marca la burbuja como reventada
            popped = true;
        }
    }

    // Método para establecer un sprite aleatorio a la burbuja
    public void SetRandomSprite()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = GetRandomBubbleSprite();
    }

    // Método para obtener un sprite aleatorio para la burbuja
    private Sprite GetRandomBubbleSprite()
    {
        // Carga todos los sprites de las burbujas desde la carpeta Resources/Sprites/Bubble
        
        // Retorna un sprite aleatorio
        return sprites[Random.Range(0, sprites.Length)];
    }
}
