using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 5f;

    private SpriteRenderer spriteRenderer; 

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float direction = 0f;
        if (Input.GetKey(KeyCode.A))
            direction = -1f; // Move left when 'A' is pressed
        else if (Input.GetKey(KeyCode.D))
            direction = 1f; // Move right when 'D' is pressed

        // Move the player horizontally
        Vector3 movement = new Vector3(direction * moveSpeed * Time.deltaTime, 0f, 0f);
        transform.Translate(movement);
    }

}