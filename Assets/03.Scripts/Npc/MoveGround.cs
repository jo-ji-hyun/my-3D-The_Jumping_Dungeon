using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    public enum MovementType { Horizontal, Vertical, Rising } // === x, z, y ===
    public MovementType movementType;

    // === 왕복 시간 ===
    public float moveTime = 4.0f;
    private float timer = 0f;

    // === 플렛폼이 혼자서 움직일때 사용 ===
    private Vector3 startPoint;
    private Vector3 endPoint;
    public float endOffset = 3.0f;
    private Rigidbody _rb;

    // === 이전 위치 ===
    private Vector3 _previous_Pos;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _previous_Pos = transform.position;
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

        _previous_Pos = newPosition;

        _rb.MovePosition(newPosition);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();

            if (playerRb != null)
            {
                playerRb.position = _previous_Pos;
            }
        }
    }
}
