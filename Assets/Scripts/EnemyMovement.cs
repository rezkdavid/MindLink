using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform leftObject;  // The leftmost object
    public Transform rightObject; // The rightmost object
    public float speed = 2f;     // Movement speed

    private bool movingRight = true;

    void Update()
    {
        // Determine the target position based on the direction
        Vector3 targetPosition = movingRight ? rightObject.position : leftObject.position;

        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // If the object reaches one of the limits, change direction
        if (transform.position == leftObject.position)
        {
            movingRight = true;
            
        }
        else if (transform.position == rightObject.position)
        {
            movingRight = false;
        }
    }
}
