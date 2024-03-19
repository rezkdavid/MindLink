using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public GameObject buttonToShow;
    public GameObject buttonToShow2;

    private bool movementStopped = false;

    // This method is called when a collision is detected
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with an object tagged as "Player"
        if (collision.gameObject.CompareTag("Goal"))
        {
            Debug.Log("Collision detected with player.");
            // Stop movement
            movementStopped = true;

            // Show the buttons
            buttonToShow.SetActive(true);
            buttonToShow2.SetActive(true);
            Debug.Log("Buttons activated.");
        }
    }

    // Update is called once per frame
    private void Update()
    {
        // Check if movement is stopped
        if (movementStopped)
        {
            // Stop the movement of the GameObject
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.velocity = Vector2.zero;
        }
    }

    // Method to replay the current level
    public void ReplayLevel()
    {
        SceneManager.LoadScene("Level1");
    }

    // Method to go back to the level selection screen
    public void GoBack()
    {
        SceneManager.LoadScene("Level Select Screen");
    }
}
