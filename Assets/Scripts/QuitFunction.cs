using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuitFunction : MonoBehaviour
{
  public Button quitButton; // Set the name of the scene to load in the Inspector

  public void Start()
  {
    quitButton.onClick.AddListener(moveToMUserScreen);
  }
  public void moveToMUserScreen(){
    SceneManager.LoadScene("MUserInput Screen");
  }
}
