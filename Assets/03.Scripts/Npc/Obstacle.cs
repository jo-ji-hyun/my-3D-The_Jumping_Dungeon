using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // === 장애물 스펙 ===
    [Header("Damage")]
    public int damage = 1;
    public float damageDelay = 0.9f;
    private float _knockbackForce = 100f;

    // === 충돌시 넉벡 (트리거 x) ===
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageIbe damgeIbe))
        {
            damgeIbe.DamageCall(damage);

            // === 플레이어의 Rigidbody ===
            Rigidbody _playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            // === 충돌 지점 === 
            Vector3 contactPoint = collision.contacts[0].point;

            // === 넉백 방향 계산 (반대 방향으로 게산) === 
            Vector3 knockbackDirection = (collision.transform.position - contactPoint).normalized;

            Vector3 KnockbackDirectionZ = new(0, 0, knockbackDirection.z);

            if (_playerRigidbody != null)
            {
                _playerRigidbody.AddForce(KnockbackDirectionZ * _knockbackForce, ForceMode.Impulse); // 순간적인 넉벡
            }
        }
    }

}
