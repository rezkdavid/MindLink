using UnityEngine;

public class Teleport : MonoBehaviour
{
    // Coordinates where the player will be teleported
    public Vector3 teleportCoordinates = new Vector3(40f, -2.08f, -0.067f);

    // Tag to identify player objects
    public string playerTag = "Player";

    // Tag to identify teleporter objects
    public string teleporterTag = "Teleporter";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object has the tag "Teleporter"
        if (collision.gameObject.CompareTag(playerTag))
        {
            Debug.Log("Teleportation Triggered by object with tag: " + teleporterTag);

            // Find the player object dynamically
            GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);

            // Teleport the player to the specified coordinates
            if (playerObject != null)
            {
                playerObject.transform.position = teleportCoordinates;
                Debug.Log("Teleported player to coordinates: " + teleportCoordinates);
            }
            else
            {
                Debug.LogWarning("Player object not found with tag: " + playerTag);
            }
        }
        else
        {
            Debug.Log("Collision with object that does not have tag: " + teleporterTag);
        }
    }
}
