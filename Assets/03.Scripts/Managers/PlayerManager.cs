using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageIbe
{
    void SubtractHp(int damage);
}


public class PlayerManager : MonoBehaviour , IDamageIbe
{
    // === �÷��̾� ü�� ===
    public int maxHp = 3; // === �ִ� ü�� ===
    public int curHp;

    public event Action OnTakeDamage;

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

    public void AddHp(int value)
    {
        curHp = Mathf.Min(curHp + value, maxHp);
    }

    public void SubtractHp(int value)
    {
        curHp = Mathf.Max(curHp - value, 0);
        OnTakeDamage?.Invoke();
    }
}
