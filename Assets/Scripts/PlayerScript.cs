using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float userSpeed = 5.0f;
    private float moveSpeed = 0f;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    // external controlled direction
    private float externalDirection = 0f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // keyboard control
        float direction = 0f;
        if (Input.GetKey(KeyCode.A))
        {
            direction = -1f; // Move left when 'A' is pressed
        }
        else if (Input.GetKey(KeyCode.D))
        {
            direction = 1f; // Move right when 'D' is pressed
        }
        else
        {
            direction = externalDirection; // use external control
        }

        // set speed and direction
        UpdateMovement(direction);
    }

    private void UpdateMovement(float direction)
    {
        if (direction != 0)
        {
            moveSpeed = userSpeed; // Set moveSpeed to userSpeed
            spriteRenderer.flipX = direction < 0; // Flip sprite based on direction
        }
        else
        {
            moveSpeed = 0f; // Set moveSpeed to 0 if no keys are pressed
        }

        animator.SetFloat("Speed", Mathf.Abs(moveSpeed));

        Vector3 movement = new Vector3(direction * moveSpeed * Time.deltaTime, 0f, 0f);
        transform.Translate(movement);
    }

    // External direction setter, used by WebSocket
    public void SetDirection(float dir)
    {
        externalDirection = dir;
    }
}
