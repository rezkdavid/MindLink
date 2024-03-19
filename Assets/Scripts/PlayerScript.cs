using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the speed as needed

    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component

    void Start()
    {
        // Get the SpriteRenderer component attached to the GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Get the horizontal input (A/D keys or left/right arrow keys)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate the movement direction based on the input
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f);

        // Move the player object
        transform.Translate(movement * moveSpeed * Time.deltaTime);

 
    }

    // Function to flip the sprite
    void FlipSprite()
    {
        // Get the current scale
        Vector3 scale = transform.localScale;

        // Flip the X scale
        scale.x *= -1;

        // Apply the new scale
        transform.localScale = scale;
    }
}
