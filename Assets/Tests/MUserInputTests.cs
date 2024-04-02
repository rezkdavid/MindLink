using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;
using System.Collections;

public class MUserInputTests
{
    private MUserInput mUserInput;

    
    [UnityTest]
    public IEnumerator ClickOkButton_LoadsLevelSelectionScreen()
    {
        // Load the scene containing the MUserInput script and the LevelSelectionScreen scene
        Debug.Log("Loading UserType Screen...");
        SceneManager.LoadScene("UserType Screen");
        Debug.Log("Scene loaded.");

        // Wait for the scene to be loaded
        yield return null;

        mUserInput = GameObject.FindObjectOfType<MUserInput>();
        if (mUserInput == null)
        {
            Debug.LogError("MUserInput script not found in the scene.");
            yield break;
        }

        Debug.Log("Finding MindLink User Button...");
        // Find and click the button component to trigger the action
        Button buttonComponent = GameObject.Find("MindLink User Button").GetComponent<Button>();
        buttonComponent.onClick.Invoke();
        Debug.Log("MindLink User Button clicked.");

        // Wait for a frame to allow the scene transition
        yield return null;

        Debug.Log("Finding User ID Input...");
        // Find the input field for user ID
        InputField userInputField = GameObject.Find("User ID Input").GetComponent<InputField>();
        Debug.Log("User ID Input found.");

        // Set the text of the input field to "vishnu"
        userInputField.text = "vishnu";
        Debug.Log("User ID set to 'vishnu'.");

        Debug.Log("Finding Ok Button...");
        // Find and click the Ok button
        Button okButton = GameObject.Find("Ok Button").GetComponent<Button>();
        okButton.onClick.Invoke();
        Debug.Log("Ok Button clicked.");

        // Wait for the scene to change
        yield return null;

        Debug.Log("Asserting scene name...");
        // Check if the current scene is now the LevelSelectionScreen
        Debug.Log("Current scene name: " + SceneManager.GetActiveScene().name);
        Assert.AreEqual("Level Select Screen", SceneManager.GetActiveScene().name);
        Debug.Log("Scene name assertion passed.");

    }
}
