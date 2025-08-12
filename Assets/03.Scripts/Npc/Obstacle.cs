using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // === ��ֹ� ���� ===
    [Header("Damage")]
    public int damage = 1;

    private float _damage_Delay = 1.5f;
    private float _damage_Timer = 0.0f;

    private float _knockback_Force = 110f;
    private float _knockback_Jump = 0.045f; // ���������� ƨ����

    private void Update()
    {
        // === ��� ���� ===
        if(_damage_Timer > 0)
        {
            _damage_Timer -= Time.deltaTime;
        }
    }

    // === �浹�� �˺� (Ʈ���� x) ===
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable damgeIbe) && _damage_Timer <= 0)
        {
            _damage_Timer = _damage_Delay;

            damgeIbe.DamageCall(damage);

            // === �÷��̾��� Rigidbody ===
            Rigidbody _playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            // === �浹 ���� === 
            Vector3 contactPoint = collision.contacts[0].point;

            // === �˹� ���� ��� (�ݴ� �������� �Ի�) === 
            Vector3 knockbackDirection = (collision.transform.position - contactPoint).normalized;

            Vector3 Knockback= new(0, _knockback_Jump, knockbackDirection.z);

            if (_playerRigidbody != null)
            {
                _playerRigidbody.AddForce(Knockback * _knockback_Force, ForceMode.Impulse); // �������� �˺�
            }
        }
    }

}
