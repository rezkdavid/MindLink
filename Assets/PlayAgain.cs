using UnityEngine;
using UnityEngine.UI;

public class CollisionDetector : MonoBehaviour
{
    public Button buttonToShow;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision involves the other box object
        if (collision.gameObject.CompareTag("Goal"))
        {
            // Enable the button when collision occurs
            buttonToShow.gameObject.SetActive(true);
        }
    }


}
