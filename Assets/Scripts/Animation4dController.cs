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

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb2D = GetComponent<Rigidbody2D>();

        // Inicialmente, asignamos una direcci�n de movimiento aleatoria
        ChangeDirection();
    }

    private void Update()
    {
        animator.SetFloat("MovementX", direction.x);
        animator.SetFloat("MovementY", direction.y);
    }

    private void FixedUpdate()
    {
        // Movemos el personaje en la direcci�n actual
        rb2D.MovePosition(rb2D.position + direction * speedMovement * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Cambiar la direcci�n hacia la opuesta cuando se detecta una colisi�n
        ChangeDirection();
    }

    private void ChangeDirection()
    {
        // Generamos una direcci�n de movimiento aleatoria en ambos ejes
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-1f, 1f);
        direction = new Vector2(randomX, randomY).normalized;
    }
}
