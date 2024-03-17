using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndCard : MonoBehaviour
{
    public Button playAgainButton;
    public Button quitButton;
    // Start is called before the first frame update
    void Start()
    {
        playAgainButton.onClick.AddListener(moveToGameMode);
        quitButton.onClick.AddListener(moveToTitleScreen);
        
    }
    public void moveToGameMode(){
        SceneManager.LoadScene("Game Screen");
    }
    public void moveToTitleScreen(){
        SceneManager.LoadScene("Title Screen");
    }
}
