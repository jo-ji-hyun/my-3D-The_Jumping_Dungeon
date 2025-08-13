using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Move")]   // === 이동 관련 ===

    [SerializeField]
    private float _speed = 2.0f;
    private Vector2 _movementInput;

    [SerializeField]   // === 점프 ===
    private float _jumpForce = 6.5f;
    public LayerMask groundLayerMask;
    // === 아이템 사용시 ===
    public bool _is_Jump_Boost = false;
    public float jumpBoostDuration = 3f;
    private Coroutine _coroutine;
    // === 나타낼 시간 ===
    public Image flashimage;
    public float flashSpeed;

    [Header("Look")]   // === 카메라 관련 ===
    public Transform cameraBox;     // 메인
    public Transform secondcamera;   // 3D
    public Image cameraFront;         // 메인 이미지
    public Image cameraBack;           // 3D 이미지
    private bool _mainCamera = true;

    private float _minXLook = -65.0f;
    private float _maxXLook = +65.0f;
    private float _cameraXRot;

    private float _lookSensitivity = 0.1f;
    private Vector2 _mouseDelta;

    // === 이동하는 플렛폼 정보 ===
    private Rigidbody _rigidbody;
    private Transform _platform_Transform; 
    private Vector3 _platform_Last_Position; 

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        cameraBox.gameObject.SetActive(_mainCamera);
        cameraFront.gameObject.SetActive(_mainCamera);

        secondcamera.gameObject.SetActive(!_mainCamera);
        cameraBack.gameObject.SetActive(!_mainCamera);
    }

    private void Update()
    {
        Move();
    }

    void FixedUpdate()
    {
        // === 플렛폼 위에 있을 경우 ===
        if (_platform_Transform != null)
        {
            // === 플렛폼 이동량 계산 ===
            Vector3 platformDelta = _platform_Transform.position - _platform_Last_Position;

            _rigidbody.position += platformDelta / 2;

            // === 마지막 플렛폼 위치 갱신 ===
            _platform_Last_Position = _platform_Transform.position;
        }
    }

    private void LateUpdate()
    {
        CameraLook();
    }

    // === 충돌 판정 ===
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Moving"))
        {
            _platform_Transform = collision.transform;
            // === 닿을때 플렛폼의 위치 저장 ===
            _platform_Last_Position = _platform_Transform.position;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Moving"))
        {
            _platform_Transform = null;
        }
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

        if(_mainCamera == true)
        {
            cameraBox.localEulerAngles = new Vector3(-_cameraXRot, 0, 0);
        }
        else
        {
            secondcamera.localEulerAngles = new Vector3(-_cameraXRot, 0, 0);
        }

        transform.eulerAngles += new Vector3(0, _mouseDelta.x * _lookSensitivity, 0);
    }

    // === 카메라 입력값 ===
    public void OnLookInput(InputAction.CallbackContext context)
    {
        _mouseDelta = context.ReadValue<Vector2>();
    }

    // === E키를 눌러 아이템 사용 ===
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

    // === 입력시 점프 ===
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
        // 점프 부스트 활성화
        _is_Jump_Boost = true;

        Flash();

        yield return new WaitForSeconds(jumpBoostDuration);

        Inventory.Instance.UseItem();

    }

    // === 화면 번쩍임 메서드 ===
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

    // === 화면을 번쩍일 코루틴 ===
    private IEnumerator FadeAway()
    {
        flashSpeed = 0.5f;

        // === 화면 불투명도 ===
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

    // === 땅인지 판별 ===
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
                return true;  // === groundLayerMask일 경우 ===
            }
        }

        return false;        // === groundLayerMask가 아닐경우 ===
    }

    // === Q키를 눌러 카메라 전환 ===
    public void OnSwitchInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            _mainCamera = !_mainCamera;

            cameraBox.gameObject.SetActive(_mainCamera);
            cameraFront.gameObject.SetActive(_mainCamera);

            secondcamera.gameObject.SetActive(!_mainCamera);
            cameraBack.gameObject.SetActive(!_mainCamera);
        }
    }
}
