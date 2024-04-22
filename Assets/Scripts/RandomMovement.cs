using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{

    [SerializeField] private float velocidadInicialX;
    [SerializeField] private float velocidadInicialY;
    [SerializeField] private float intervaloCambioDirecciónMinimo = 1f;
    [SerializeField] private float intervaloCambioDirecciónMaximo = 3f;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRendererDog;
    private float tiempoSiguienteCambioDirección;
    private Vector2 direccionActual;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        spriteRendererDog = GetComponentInChildren<SpriteRenderer>();

        direccionActual = new Vector2(velocidadInicialX, velocidadInicialY).normalized;
        rb.velocity = direccionActual;

        CalcularSiguienteCambioDirección();
    }

    private void FixedUpdate()
    {
        animator.SetFloat("Walk", Mathf.Abs(rb.velocity.magnitude));

        if (Time.time >= tiempoSiguienteCambioDirección)
        {
            CambiarDirección();
            CalcularSiguienteCambioDirección();
        }

        // Girar el sprite del perro según la dirección del movimiento
        if (direccionActual.x > 0)
        {
            spriteRendererDog.flipX = true;
        }
        else if (direccionActual.x < 0)
        {
            spriteRendererDog.flipX = false;
        }
    }

    private void CambiarDirección()
    {
        direccionActual = Random.insideUnitCircle.normalized;
        rb.velocity = direccionActual;
    }

    private void CalcularSiguienteCambioDirección()
    {
        tiempoSiguienteCambioDirección = Time.time + Random.Range(intervaloCambioDirecciónMinimo, intervaloCambioDirecciónMaximo);
    }
}
