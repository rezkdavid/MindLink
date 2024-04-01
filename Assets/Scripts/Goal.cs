using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public GameObject buttonToShow;
    public GameObject buttonToShow2;

    private bool movementStopped = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            movementStopped = true;
            buttonToShow.SetActive(true);
            buttonToShow2.SetActive(true);
        }
    }

    private void Update()
    {
        if (movementStopped)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.velocity = Vector2.zero;
        }
    }

    public void ReplayCurrentLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void GoBack()
    {
        SceneManager.LoadScene("Level Select Screen");
    }
}
