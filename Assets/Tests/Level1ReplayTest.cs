using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using System.Collections;

public class Level1ReplayTest
{
    [UnityTest]
    public IEnumerator ReplayButtonLoadsLevel1()
    {
        SceneManager.LoadScene("Level1");
        yield return new WaitForSeconds(5); 

        GameObject replayButton = GameObject.Find("Replay");

        Assert.IsNotNull(replayButton, "Replay button not found in the scene.");

        replayButton.SetActive(true);

        UnityEngine.UI.Button buttonComponent = replayButton.GetComponent<UnityEngine.UI.Button>();

        buttonComponent.onClick.Invoke();

        yield return new WaitForSeconds(3); 
        Assert.AreEqual("Level1", SceneManager.GetActiveScene().name, "Level 1 scene was not loaded after clicking the replay button.");
    }
}
