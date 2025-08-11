using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

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
    // === ��Ÿ�� �ð� ===
    public Image flashimage;
    public float flashSpeed;

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
        if (context.phase == InputActionPhase.Started && _is_Jump_Boost == false) 
        {
            if (Inventory.Instance.inventory.Count > 0)
            {
                _coroutine = StartCoroutine(JumpBoostCoroutine());
            }
        }
    }

    // === �Է½� ���� ===
    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && IsGrounded() && GameManager.Instance.PlayerManager.curStamina >= GameManager.Instance.PlayerManager.maxStamina)
        {
            GameManager.Instance.PlayerManager.curStamina = 0;

            if (_is_Jump_Boost == false) 
            {
                GetComponent<Rigidbody>().AddForce(Vector2.up * _jumpForce, ForceMode.Impulse);
            }
            else 
            {
                GetComponent<Rigidbody>().AddForce(_jumpForce * 2 * Vector2.up, ForceMode.Impulse);
                _is_Jump_Boost = false;
            }
        }
    }

    IEnumerator JumpBoostCoroutine()
    {
        // ���� �ν�Ʈ Ȱ��ȭ
        _is_Jump_Boost = true;

        Flash();

        yield return new WaitForSeconds(jumpBoostDuration);

        Inventory.Instance.UseItem();

    }

    // === ȭ�� ��½�� �޼��� ===
    void Flash()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        flashimage.enabled = true;
        flashimage.color = new Color(0, 0, 1f);
        _coroutine = StartCoroutine(FadeAway());
    }

    // === ȭ���� ��½�� �ڷ�ƾ ===
    private IEnumerator FadeAway()
    {
        flashSpeed = 0.5f;

        // === ȭ�� ������ ===
        float startAlpa = 0.3f;
        float a = startAlpa;

        while (a > 0)
        {
            a -= (startAlpa / flashSpeed) * Time.deltaTime;
            flashimage.color = new Color(0, 0, 1f, a);
            yield return null;
        }

        yield return new WaitForSeconds(flashSpeed);

        flashimage.enabled = false;
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
