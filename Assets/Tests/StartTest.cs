using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class StartTest
{
    [UnityTest]
    public IEnumerator StartButtonToLevelSelectScreen()
    {
        SceneManager.LoadScene("Title Screen");

        yield return null;

        Button buttonComponent = GameObject.Find("Start Button").GetComponent<Button>();

        buttonComponent.onClick.Invoke();

        yield return null;

        // Check if the scene is now "Level Select Screen"
        Assert.AreEqual("Level Select Screen", SceneManager.GetActiveScene().name);
    }
}
