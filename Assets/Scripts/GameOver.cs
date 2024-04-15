using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject gameOverCanvas; 

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
        gameOverCanvas.SetActive(true);  
        Time.timeScale = 0f; 
    }
}
