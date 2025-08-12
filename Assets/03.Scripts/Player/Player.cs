using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller;
    public PlayerCondition condition;

    public ItemData itemData;

    private void Awake()
    {
        GameManager.Instance.PlayerManager.Player = this;
        controller = GetComponent<PlayerController>();
        condition = GetComponent<PlayerCondition>();
    }

    // === 바다에 떨어질시 사망 ===
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Die"))
        {
            GameManager.Instance.PlayerManager.curHp = 0;
            GameManager.Instance.GameOver();
        }

    }

    // === 성벽에 닿을시 클리어 ===
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Clear"))
        {
            GameManager.Instance.GameClear();
        }
    }
}
