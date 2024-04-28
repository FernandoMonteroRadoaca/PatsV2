using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Animation4dController : MonoBehaviour
{
    [SerializeField] private float speedMovement;
    private Vector2 direction;
    private Rigidbody2D rb2D;
    private Animator animator;
    private Collider2D lastCollision;
    private float timeSinceLastCollision; // Contador de tiempo desde la última colisión
    public float timeBetweenCollisions = 0.1f; // Tiempo mínimo entre cambios de dirección

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb2D = GetComponent<Rigidbody2D>();

        // Inicialmente, asignamos una dirección de movimiento aleatoria
        ChangeDirection();
    }

    private void Update()
    {
        animator.SetFloat("MovementX", direction.x);
        animator.SetFloat("MovementY", direction.y);
    }

    private void FixedUpdate()
    {
        // Movemos el personaje en la dirección actual
        rb2D.MovePosition(rb2D.position + direction * speedMovement * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Reflejar la dirección actual en relación con la normal de la colisión
        direction = Vector2.Reflect(direction, collision.contacts[0].normal);

        // Actualizar el tiempo de la última colisión
        timeSinceLastCollision = Time.time;
    }

    private void ChangeDirection()
    {
        // Generamos una dirección de movimiento aleatoria en ambos ejes
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-1f, 1f);
        direction = new Vector2(randomX, randomY).normalized;
    }
}    