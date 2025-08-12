using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour 
{
    // === 플레이어 체력 ===
    public int maxHp = 3; // === 최대 체력 ===
    public int curHp;

    // === 플레이어 스테미나 ===
    public int maxStamina = 220; // === 최대 스테미나 ===
    public int curStamina;

    public void Start()
    {
        curHp = maxHp;
        curStamina = maxStamina;
    }

    private void Update()
    {
        // === 현재 체력이 0이하일 경우 게임오버 ===
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
