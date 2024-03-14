using UnityEngine;

public class StopOnCollision : MonoBehaviour
{
    public Rigidbody rb;

    void Start()
    {
        // Get the Rigidbody2D component attached to the GameObject
        rb = GetComponent<Rigidbody>();
    }

    // This method is called when the GameObject collides with another GameObject
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding GameObject has a BoxCollider2D
        if (collision.gameObject.GetComponent<BoxCollider2D>() != null)
        {
            // Stop the movement if collided with another object
            StopMovement();
        }
    }

    // Stops the movement of the GameObject
    private void StopMovement()
    {
        // Check if the Rigidbody2D component is not null
        if (rb != null)
        {
            // Set velocity to zero to stop movement
            rb.velocity = Vector2.zero;
            // Optionally, you can set other properties to stop rotation or other movements
            rb.angularVelocity = 0f;
        }
        else
        {
            Debug.LogWarning("Rigidbody2D component not found on object: " + gameObject.name);
        }
    }
}
