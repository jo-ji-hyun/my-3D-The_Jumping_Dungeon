using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Move")]    // === 이동 관련 ===

    [SerializeField]
    private float _speed = 2.0f;
    private Vector2 _movementInput;

    [SerializeField]
    private float _jumpForce;
    public LayerMask groundLayerMask;

    [Header("Look")]   // === 카메라 관련 ===
    public Transform cameraBox;

    private float _minXLook = -65.0f;
    private float _maxXLook = +65.0f;
    private float _cameraXRot;

    private float _lookSensitivity = 0.1f;
    private Vector2 _mouseDelta;

    // === 그 외 ===
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }

    private void LateUpdate()
    {
        CameraLook();
    }

    // === 이동 ===
    private void Move()
    {
        Vector3 dir = transform.forward * _movementInput.y + transform.right * _movementInput.x;
        dir *= _speed;
        dir.y = GetComponent<Rigidbody>().velocity.y;

        GetComponent<Rigidbody>().velocity = dir;
    }

    // === 입력시 이동 ===
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

    // === 카메라 이동 ===
    void CameraLook()
    {
        _cameraXRot += _mouseDelta.y * _lookSensitivity;
        _cameraXRot = Mathf.Clamp(_cameraXRot, _minXLook, _maxXLook);
        cameraBox.localEulerAngles = new Vector3(-_cameraXRot, 0, 0);

        transform.eulerAngles += new Vector3(0, _mouseDelta.x * _lookSensitivity, 0);
    }

    // === 카메라 입력값 ===
    public void OnLookInput(InputAction.CallbackContext context)
    {
        _mouseDelta = context.ReadValue<Vector2>();
    }
}
