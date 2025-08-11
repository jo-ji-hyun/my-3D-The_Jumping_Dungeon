using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    // === �������� ������ ===
    private float _jump_Up = 40.0f;

    // === �浹�� ���� (Ʈ���� x) ===
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // === �÷��̾��� Rigidbody ===
            Rigidbody _playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            // === ���� ���� === 
            Vector3 contactPoint = collision.contacts[0].point;

            // === ���� ������ ���� ===
            _playerRigidbody.velocity = new Vector3(_playerRigidbody.velocity.x, 0, _playerRigidbody.velocity.z);

            // === ���� ���� ��� (�ݴ� �������� �Ի�) === 
            Vector3 jumpDirection = (collision.transform.position - contactPoint).normalized;

            Vector3 jumpping = new(0, jumpDirection.y, 0);

            if (_playerRigidbody != null)
            {
                _playerRigidbody.AddForce(jumpping * _jump_Up, ForceMode.Impulse); // �������� ����
            }
        }
    }
}
