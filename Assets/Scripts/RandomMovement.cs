using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{

    [SerializeField] private float velocidadInicialX;
    [SerializeField] private float velocidadInicialY;
    [SerializeField] private float intervaloCambioDirecci�nMinimo = 1f;
    [SerializeField] private float intervaloCambioDirecci�nMaximo = 3f;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRendererDog;
    private float tiempoSiguienteCambioDirecci�n;
    private Vector2 direccionActual;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        spriteRendererDog = GetComponentInChildren<SpriteRenderer>();

        direccionActual = new Vector2(velocidadInicialX, velocidadInicialY).normalized;
        rb.velocity = direccionActual;

        CalcularSiguienteCambioDirecci�n();
    }

    private void FixedUpdate()
    {
        animator.SetFloat("Walk", Mathf.Abs(rb.velocity.magnitude));

        if (Time.time >= tiempoSiguienteCambioDirecci�n)
        {
            CambiarDirecci�n();
            CalcularSiguienteCambioDirecci�n();
        }

        // Girar el sprite del perro seg�n la direcci�n del movimiento
        if (direccionActual.x > 0)
        {
            spriteRendererDog.flipX = true;
        }
        else if (direccionActual.x < 0)
        {
            spriteRendererDog.flipX = false;
        }
    }

    private void CambiarDirecci�n()
    {
        direccionActual = Random.insideUnitCircle.normalized;
        rb.velocity = direccionActual;
    }

    private void CalcularSiguienteCambioDirecci�n()
    {
        tiempoSiguienteCambioDirecci�n = Time.time + Random.Range(intervaloCambioDirecci�nMinimo, intervaloCambioDirecci�nMaximo);
    }
}
