using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenuCanvas;
    private bool isPaused = false;
    //public bool ResumeButton;

    void Update()
    {
        // Check if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // If the game is not already paused, pause it
            if (!isPaused)
            {
                PauseGame();
            }
            // If the game is already paused, resume it
            else
            {
                ResumeGame();
            }
        }
    }

    void PauseGame()
    {
        // Show the pause menu canvas
        pauseMenuCanvas.SetActive(true);
        // Freeze the game
        Time.timeScale = 0f;
        // Set the pause state to true
        isPaused = true;
    }

    public void RestartGame()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ResumeGame()
    {
        // Hide the pause menu canvas
        pauseMenuCanvas.SetActive(false);
        // Unfreeze the game
        Time.timeScale = 1f;
        // Set the pause state to false
        isPaused = false;
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Level Select Screen");
    }
}
