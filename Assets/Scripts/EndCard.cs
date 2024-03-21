using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndCard : MonoBehaviour
{
    private UserDataHolder userDataHolder;
    public Button playAgainButton;
    public Button quitButton;
    public Text userFullName;
    // Start is called before the first frame update
    void Start()
    {
        userDataHolder = new UserDataHolder();
        playAgainButton.onClick.AddListener(moveToGameMode);
        quitButton.onClick.AddListener(moveToTitleScreen);
        userFullName.text= userDataHolder.userName;
        // Debug.Log("userFullName");
        
    }
    public void moveToGameMode(){
        SceneManager.LoadScene("Level Select Screen");
    }
    public void moveToTitleScreen(){
        SceneManager.LoadScene("User Type Screen");
    }
}
