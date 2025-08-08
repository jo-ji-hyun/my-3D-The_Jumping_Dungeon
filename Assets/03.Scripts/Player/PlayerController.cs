using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Move")]    // === �̵� ���� ===

    [SerializeField]
    private float _speed = 2.0f;
    private Vector2 _movementInput;

    [SerializeField]
    private float _jumpForce;
    public LayerMask groundLayerMask;

    [Header("Look")]   // === ī�޶� ���� ===
    public Transform cameraBox;

    private float _minXLook = -65.0f;
    private float _maxXLook = +65.0f;
    private float _cameraXRot;

    private float _lookSensitivity = 0.1f;
    private Vector2 _mouseDelta;

    // === �� �� ===
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }

    // === �̵� ===
    private void Move()
    {
        Vector3 dir = transform.forward * _movementInput.y + transform.right * _movementInput.x;
        dir *= _speed;
        dir.y = GetComponent<Rigidbody>().velocity.y;

        GetComponent<Rigidbody>().velocity = dir;
    }

    // === �Է½� �̵� ===
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            _movementInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            _movementInput = Vector2.zero;
        }
    }



}
