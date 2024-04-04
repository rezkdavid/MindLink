using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // User-defined speed variable
    public float userSpeed = 15f;

    private float moveSpeed = 0f;

    private SpriteRenderer spriteRenderer;
    public Animator animator;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float direction = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            direction = -1f; // Move left when 'A' is pressed
            moveSpeed = userSpeed; // Set moveSpeed to userSpeed
            spriteRenderer.flipX = true; // Flip sprite to face left
        }
        else if (Input.GetKey(KeyCode.D))
        {
            direction = 1f; // Move right when 'D' is pressed
            moveSpeed = userSpeed; // Set moveSpeed to userSpeed
            spriteRenderer.flipX = false; // Do not flip sprite to face right
        }
        else
        {
            moveSpeed = 0f; // Set moveSpeed to 0 if no keys are pressed
        }

        animator.SetFloat("Speed", Mathf.Abs(moveSpeed));

        Vector3 movement = new Vector3(direction * moveSpeed * Time.deltaTime, 0f, 0f);
        transform.Translate(movement);
    }
}
