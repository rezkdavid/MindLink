using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewUserInput : MonoBehaviour
{
    public InputField userID;
    public InputField fullName;
    public Button okButton;
    ArrayList credentials;


    void Start()
    {
        // when ok button is clicked,registerUser method is called and the data is registered to the database as arrayList
        okButton.onClick.AddListener(registerUser);
    }

    void registerUser()
    {
        bool isExists = false;
        // to check if the file exist
        if (File.Exists(Application.dataPath + "/userInfo.txt"))
        {
            // copy all the contents of the file to arraylist
            credentials = new ArrayList(File.ReadAllLines(Application.dataPath + "/userInfo.txt"));
        }
        else
        {

            // credentials = new ArrayList(); 
            // Create an empty file
            File.WriteAllText(Application.dataPath + "/userInfo.txt", ""); 
        }
        // text file content are contents are added to the arraylist
        credentials = new ArrayList(File.ReadAllLines(Application.dataPath + "/userInfo.txt"));
        foreach (var i in credentials)
        {
            if (i.ToString().Contains(userID.text)) // changed usernameInput.text to userID.text
            {
                isExists = true;
                break;
            }
        }
        if (isExists)
        {
        // if the userID exits , stops from creating ducplicates ID and prompt in log that userID exist
            Debug.Log($"Username '{userID.text}' already exists");
        }
        else
        {
        // userID is added if it does not have and update the text file
            credentials.Add(userID.text + ":" + fullName.text);
            File.WriteAllLines(Application.dataPath + "/userInfo.txt", (string[])credentials.ToArray(typeof(string)));
            Debug.Log("User Created !");
        }
    }
}
