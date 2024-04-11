using PlayFab;
using PlayFab.ClientModels;
using PlayFab.MultiplayerModels;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayfabLogin : MonoBehaviour
{
    public Text messageText;
    public InputField email;
    public InputField password;
    public void LoginButton(){
        var request= new LoginWithEmailAddressRequest{
            Email= email.text,
            Password= password.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnSuccess, OnError);
    }
    void OnSuccess(LoginResult request){
        Debug.Log("Login Successful, information retreived from the database!");
        if (messageText != null)
            messageText.text = "Login Successful"; // Update UI message if messageText is not null
    }
    void OnError(PlayFabError error){
        Debug.Log("Error in creation: " + error.GenerateErrorReport());
        if (messageText != null)
            messageText.text = error.ErrorMessage; // Update UI message with error if messageText is not null
    }
}