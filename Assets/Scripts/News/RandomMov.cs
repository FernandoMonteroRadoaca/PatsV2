using UnityEngine;
using System.Collections;

public class RandomMov : MonoBehaviour
{
    public float velocidadMinima = 2f;
    public float velocidadMaxima = 5f;
    public float duracionMovimientoMinima = 2f;
    public float duracionMovimientoMaxima = 5f;
    public float duracionPausaMinima = 1f;
    public float duracionPausaMaxima = 3f;

    public float limiteIzquierda = -8f;
    public float limiteDerecha = 8f;
    public float limiteSuelo = -3f;
    public float limiteAltura = -1f;

    private Vector2 direccionMovimiento;
    private float velocidadActual;
    private Animator animator;
    private bool enEjecucion = true;

    private Rigidbody2D rb;

    
    public float minBarkInterval = 3f; // Tiempo mínimo entre ladridos
    public float maxBarkInterval = 7f; // Tiempo máximo entre ladridos
    private AudioSource audioSource;
    private float barkTimer;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(CambiarMovimiento());
        ResetBarkTimer();
    }

    void Update()
    {
        if (!enEjecucion)
            return;

        Vector3 newPosition = transform.position + (new Vector3(direccionMovimiento.x, direccionMovimiento.y, 0) * velocidadActual * Time.deltaTime);

        if (newPosition.x < limiteIzquierda || newPosition.x > limiteDerecha)
        {
            direccionMovimiento.x *= -1;
            newPosition.x = Mathf.Clamp(newPosition.x, limiteIzquierda, limiteDerecha);
        }

        if (newPosition.y < limiteSuelo || newPosition.y > limiteAltura)
        {
            direccionMovimiento.y *= -1;
            newPosition.y = Mathf.Clamp(newPosition.y, limiteSuelo, limiteAltura);
        }

        transform.position = newPosition;

        if (direccionMovimiento != Vector2.zero)
        {
            float horizontal = direccionMovimiento.x;
            float vertical = direccionMovimiento.y;

            if (Mathf.Abs(horizontal) > Mathf.Abs(vertical))
            {
                animator.SetBool("Derecha", horizontal > 0);
                animator.SetBool("Izquierda", horizontal < 0);
                animator.SetBool("Arriba", false);
                animator.SetBool("Abajo", false);
                animator.SetBool("Parado", false);
                barkTimer -= Time.deltaTime;
                if (barkTimer <= 0)
                {
                    // Reproducir el sonido de ladrido
                    audioSource.Play();
                    // Reiniciar el temporizador
                    ResetBarkTimer();
                }
            }
            else
            {
                animator.SetBool("Derecha", false);
                animator.SetBool("Izquierda", false);
                animator.SetBool("Arriba", vertical > 0);
                animator.SetBool("Abajo", vertical < 0);
                animator.SetBool("Parado", false);
            }
        }

        if (velocidadActual == 0)
        {
            HacerParada();
        }
    }
    void ResetBarkTimer()
    {
        barkTimer = Random.Range(minBarkInterval, maxBarkInterval);
    }

    IEnumerator CambiarMovimiento()
    {
        while (enEjecucion)
        {
            direccionMovimiento = GenerateRandomVector();
            velocidadActual = Random.Range(velocidadMinima, velocidadMaxima);

            yield return new WaitForSeconds(Random.Range(duracionMovimientoMinima, duracionMovimientoMaxima));

            direccionMovimiento = Vector2.zero;
            velocidadActual = 0;

            yield return new WaitForSeconds(Random.Range(duracionPausaMinima, duracionPausaMaxima));
        }
    }

    public void HacerParada()
    {
        animator.SetBool("Derecha", false);
        animator.SetBool("Izquierda", false);
        animator.SetBool("Arriba", false);
        animator.SetBool("Abajo", false);
        animator.SetBool("Parado", true);
    }

    public void detenerScript()
    {
        enEjecucion = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Perro"))
        {
            // Obtener la dirección del choque
            Vector2 normal = collision.GetContact(0).normal;

            // Reflejar la dirección del movimiento
            direccionMovimiento = Vector2.Reflect(direccionMovimiento, normal);
        }
    }

    private Vector2 GenerateRandomVector()
    {
        float x, y;

        float probability = Random.value;

        if (probability <= 0.9f)
        {
            x = Random.Range(-2.5f, 2.5f);
            y = Random.Range(-0.5f, 0.5f);
        }
        else
        {
            y = Random.Range(-2.5f, 2.5f);
            x = Random.Range(-0.5f, 0.5f);
        }

        Vector2 normalizedVector = new Vector2(x, y).normalized;

        return normalizedVector;
    }
}
