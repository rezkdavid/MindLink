using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MUserInput : MonoBehaviour
{
   public Button okButton;
   public InputField userID;

   ArrayList credentials;
   void Start(){
    okButton.onClick.AddListener(loadUser);
    if (File.Exists(Application.dataPath + "/userInfo.txt"))
        {
            credentials = new ArrayList(File.ReadAllLines(Application.dataPath + "/userInfo.txt"));
        }
        else
        {
            Debug.Log("Credential file doesn't exist");
        }
   }
   public void loadUser(){
    bool isExists = false;
    credentials = new ArrayList(File.ReadAllLines(Application.dataPath + "/userInfo.txt"));
    foreach (var i in credentials)
        {
            string line = i.ToString();
            // check if the user exist with each line
            if (i.ToString().Substring(0, i.ToString().IndexOf(":")).Equals(userID.text))
            {
                isExists = true;
                break;
            }
        }
        if (isExists)
        {
            Debug.Log($"Logging in '{userID.text}'");
            // moving to the next screen, for now it will create a log.
            // write a code with to call method for next scene (SceneManager.LoadScene("**next scene**));
        }
        else
        {
            Debug.Log("Incorrect credentials");
        }
   }

}
