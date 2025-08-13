using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    public enum MovementType { Horizontal, Vertical, Rising } // === x, z, y ===
    public MovementType movementType;

    // === �պ� �ð� ===
    public float moveTime = 4.0f;
    private float timer = 0f;

    // === �÷����� ȥ�ڼ� �����϶� ��� ===
    private Vector3 startPoint;
    private Vector3 endPoint;
    public float endOffset = 3.0f;
    private Rigidbody _rb;

    // === ���� ��ġ ===
    private Vector3 _platform_Velocity;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
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

    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;

        float t = Mathf.PingPong(timer, moveTime) / moveTime;

        Vector3 newPosition = Vector3.Lerp(startPoint, endPoint, t);

        _rb.MovePosition(newPosition);
    }
}
