using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    Vector3 mousePos;
    public float moveSpeed = 0.1f;
    Rigidbody2D rb;

    [SerializeField]
    CircleCollider2D circleBounds;
    Vector2 position = new Vector2(0f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        rb.position = circleBounds.bounds.center;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (!circleBounds.bounds.Contains(mousePos))
        {
            mousePos = circleBounds.bounds.ClosestPoint(mousePos);
        }
        position = Vector2.Lerp(transform.position, mousePos, moveSpeed);
    }

    void FixedUpdate()
    {
        rb.MovePosition(position);

        // TODO: Make rotation better
        // Calculate the direction to the mouse position
        Vector2 direction = (Vector2)mousePos - rb.position;

        // Calculate the angle to the mouse position
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Apply the rotation to the rigidbody
        rb.rotation = angle;
    }
    
}
