using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface IDamageIbe
{
    void DamageCall(int damage);
}

public class PlayerCondition : MonoBehaviour, IDamageIbe
{
    public event Action OnTakeDamage;

    public void DamageCall(int damage)
    {
        SubtractHp(damage);
        OnTakeDamage?.Invoke();
    }
    // === 데미지 계산 ===

    public void AddHp(int value)
    {
        GameManager.Instance.PlayerManager.curHp = Mathf.Min(GameManager.Instance.PlayerManager.curHp - value, GameManager.Instance.PlayerManager.maxHp);
    }

    public void SubtractHp(int value)
    {
        GameManager.Instance.PlayerManager.curHp = Mathf.Max(GameManager.Instance.PlayerManager.curHp - value, 0);
    }
}
