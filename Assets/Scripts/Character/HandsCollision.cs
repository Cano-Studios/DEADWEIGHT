using UnityEngine;

public class HandsCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // TODO: It would be nice if hands would collide but currently they can launch the player and do other stuff
            Physics2D.IgnoreCollision(other.collider, GetComponent<Collider2D>());
        }else if (other.gameObject.CompareTag("Chain"))
        {
            Physics2D.IgnoreCollision(other.collider, GetComponent<Collider2D>());
        }else if (other.gameObject.CompareTag("Robot"))
        {
            Physics2D.IgnoreCollision(other.collider, GetComponent<Collider2D>());
        }
    }
}