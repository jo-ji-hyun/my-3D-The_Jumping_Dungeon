using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    // === 가해지는 점프력 ===
    private float _jump_Up = 18.5f;

    // === 충돌시 점프 (트리거 x) ===
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // === 플레이어의 Rigidbody ===
            Rigidbody _playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            // === 기존 점프력 고정 ===
            _playerRigidbody.velocity = new Vector3(_playerRigidbody.velocity.x, 0, _playerRigidbody.velocity.z);

            if (_playerRigidbody != null)
            {
                _playerRigidbody.AddForce(Vector3.up * _jump_Up, ForceMode.Impulse); // 순간적인 점프
            }
        }
    }
}
