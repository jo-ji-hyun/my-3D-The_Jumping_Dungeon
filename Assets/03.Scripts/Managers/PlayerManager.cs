using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour 
{
    // === �÷��̾� ü�� ===
    public int maxHp = 3; // === �ִ� ü�� ===
    public int curHp;

    // === �÷��̾� ���׹̳� ===
    public int maxStamina = 220; // === �ִ� ���׹̳� ===
    public int curStamina;

    public void Start()
    {
        curHp = maxHp;
        curStamina = maxStamina;
    }

    private void Update()
    {
        // === ���� ü���� 0������ ��� ���ӿ��� ===
        if (curHp <= 0) 
        {
            GameManager.Instance.GameOver();
        }
    }

    private void FixedUpdate()
    {
        if (curStamina != maxStamina)
        {
            curStamina += 2;
        }
    }

    public Player Player
    {
        get { return _player; }
        set { _player = value; }
    }
    private Player _player;

}
