using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // === ��ֹ� ���� ===
    [Header("Damage")]
    public int damage = 1;
    public float damageDelay = 1.0f;

    // === �������̽� IDamageIbe�� List�� �ҷ��� ===
    List<IDamageIbe> players = new List<IDamageIbe>();

    void Start()
    {
        InvokeRepeating("DealDamage", 0, damageDelay);
    }

    private void DealDamage()
    {
        for (int i = 0; i < players.Count; i++)
        {
            players[i].SubtractHp(damage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("�浹 ����");
        if (other.TryGetComponent(out IDamageIbe damgeIbe))
        {
            players.Add(damgeIbe);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IDamageIbe damgeIbe))
        {
            players.Remove(damgeIbe);
        }
    }
}
