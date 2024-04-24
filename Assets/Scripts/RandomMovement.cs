using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    [SerializeField] private float velocidadInicialX;
    [SerializeField] private float velocidadInicialY;
    [SerializeField] private float intervaloCambioDirecciónMinimo = 1f;
    [SerializeField] private float intervaloCambioDirecciónMaximo = 3f;
    [SerializeField] private float duracionPausaInicial = 2f;
    [SerializeField] private float duracionPausaRegular = 3f;
    [SerializeField] private float intervaloParadasRegulares = 10f;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRendererDog;
    private float tiempoSiguienteCambioDirección;
    private float tiempoFinPausa;
    private float tiempoSiguienteParadaRegular;
    private Vector2 direccionActual;
    private bool enPausa;
    private bool primerInicio = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        spriteRendererDog = GetComponentInChildren<SpriteRenderer>();

        // Inicia el movimiento después de una pausa inicial
        if (primerInicio)
        {
            primerInicio = false;
            PausaInicial();
        }
        else
        {
            IniciarMovimiento();
        }
    }

    private void FixedUpdate()
    {
        animator.SetFloat("Walk", Mathf.Abs(rb.velocity.magnitude));

        if (!enPausa && Time.time >= tiempoSiguienteCambioDirección)
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

        // Verificar si es hora de hacer una parada regular
        if (!enPausa && Time.time >= tiempoSiguienteParadaRegular)
        {
            ParadaRegular();
        }

        // Si está en pausa, verifica si la pausa ha terminado
        if (enPausa && Time.time >= tiempoFinPausa)
        {
            enPausa = false;
            // Solo calcular el siguiente cambio de dirección si no está en pausa
            if (!enPausa)
            {
                CalcularSiguienteCambioDirección();
            }
        }
    }

    private void CambiarDirección()
    {
        direccionActual = Random.insideUnitCircle.normalized;
        rb.velocity = direccionActual;

        // Inicia una pausa regular después de cambiar la dirección
        float duracionPausa = duracionPausaRegular;
        tiempoFinPausa = Time.time + duracionPausa;
        enPausa = true;
    }

    private void PausaInicial()
    {
        // Inicia una pausa inicial al inicio del juego
        float duracionPausa = duracionPausaInicial;
        tiempoFinPausa = Time.time + duracionPausa;
        enPausa = true;
    }

    private void IniciarMovimiento()
    {
        direccionActual = new Vector2(velocidadInicialX, velocidadInicialY).normalized;
        rb.velocity = direccionActual;

        // Inicia una pausa regular después de iniciar el movimiento
        float duracionPausa = duracionPausaRegular;
        tiempoFinPausa = Time.time + duracionPausa;
        enPausa = true;

        // Establece el siguiente tiempo para una parada regular
        tiempoSiguienteParadaRegular = Time.time + intervaloParadasRegulares;
    }

    private void CalcularSiguienteCambioDirección()
    {
        tiempoSiguienteCambioDirección = Time.time + Random.Range(intervaloCambioDirecciónMinimo, intervaloCambioDirecciónMaximo);
    }

    private void ParadaRegular()
    {
        // Detiene al personaje durante una pausa regular
        float duracionPausa = duracionPausaRegular;
        tiempoFinPausa = Time.time + duracionPausa;
        enPausa = true;

        // Establece el siguiente tiempo para una parada regular
        tiempoSiguienteParadaRegular = Time.time + intervaloParadasRegulares;
    }

    // Este método se llama cuando este objeto colisiona con otro Collider2D
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Reflejar la dirección actual en relación con la normal de la colisión
        direccionActual = Vector2.Reflect(direccionActual, collision.contacts[0].normal);
        rb.velocity = direccionActual;
    }
}
