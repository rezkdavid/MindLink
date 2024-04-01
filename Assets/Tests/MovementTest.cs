using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;
using UnityEngine.SceneManagement;


public class MovementTest
{
    [UnityTest]
    public IEnumerator ObjectMovesLeftWhenAIsPressed()
    {
        SceneManager.LoadScene("Level1");
        yield return new WaitForFixedUpdate();
        GameObject testObject = new GameObject();
        Rigidbody2D rb = testObject.AddComponent<Rigidbody2D>();
        PlayerScript playerScript = testObject.AddComponent<PlayerScript>();
        yield return PressKey(KeyCode.A);
        Assert.Less(rb.position.x, 0f);
        GameObject.Destroy(testObject);
    }

    [UnityTest]
    public IEnumerator ObjectMovesRightWhenDIsPressed()
    {
        SceneManager.LoadScene("Level1");
        yield return new WaitForFixedUpdate();
        GameObject testObject = new GameObject();
        Rigidbody2D rb = testObject.AddComponent<Rigidbody2D>();
        PlayerScript playerScript = testObject.AddComponent<PlayerScript>();
        yield return PressKey(KeyCode.D);
        Assert.Greater(rb.position.x, 0f);
        GameObject.Destroy(testObject);
    }

    private IEnumerator PressKey(KeyCode key)
    {
        Input.GetKeyDown(key);
        yield return new WaitForSeconds(5.0f);
    }
}
