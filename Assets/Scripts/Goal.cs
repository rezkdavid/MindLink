using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Goal : MonoBehaviour
{
    public GameObject buttonToShow;
    public GameObject buttonToShow2;
    public TMP_Text timerText;
    public TMP_Text collisionText; 
    private bool movementStopped = false;
    private float timer = 0f;

    private void Start()
    {
        Time.timeScale = 1f;
        movementStopped = false;
        UpdateTimerDisplay();
    }

    private void Update()
    {
        if (movementStopped)
        {
            Time.timeScale = 0f;
            return;
        }

        timer += Time.deltaTime;
        UpdateTimerDisplay();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            movementStopped = true;
            ShowCollisionText(); 
            buttonToShow.SetActive(true);
            buttonToShow2.SetActive(true);
        }
    }

    private void UpdateTimerDisplay()
    {
        if (timerText != null)
        {
            timerText.text = "Time: " + timer.ToString("F2");
        }
    }

    private void ShowCollisionText()
    {
        if (collisionText != null)
        {
            collisionText.gameObject.SetActive(true);
        }
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoBack()
    {
        SceneManager.LoadScene("Level Select Screen");
    }
}
