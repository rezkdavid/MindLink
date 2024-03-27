using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Playagain : MonoBehaviour
{
  public Button playAgainButton; // Set the name of the scene to load in the Inspector

  public void Start()
  {
    playAgainButton.onClick.AddListener(moveToLevelScreen);
  }
  public void moveToLevelScreen(){
    SceneManager.LoadScene("Level Select Screen");
  }
}
