using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    public enum MovementType { Horizontal, Vertical, Rising } // === x, z, y ===
    public MovementType movementType;

    public float moveTime = 4.0f;
    private float timer = 0f;

    private Vector3 startPoint;
    private Vector3 endPoint;
    public float endOffset = 3.0f;

    void Start()
    {
        startPoint = transform.position;

        if (movementType == MovementType.Horizontal)
        {
            endPoint = startPoint + Vector3.right * endOffset;
        }
        else if (movementType == MovementType.Vertical)
        {
            endPoint = startPoint + Vector3.forward * endOffset;
        }
        else if (movementType == MovementType.Rising)
        {
            endPoint = startPoint + Vector3.up * endOffset;
        }

    }

    void Update()
    {
        timer += Time.deltaTime;

        float t = Mathf.PingPong(timer, moveTime) / moveTime;

        Vector3 newPosition = Vector3.Lerp(startPoint, endPoint, t);

        transform.position = newPosition;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
