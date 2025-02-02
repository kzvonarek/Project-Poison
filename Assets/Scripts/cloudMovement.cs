using UnityEngine;

public class cloudMovement : MonoBehaviour
{
    [SerializeField] GameObject player;

    // cloud movement
    [SerializeField] float baseSpeed; // speed to follow player
    [SerializeField] float maxSpeed; // max speed to follow player
    [SerializeField] float yDistFromPlayer; // offset above player
    [SerializeField] float yLerpSpeed;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // get player position
        Vector2 targetPosition = player.transform.position;

        // calculate horizontal velocity
        float distanceX = Mathf.Abs(targetPosition.x - transform.position.x);
        float speedMultiplier = Mathf.Clamp(distanceX * 0.5f, 1f, maxSpeed); // increases speed if far from player
        float targetVelocityX = Mathf.Lerp(rb.linearVelocity.x, (targetPosition.x - transform.position.x) * baseSpeed * speedMultiplier, 0.1f);

        // apply horizontal velocity
        rb.linearVelocity = new Vector2(targetVelocityX, rb.linearVelocity.y);

        // adjust y dist of cloud from player
        transform.position = new Vector2(transform.position.x, player.transform.position.y + yDistFromPlayer);
    }
}