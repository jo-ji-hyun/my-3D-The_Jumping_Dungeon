using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactoin : MonoBehaviour
{
    // === 환경조사 ===
    [SerializeField]
    private float _checkRate = 0.5f;
    private float _lastCheck;
    public float maxCheckDistance = 7.0f; // === 체크할 거리 ===
    public LayerMask layerMask;

    public GameObject curInteractGameObj;
    private IInteractable _curInteractable;

    public TextMeshProUGUI promptText; // === 출력할 창 ===
    private Camera _camera;

    void Start()
    {
        _camera = Camera.main;

    }

    void Update()
    {
        if (Time.time - _lastCheck > _checkRate)
        {
            _lastCheck = Time.time;

            // === 가상의 레이저로 물체와 닿을시 체크 ===
            Ray ray = _camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, maxCheckDistance, layerMask))
            {
                curInteractGameObj = hit.collider.gameObject;
                _curInteractable = hit.collider.GetComponent<IInteractable>();
                SetPromptText();
            }
            else
            {
                curInteractGameObj = null;
                _curInteractable = null;
                promptText.gameObject.SetActive(false);
            }
        }
    }

    private void SetPromptText()
    {
        promptText.gameObject.SetActive(true);
        promptText.text = _curInteractable.GetInteractPrompt();
    }
}
