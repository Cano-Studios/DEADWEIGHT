using UnityEngine;

public class RobotCollision : MonoBehaviour
{    
    private float lastSmokeTime = -1f;
    public static float smokeCooldown = 1f;
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Chain"))
        {
            Physics2D.IgnoreCollision(other.collider, GetComponent<Collider2D>());
        }else if (other.gameObject.CompareTag("Ground"))
        {
           if (Time.time - lastSmokeTime > smokeCooldown)
            {
                ParticleManager.Instance.CreateSmoke(other.GetContact(0).point);
                lastSmokeTime = Time.time;
            }
        }
    }
}