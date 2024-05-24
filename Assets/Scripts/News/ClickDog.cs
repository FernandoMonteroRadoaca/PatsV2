using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickDog : MonoBehaviour
{
    public Vector2 destination = new Vector2(0, 1.8f); // The position the object will move to

    public float movementSpeed = 2f;
    public float animationDuration = 2f;
    public float maxScale = 5f;
    public Sprite finalSprite;
    private Animator animator;

    private RandomMovDog randomMovDog;
    private SpriteRenderer spriteRenderer;
    private new Collider2D collider2D;

    private bool isMoving = false; // Variable that indicates if the object is moving
    private bool atDestination = false;
    private float elapsedTime = 0f;

    private string dogName;

    private LivingRoomUIManager uiManager;

    private void OnMouseDown()
    {
        if (SceneManager.GetActiveScene().name == "StartRoom")
        {
            if (!atDestination)
            {
                MoveToDestination(destination);
            }
        }
        else if (SceneManager.GetActiveScene().name == "ChooseDog")
        {
            dogName = gameObject.name;
            PlayerPrefs.SetString("SelectedDog", dogName); // Save the name of the selected dog
            SceneManager.LoadScene("StartRoom");
        }
    }

    void Start()
    {
        collider2D = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        randomMovDog = GetComponent<RandomMovDog>();

        uiManager = FindObjectOfType<LivingRoomUIManager>();
    }

    void Update()
    {
        if (isMoving)
        {
            // Calculate direction towards destination
            Vector2 direction = (destination - (Vector2)transform.position).normalized;

            // Calculate new position to move towards
            Vector2 newPosition = (Vector2)transform.position + direction * movementSpeed * Time.deltaTime;

            // Set the new position
            transform.position = newPosition;

            // Calculate animation progress (0 to 1)
            elapsedTime += Time.deltaTime;
            float progress = Mathf.Clamp01(elapsedTime / animationDuration);

            // Calculate current scale of the object based on animation progress
            float currentScale = Mathf.Lerp(1f, maxScale, progress);

            // Assign the new scale to the object
            transform.localScale = new Vector3(currentScale, currentScale, 1f);

            // If the animation has finished
            if (progress >= 1f)
            {
                isMoving = false;
                transform.position = destination;
                atDestination = true;
                animator.enabled = false;
                spriteRenderer.sprite = finalSprite;
                randomMovDog.StopScript();
                collider2D.enabled = false;


                // Show buttons when destination is reached
                if (uiManager != null)
                {
                    uiManager.SetButtonsActive(true);
                }
            }

            // Set animation direction
            if (direction != Vector2.zero)
            {
                animator.SetBool("Right", false);
                animator.SetBool("Left", false);
                animator.SetBool("Up", false);
                animator.SetBool("Down", true);
                animator.SetBool("Idle", false);
            }
        }
    }

    // Method to move the object to the destination
    public void MoveToDestination(Vector2 newDestination)
    {
        destination = newDestination;
        isMoving = true;
        atDestination = false; // Reset atDestination to allow for another move
        elapsedTime = 0f; // Reset elapsedTime for the new movement

        // Hide buttons when starting movement
        if (uiManager != null)
        {
            uiManager.SetButtonsActive(false);
        }
    }

    // Method to stop movement animations
    private void StopMovement()
    {
        animator.SetBool("Right", false);
        animator.SetBool("Left", false);
        animator.SetBool("Up", false);
        animator.SetBool("Down", false);
        animator.SetBool("Idle", true);
    }

    // Method to move the dog back and resume random movement
    public void MoveBack()
    {
        randomMovDog.StartScript(); // Resume random movement
        atDestination = false;
        transform.localScale = new Vector3(1f, 1f, 1f); // Reset the scale
        animator.enabled = true; // Enable the animator

        // Hide buttons when moving back
        if (uiManager != null)
        {
            uiManager.SetButtonsActive(false);
        }
    }
}
