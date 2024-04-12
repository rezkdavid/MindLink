using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMode : MonoBehaviour
{
    public Button endButton;
    // Start is called before the first frame update
    void Start()
    {
        endButton.onClick.AddListener(moveToDashBoard);
    }
    public void moveToDashBoard(){
        SceneManager.LoadScene("End Card Screen");

    }

}
