using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Movement inspired by @see: https://www.youtube.com/watch?v=FXqwunFQuao

    public float followSpeed = 2f;
    public float yOffset = 1f;
    public Transform target;

    private void Update()
    {
        Vector3 newPosition = new Vector3(target.position.x, target.position.y + yOffset, -10f);
        transform.position = Vector3.Lerp(transform.position, newPosition, followSpeed * Time.deltaTime);
    }
}
