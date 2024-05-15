using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PerritoClic : MonoBehaviour
{
     public Vector2 destino = new Vector2(0,1.8f); // La posición a la que el objeto se moverá

    // Velocidad a la que el objeto se moverá
    public float velocidadMovimiento = 2f;
    public float duracionAnimacion = 2f;
    public float escalaMaxima = 5f;
    public Sprite spriteFinal;
    private Animator animator;

    private RandomMov randomMov;
    private SpriteRenderer spriteRenderer;
    
    private bool enMovimiento = false; // Variable que indica si el objeto está en movimiento
    private bool enDestino = false;
    private float tiempoTranscurrido = 0f;
     // Tamaño final al que se agrandará el objeto


    private string nombrePerrito;

    private void OnMouseDown()
    {
        if(SceneManager.GetActiveScene().name == "StartRoom"){
                if (!enDestino)
            {
                MoverHaciaDestino(destino);
            }
        }else if(SceneManager.GetActiveScene().name == "ChooseDog"){
            nombrePerrito = gameObject.name;
            PlayerPrefs.SetString("PerritoSeleccionado", nombrePerrito); // Guarda el nombre del perrito seleccionado
            SceneManager.LoadScene("StartRoom");
        }
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        randomMov = GetComponent<RandomMov>();
    }

    void Update()
    {
        if (enMovimiento)
        {
            // Calcula la dirección hacia el destino
            Vector2 direccion = (destino - (Vector2)transform.position).normalized;

            // Calcula la nueva posición hacia la que se moverá el objeto
            Vector2 nuevaPosicion = (Vector2)transform.position + direccion * velocidadMovimiento * Time.deltaTime;

            // Establece la nueva posición
            transform.position = nuevaPosicion;

            // Calcular el progreso de la animación (0 a 1)
            tiempoTranscurrido += Time.deltaTime;
            float progreso = Mathf.Clamp01(tiempoTranscurrido / duracionAnimacion);

            // Calcular la escala actual del objeto en función del progreso de la animación
            float escalaActual = Mathf.Lerp(1f, escalaMaxima, progreso);

            // Asignar la nueva escala al objeto
            transform.localScale = new Vector3(escalaActual, escalaActual, 1f);

            // Si la animación ha terminado
            if (progreso >= 1f)
            {
                enMovimiento = false;
                transform.position = destino;
                enDestino = true;
                animator.enabled = false;
                spriteRenderer.sprite = spriteFinal;
                randomMov.detenerScript();
            }
        



            // Establece la dirección de la animación
            if (direccion != Vector2.zero)
            {
                float horizontal = direccion.x;
                float vertical = direccion.y;

                if (Mathf.Abs(horizontal) > Mathf.Abs(vertical))
                {
                    animator.SetBool("Derecha", horizontal > 0);
                    animator.SetBool("Izquierda", horizontal < 0);
                    animator.SetBool("Arriba", false);
                    animator.SetBool("Abajo", false);
                    animator.SetBool("Parado", false);
                }
                else
                {
                    animator.SetBool("Derecha", false);
                    animator.SetBool("Izquierda", false);
                    animator.SetBool("Arriba", false);             //no hacemos lo mismo porque al moverse desde ciertos puntos 
                    animator.SetBool("Abajo", true);               //detecta que se mueve hacia arriba pero queda poco estetico
                    animator.SetBool("Parado", false);             //puesto que movemos siempre hacia el punto de abajo al centro nunca movera hacia arriba
                }
            }
        }
    }

    // Método para mover el objeto al destino
    public void MoverHaciaDestino(Vector2 nuevaDestino)
    {
        destino = nuevaDestino;
        enMovimiento = true;
    }

    // Método para detener las animaciones de movimiento
    private void HacerParada()
    {
        animator.SetBool("Derecha", false);
        animator.SetBool("Izquierda", false);
        animator.SetBool("Arriba", false);
        animator.SetBool("Abajo", false);
        animator.SetBool("Parado", true);
    }
}
