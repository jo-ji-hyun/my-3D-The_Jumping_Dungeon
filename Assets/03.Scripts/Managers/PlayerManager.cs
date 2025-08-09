using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour 
{
    // === 플레이어 체력 ===
    public int maxHp = 3; // === 최대 체력 ===
    public int curHp;

    public void Awake()
    {
        curHp = maxHp;
    }

    private void Update()
    {
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
