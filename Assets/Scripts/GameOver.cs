using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject gameOverCanvas; // Reference to the game over canvas

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has the "Enemy" tag
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Activate game over canvas
            ActivateGameOverScreen();
        }
    }

    void ActivateGameOverScreen()
    {
        // Enable the game over canvas
        gameOverCanvas.SetActive(true);
        
        // You might also want to pause the game or perform other actions here
        Time.timeScale = 0f; // Pause the game
    }
}
