using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayfabRegister : MonoBehaviour
{
    [Header("UI")]
    public Text messageText; // Assign this in the Unity Editor
    public InputField email;
    public InputField fullName;
    public InputField password;
    public InputField userName;

    public void RegisterButton()
    {
        Debug.Log(email.text);
        Debug.Log(password.text);
        Debug.Log(userName.text);
        Debug.Log(fullName.text);
        //Debuglog(email.text);
        
        
        var request = new RegisterPlayFabUserRequest
        {
            Email = email.text,
            Password = password.text,
            Username = userName.text,
            DisplayName= fullName.text,
            RequireBothUsernameAndEmail = false // Only email is required
        };
        
        PlayFabClientAPI.RegisterPlayFabUser(request, OnSuccess, OnError);
    }

    void OnSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("Registered to the database!");
        if (messageText != null)
            messageText.text = "Account Registered"; // Update UI message if messageText is not null
    }

    void OnError(PlayFabError error)
    {
        if (messageText != null)
            messageText.text = error.ErrorMessage; // Update UI message with error if messageText is not null
        Debug.Log("Error in creation: " + error.GenerateErrorReport());
    }
}
