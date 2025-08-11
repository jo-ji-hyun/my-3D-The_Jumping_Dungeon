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
    public int maxStamina = 200; // === 최대 체력 ===
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

        // === 현재 체력이 0이하일 경우 게임오버 ===
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
