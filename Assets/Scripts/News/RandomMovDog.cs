using UnityEngine;
using System.Collections;

public class RandomMovDog : MonoBehaviour
{
    public float minSpeed = 2f;
    public float maxSpeed = 5f;
    public float minMovementDuration = 2f;
    public float maxMovementDuration = 5f;
    public float minPauseDuration = 1f;
    public float maxPauseDuration = 3f;

    public float leftLimit = -8f;
    public float rightLimit = 8f;
    public float bottomLimit = -3f;
    public float topLimit = -1f;

    private Vector2 movementDirection;
    private float currentSpeed;
    private Animator animator;
    private bool isRunning = true;

    private Rigidbody2D rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(ChangeMovement());
    }

    void Update()
    {
        if (!isRunning)
            return;

        Vector3 newPosition = transform.position + (new Vector3(movementDirection.x, movementDirection.y, 0) * currentSpeed * Time.deltaTime);

        if (newPosition.x < leftLimit || newPosition.x > rightLimit)
        {
            movementDirection.x *= -1;
            newPosition.x = Mathf.Clamp(newPosition.x, leftLimit, rightLimit);
        }

        if (newPosition.y < bottomLimit || newPosition.y > topLimit)
        {
            movementDirection.y *= -1;
            newPosition.y = Mathf.Clamp(newPosition.y, bottomLimit, topLimit);
        }

        transform.position = newPosition;

        if (movementDirection != Vector2.zero)
        {
            float horizontal = movementDirection.x;
            float vertical = movementDirection.y;

            if (Mathf.Abs(horizontal) > Mathf.Abs(vertical))
            {
                animator.SetBool("Right", horizontal > 0);
                animator.SetBool("Left", horizontal < 0);
                animator.SetBool("Up", false);
                animator.SetBool("Down", false);
                animator.SetBool("Idle", false);
            }
            else
            {
                animator.SetBool("Right", false);
                animator.SetBool("Left", false);
                animator.SetBool("Up", vertical > 0);
                animator.SetBool("Down", vertical < 0);
                animator.SetBool("Idle", false);
            }
        }

        if (currentSpeed == 0)
        {
            DoPause();
        }
    }

    IEnumerator ChangeMovement()
    {
        while (isRunning)
        {
            movementDirection = GenerateRandomVector();
            currentSpeed = Random.Range(minSpeed, maxSpeed);

            yield return new WaitForSeconds(Random.Range(minMovementDuration, maxMovementDuration));

            movementDirection = Vector2.zero;
            currentSpeed = 0;

            yield return new WaitForSeconds(Random.Range(minPauseDuration, maxPauseDuration));
        }
    }

    public void DoPause()
    {
        animator.SetBool("Right", false);
        animator.SetBool("Left", false);
        animator.SetBool("Up", false);
        animator.SetBool("Down", false);
        animator.SetBool("Idle", true);
    }

    public void StopScript()
    {
        isRunning = false;
        StopCoroutine(ChangeMovement());
    }

    public void StartScript()
    {
        isRunning = true;
        StartCoroutine(ChangeMovement());
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Dog"))
        {
            Vector2 normal = collision.GetContact(0).normal;
            movementDirection = Vector2.Reflect(movementDirection, normal);
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
