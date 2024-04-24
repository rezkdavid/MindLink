using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform leftObject;
    public Transform rightObject;
    public float speed = 2f;

    private bool movingRight = false;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector3 targetPosition = movingRight ? rightObject.position : leftObject.position;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (transform.position == leftObject.position)
        {
            movingRight = true;
            FlipSprite();
        }
        else if (transform.position == rightObject.position)
        {
            movingRight = false;
            FlipSprite();
        }
    }

    void FlipSprite()
    {
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
}
