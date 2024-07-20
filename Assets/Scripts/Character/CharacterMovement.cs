using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Vector2 speed = new Vector2(50, 100);
    public Rigidbody2D rb;
    public bool isJumping = false;
    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;
    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;


    // Coyote jump based off @see: https://www.youtube.com/watch?v=RFix_Kg2Di0&t=153s
    void Start()
    {
        rb.velocity = Vector2.zero;
        coyoteTimeCounter = coyoteTime;
        jumpBufferCounter = 0f;
    }

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed.x * inputX, rb.velocity.y);

        // Update coyote timer 
        if (isJumping)
            coyoteTimeCounter -= Time.deltaTime;
        else
            coyoteTimeCounter = coyoteTime;

        // Update jump buffer timerr
        if (Input.GetButtonDown("Jump"))
            jumpBufferCounter = jumpBufferTime;
        else
            jumpBufferCounter -= Time.deltaTime;

        if (jumpBufferCounter > 0f && (coyoteTimeCounter > 0f || !isJumping))
        {
            rb.velocity = new Vector2(rb.velocity.x, speed.y);
            isJumping = true;
            jumpBufferCounter = 0f;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }else if (other.gameObject.CompareTag("Chain"))
        {
            Physics2D.IgnoreCollision(other.collider, GetComponent<Collider2D>());
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }
}
