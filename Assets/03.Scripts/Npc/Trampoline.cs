using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    // === 가해지는 점프력 ===
    private float _jump_Up = 40.0f;

    // === 충돌시 점프 (트리거 x) ===
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // === 플레이어의 Rigidbody ===
            Rigidbody _playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            // === 점프 지점 === 
            Vector3 contactPoint = collision.contacts[0].point;

            // === 기존 점프력 고정 ===
            _playerRigidbody.velocity = new Vector3(_playerRigidbody.velocity.x, 0, _playerRigidbody.velocity.z);

            // === 점프 방향 계산 (반대 방향으로 게산) === 
            Vector3 jumpDirection = (collision.transform.position - contactPoint).normalized;

            Vector3 jumpping = new(0, jumpDirection.y, 0);

            if (_playerRigidbody != null)
            {
                _playerRigidbody.AddForce(jumpping * _jump_Up, ForceMode.Impulse); // 순간적인 점프
            }
        }
    }
}
