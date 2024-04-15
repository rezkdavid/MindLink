using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public GameObject buttonToShow;
    public GameObject buttonToShow2;

    private bool movementStopped = false;

    private void Start()
    {
       Time.timeScale = 1f;
       movementStopped = false;
    }

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

    private void Update()
{
    if (movementStopped == true)
    {
        Time.timeScale = 0f;
    }
   
}

    // Method to replay the current level
   public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Method to go back to the level selection screen
    public void GoBack()
    {
        SceneManager.LoadScene("Level Select Screen");
    }
}
