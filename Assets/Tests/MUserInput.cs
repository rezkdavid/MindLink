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
   //public UserDataHolder userDataHolder;


   ArrayList credentials;
   void Start(){
    if (File.Exists(Application.dataPath + "/userInfo.txt"))
        {

            credentials = new ArrayList(File.ReadAllLines(Application.dataPath + "/userInfo.txt"));
        }
        else
        {
            Debug.Log("Credential file doesn't exist");
        }
    //okButton.onClick.AddListener(loadUser);
    
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
                //userDataHolder.userName = line.Substring(line.IndexOf(":") + 1).Trim();   
                break;
            }
        }
        if (isExists)
        {
            // creating a log for backend
            Debug.Log($"Logging in '{userID.text}'");
            // when clicked play button, it moves to the next scene, which is game scene.
            SceneManager.LoadScene("Level Select Screen");
        }
        else
        {
            Debug.Log("Incorrect credentials");
        }
   }

}

