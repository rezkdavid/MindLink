using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackTest
{
    [UnityTest]
    public IEnumerator BackButtontoTitleScreen()
    {
        SceneManager.LoadScene("Level Select Screen");

        yield return null;

        Button buttonComponent = GameObject.Find("Back Button").GetComponent<Button>();

        buttonComponent.onClick.Invoke();

        yield return null;

        // Check if the scene is now "Title Screen"
        Assert.AreEqual("Title Screen", SceneManager.GetActiveScene().name);
    }
}
