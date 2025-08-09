using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerManager : MonoBehaviour
{
    // === 플레이어 체력 ===
    public float maxHp = 100f; // === 최대 체력 ===
    public float curHp;

    public void Awake()
    {
        curHp = maxHp;
    }
    private void Update()
    {
        if (curHp <= 0) 
        {
            GameManager.Instance.GameOver();
        }
    }

    private void LateUpdate()
    {
        SubtractHp(1 * Time.time); // 실험용
    }

    public Player Player
    {
        get { return _player; }
        set { _player = value; }
    }
    private Player _player;

    // === 데미지 계산 ===

    public void AddHp(float value)
    {
        curHp = Mathf.Min(curHp + value, maxHp);
    }

    public void SubtractHp(float value)
    {
        curHp = Mathf.Max(curHp - value, 0f);
    }
}
