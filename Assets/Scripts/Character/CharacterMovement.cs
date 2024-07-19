using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Vector2 speed = new Vector2(50, 50);
    public Rigidbody2D rb;
    public bool isJumping;

    void Start()
    {
        rb.velocity = new Vector2(0, 0);
    }
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed.x * inputX, rb.velocity.y);
        if (!isJumping && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, speed.y);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
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
            // coyote jump
            isJumping = true;
            Invoke("SetJumping", 0.5f);
        }
    }

    void SetJumping()
    {
        isJumping = true;
    }
}