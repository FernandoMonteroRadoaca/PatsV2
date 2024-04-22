using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRendererDog;


    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        spriteRendererDog = GetComponentInChildren<SpriteRenderer>();

    }
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        rb.velocity = new Vector2 (horizontal,vertical) * speed;
        animator.SetFloat("Walk",Mathf.Abs(rb.velocity.magnitude));

        if (horizontal > 0)
        {
            spriteRendererDog.flipX = true;

        }else if (horizontal < 0) {
            spriteRendererDog.flipX=false;
        }
    }
}
