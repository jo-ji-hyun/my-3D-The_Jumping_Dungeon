using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    // === �������� ������ ===
    private float _jump_Up = 18.5f;

    // === �浹�� ���� (Ʈ���� x) ===
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // === �÷��̾��� Rigidbody ===
            Rigidbody _playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            // === ���� ������ ���� ===
            _playerRigidbody.velocity = new Vector3(_playerRigidbody.velocity.x, 0, _playerRigidbody.velocity.z);

            if (_playerRigidbody != null)
            {
                _playerRigidbody.AddForce(Vector3.up * _jump_Up, ForceMode.Impulse); // �������� ����
            }
        }
    }
}
