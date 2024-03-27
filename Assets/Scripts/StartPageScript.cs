using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartingScreenScript : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("Level Select Screen");
    }
    public void quitGame()
    {
        Application.Quit();
        Debug.Log("Exited the application");
    }

    public void returntoStart()
    {
        SceneManager.LoadScene("Title Screen");
    }
}

