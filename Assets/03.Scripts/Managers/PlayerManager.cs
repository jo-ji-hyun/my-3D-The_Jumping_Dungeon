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
    public int maxStamina = 200; // === �ִ� ü�� ===
    public int curStamina;

    public void Awake()
    {
        curHp = maxHp;
        curStamina = maxStamina;
    }

    private void Update()
    {
        if(curStamina != maxStamina)
        {
            curStamina += 1;
        }

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

}
