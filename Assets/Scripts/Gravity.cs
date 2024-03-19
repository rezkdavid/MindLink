using UnityEngine;

public class Gravity : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D playerCollider;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
        if (IsOnPlatform())
        {
            // Disable gravity if the player is on the platform
            rb.gravityScale = 0f;
        }
        else
        {
            // Enable gravity if the player is not on the platform
            rb.gravityScale = 1f;
        }
    }

    private bool IsOnPlatform()
    {
        // Cast a ray downwards from the player's position to detect if it's on the platform
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, playerCollider.bounds.extents.y + 0.1f);

        // Check if the ray hits the platform and the platform effector is affecting it
        return hit.collider != null && hit.collider.CompareTag("Platform") && hit.collider.GetComponent<PlatformEffector2D>() != null;
    }
}
