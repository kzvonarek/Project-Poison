using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // movement variables
    private float horizVeloc;
    [SerializeField] float speed;
    [SerializeField] float jumpingPower;

    // player object variables
    private Rigidbody2D rb;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    private bool isFacingRight = true;

    void Start()
    {
        Application.targetFrameRate = 60; // move to Game Manager script

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // move direction
        horizVeloc = Input.GetAxisRaw("Horizontal");

        // player jump
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            if (IsGrounded())
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
            }
        }

        // control jump height
        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        // horizontal movement
        rb.linearVelocity = new Vector2(horizVeloc * speed, rb.linearVelocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizVeloc < 0f || !isFacingRight && horizVeloc > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}