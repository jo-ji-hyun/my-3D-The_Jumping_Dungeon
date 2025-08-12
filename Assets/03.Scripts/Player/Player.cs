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

    // === ¹Ù´Ù¿¡ ¶³¾îÁú½Ã »ç¸Á ===
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Die"))
        {
            GameManager.Instance.PlayerManager.curHp = 0;
            GameManager.Instance.GameOver();
        }

        if (collision.gameObject.CompareTag("Clear"))
        {
            GameManager.Instance.GameClear();
        }
    }
}
