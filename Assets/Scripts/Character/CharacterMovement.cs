using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Vector2 speed = new Vector2(50, 100);
    public Rigidbody2D rb;
    public bool isJumping = false;
    public bool isGrounded = false;
    private float coyoteTime = 0.1f;
    private float coyoteTimeCounter;
    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;
    public float jumpStartTime;
    private float jumpTime;
    private float lastSmokeTime = -1f;
    public static float smokeCooldown = 1f;


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

        // Update jump buffer timer
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpBufferCounter = jumpBufferTime;
            jumpTime = jumpStartTime;
        }
        else
            jumpBufferCounter -= Time.deltaTime;

        if (jumpBufferCounter > 0f && (coyoteTimeCounter > 0f || !isJumping))
        {
            AudioManager.Instance.PlayJumpSound();
            rb.velocity = new Vector2(rb.velocity.x, speed.y);
            isJumping = true;
            jumpBufferCounter = 0f;
        }

        // charge jump
        if(Input.GetButton("Jump") && isJumping)
        {
            if (jumpTime > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, speed.y);
                jumpTime -= Time.deltaTime;
            
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            jumpTime = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {   
            isGrounded = true;
            isJumping = false;
            if (Time.time - lastSmokeTime > smokeCooldown)
            {
                ParticleManager.Instance.CreateSmoke(other.GetContact(0).point);
                lastSmokeTime = Time.time;
            }
        }else if (other.gameObject.CompareTag("Chain"))
        {
            Physics2D.IgnoreCollision(other.collider, GetComponent<Collider2D>());
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            isJumping = false;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") && !isJumping)
        {
            isGrounded = false;
            isJumping = true;
        }
    }
}
