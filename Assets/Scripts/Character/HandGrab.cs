using UnityEngine;
using System.Linq;

public class HandGrab : MonoBehaviour
{
    [SerializeField]
    CircleCollider2D leftHandCollider;
    
    [SerializeField]
    CircleCollider2D rightHandCollider;
    
    [SerializeField]
    GameObject[] chains;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < chains.Length; i++)
            {
                if (leftHandCollider.bounds.Contains(chains[i].GetComponent<Collider2D>().bounds.center))
                {
                    chains[i].GetComponent<ChainDrag>().StartDragging(leftHandCollider.attachedRigidbody);
                    Debug.Log("Left hand grabbed the chain");
                }
                else if (rightHandCollider.bounds.Contains(chains[i].GetComponent<Collider2D>().bounds.center))
                {
                    chains[i].GetComponent<ChainDrag>().StartDragging(rightHandCollider.attachedRigidbody);
                    Debug.Log("Right hand grabbed the chain");
                }
            }
        }

        if(Input.GetMouseButtonUp(0))
        {
            for (int i = 0; i < chains.Length; i++)
            {
                chains[i].GetComponent<ChainDrag>().StopDragging();
            }
        }
    }
}