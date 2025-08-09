using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerManager : MonoBehaviour
{
    // === �÷��̾� ü�� ===
    public float maxHp = 3f; // === �ִ� ü�� ===
    public float curHp;

    public void Awake()
    {
        curHp = maxHp;
    }

    private void Update()
    {
        // === ���� ü���� 0������ ��� ���ӿ��� ===
        if (curHp <= 0) 
        {
            GameManager.Instance.GameOver();
        }
    }

    public Player Player
    {
        get { return _player; }
        set { _player = value; }
    }
    private Player _player;

    // === ������ ��� ===

    public void AddHp(float value)
    {
        curHp = Mathf.Min(curHp + value, maxHp);
    }

    public void SubtractHp(float value)
    {
        curHp = Mathf.Max(curHp - value, 0f);
    }
}
