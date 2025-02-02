using UnityEngine;

public class cloudMovement : MonoBehaviour
{
    [SerializeField] GameObject player;

    // cloud movement
    [SerializeField] float speed; // speed to follow player
    [SerializeField] float maxSpeed; // max speed to follow player
    [SerializeField] float yDistFromPlayer;
    private float horizVelocity;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // get player position
        Vector2 targetPosition = player.transform.position;

        // calculate velocity to follow player
        float targetVelocity = (targetPosition.x - transform.position.x) * speed;
        horizVelocity = Mathf.Clamp(targetVelocity, -maxSpeed, maxSpeed);
    }

    void FixedUpdate()
    {
        // apply velocity to cloud
        transform.position = new Vector2(transform.position.x + horizVelocity * Time.deltaTime, player.transform.position.y + yDistFromPlayer);
    }
}