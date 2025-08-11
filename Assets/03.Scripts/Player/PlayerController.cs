using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Move")]   // === �̵� ���� ===

    [SerializeField]
    private float _speed = 2.0f;
    private Vector2 _movementInput;

    [SerializeField]   // === ���� ===
    private float _jumpForce = 6.5f;
    public LayerMask groundLayerMask;
    // === ������ ���� ===
    public bool _is_Jump_Boost = false;
    public float jumpBoostDuration = 3f;
    private Coroutine _coroutine;

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

    private void LateUpdate()
    {
        CameraLook();
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

    // === ī�޶� �̵� ===
    void CameraLook()
    {
        _cameraXRot += _mouseDelta.y * _lookSensitivity;
        _cameraXRot = Mathf.Clamp(_cameraXRot, _minXLook, _maxXLook);
        cameraBox.localEulerAngles = new Vector3(-_cameraXRot, 0, 0);

        transform.eulerAngles += new Vector3(0, _mouseDelta.x * _lookSensitivity, 0);
    }

    // === ī�޶� �Է°� ===
    public void OnLookInput(InputAction.CallbackContext context)
    {
        _mouseDelta = context.ReadValue<Vector2>();
    }

    // === EŰ�� ���� ������ ��� ===
    public void OnUseInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed) 
        {
            if (Inventory.Instance.inventory != null)
            {
                Inventory.Instance.UseItem();
                _coroutine = StartCoroutine(JumpBoostCoroutine());
            }
        }
    }

    // === �Է½� ���� ===
    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && IsGrounded())
        {
            if (_is_Jump_Boost == false) 
            {
                GetComponent<Rigidbody>().AddForce(Vector2.up * _jumpForce, ForceMode.Impulse);
            }
            else 
            {
                GetComponent<Rigidbody>().AddForce(_jumpForce * 2 * Vector2.up, ForceMode.Impulse);
            }
        }
    }

    IEnumerator JumpBoostCoroutine()
    {
        // ���� �ν�Ʈ Ȱ��ȭ
        _is_Jump_Boost = true;

        yield return new WaitForSeconds(jumpBoostDuration);

        _is_Jump_Boost = false;
    }

    // === ������ �Ǻ� ===
    bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.01f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.01f) + (transform.up * 0.01f),Vector3.down),
            new Ray(transform.position + (transform.right * 0.01f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.01f) +(transform.up * 0.01f), Vector3.down)
        };

        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 1.0f, groundLayerMask))
            {
                return true;  // === groundLayerMask�� ��� ===
            }
        }

        return false;        // === groundLayerMask�� �ƴҰ�� ===
    }
}
