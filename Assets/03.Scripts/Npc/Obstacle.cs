using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float damage = 1;
    public float damageDelay = 1.0f;

    void Start()
    {
        InvokeRepeating("DealDamage", 0, damageDelay);
    }

    private void DealDamage()
    {
        GameManager.Instance.PlayerManager.SubtractHp(damage);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DealDamage();
        }
    }

    private void OnTriggerExit(Collider other)
    {

    }
}
