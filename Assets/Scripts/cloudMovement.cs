using System.Threading;
using UnityEngine;

public class cloudMovement : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Camera mainCamera;

    // cloud movement
    [SerializeField] float baseSpeed; // speed to follow player
    [SerializeField] float maxSpeed; // max speed to follow player
    [SerializeField] float yDistFromPlayer; // offset above player
    [SerializeField] float yLerpSpeed;
    private Rigidbody2D rb;

    // movement by mouse, on click
    bool mouseControl = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (mouseControl == false)
        {// get player position
            Vector2 targetPosition = player.transform.position;

            // calculate horizontal velocity
            float distanceX = Mathf.Abs(targetPosition.x - transform.position.x);
            float speedMultiplier = Mathf.Clamp(distanceX * 0.5f, 1f, maxSpeed); // increases speed if far from player
            float targetVelocityX = Mathf.Lerp(rb.linearVelocity.x, (targetPosition.x - transform.position.x) * baseSpeed * speedMultiplier, 0.1f);

            // apply horizontal velocity
            rb.linearVelocity = new Vector2(targetVelocityX, rb.linearVelocity.y);

            // // adjust y dist of cloud from player
            // transform.position = new Vector2(transform.position.x, player.transform.position.y + yDistFromPlayer);

            // smooth y-movement
            float targetY = targetPosition.y + yDistFromPlayer;
            float smoothedY = Mathf.Lerp(transform.position.y, targetY, Time.fixedDeltaTime * yLerpSpeed);
            transform.position = new Vector2(transform.position.x, smoothedY);

        }
        else
        {
            Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
            mouseWorldPosition.z = 0; // ensure correct 2D plane
            rb.MovePosition(mouseWorldPosition);
        }
    }

    void OnMouseDown()
    {
        mouseControl = true;
    }

    void OnMouseUp()
    {
        mouseControl = false;
    }
}