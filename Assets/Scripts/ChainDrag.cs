using UnityEngine;

public class ChainDrag : MonoBehaviour
{
    private bool isDragging;
    private Vector2 mousePosition;
    private Rigidbody2D rb;
    private Rigidbody2D rbToFollow;
    [SerializeField]
    private float throwValue;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void StartDragging(Rigidbody2D rigidBody)
    {
        isDragging = true;
        rbToFollow = rigidBody;
    }

    public void StopDragging()
    {
        isDragging = false;
        rbToFollow = null;
    }

    void Update()
    {
        if (isDragging)
        {
            rb.velocity = (rbToFollow.position - rb.position) * throwValue;
            //rb.position = rbToFollow.position;
        }
    }

    
}