using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    [SerializeField] private float velocidadInicialX;
    [SerializeField] private float velocidadInicialY;
    [SerializeField] private float intervaloCambioDireccionMinimo = 1f;
    [SerializeField] private float intervaloCambioDireccionMaximo = 3f;
    [SerializeField] private float duracionPausaInicial = 2f;
    [SerializeField] private float duracionPausaRegular = 3f;
    [SerializeField] private float intervaloParadasRegulares = 10f;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRendererDog;
    private float tiempoSiguienteCambioDireccion;
    private float tiempoFinPausa;
    private float tiempoSiguienteParadaRegular;
    private Vector2 direccionActual;
    private bool enPausa;
    private bool primerInicio = true;
    private bool enEjecucion = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        spriteRendererDog = GetComponentInChildren<SpriteRenderer>();

        // Inicia el movimiento despu�s de una pausa inicial
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
        if(enEjecucion){
            animator.SetFloat("Walk", Mathf.Abs(rb.velocity.magnitude));

            if (!enPausa && Time.time >= tiempoSiguienteCambioDireccion)
            {
                CambiarDireccion();
                CalcularSiguienteCambioDireccion();
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

            // Verificar si es hora de hacer una parada regular
            if (!enPausa && Time.time >= tiempoSiguienteParadaRegular)
            {
                ParadaRegular();
            }  

            // Si est� en pausa, verifica si la pausa ha terminado
            if (enPausa && Time.time >= tiempoFinPausa)
            {
                enPausa = false;
                // Solo calcular el siguiente cambio de direcci�n si no est� en pausa
                if (!enPausa)
                {
                    CalcularSiguienteCambioDireccion();
                }
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Reflejar la direcci�n actual en relaci�n con la normal de la colisi�n
        direccionActual = Vector2.Reflect(direccionActual, collision.contacts[0].normal);
        rb.velocity = direccionActual;

        // Calcular el �ngulo entre la direcci�n actual y la direcci�n reflejada
        float angle = Vector2.Angle(rb.velocity.normalized, direccionActual.normalized);

        // Si el �ngulo es menor que 90 grados, agregar o restar 90 grados seg�n convenga
        if (angle < 90f)
        {
            // Seleccionar aleatoriamente si sumar o restar 90 grados
            int randomSign = Random.value > 0.5f ? 1 : -1;
            // Ajustar la direcci�n sumando o restando 90 grados
            direccionActual = Quaternion.Euler(0, 0, 90 * randomSign) * direccionActual;
            rb.velocity = direccionActual;
        }
    }

    private void CambiarDireccion()
    {
        direccionActual = Random.insideUnitCircle.normalized;
        rb.velocity = direccionActual;

        // Inicia una pausa regular despu�s de cambiar la direcci�n
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

        // Inicia una pausa regular despu�s de iniciar el movimiento
        float duracionPausa = duracionPausaRegular;
        tiempoFinPausa = Time.time + duracionPausa;
        enPausa = true;

        // Establece el siguiente tiempo para una parada regular
        tiempoSiguienteParadaRegular = Time.time + intervaloParadasRegulares;
    }

    private void CalcularSiguienteCambioDireccion()
    {
        tiempoSiguienteCambioDireccion = Time.time + Random.Range(intervaloCambioDireccionMinimo, intervaloCambioDireccionMaximo);
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
    public void stopScript(){
        enEjecucion = false;
    }
}
