using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface IDamageable
{
    void DamageCall(int damage);
}

public class PlayerCondition : MonoBehaviour, IDamageable
{
    public event Action OnTakeDamage;

    public void DamageCall(int damage)
    {
        SubtractHp(damage);
        OnTakeDamage?.Invoke();
    }
    // === 데미지 계산 ===

    public void SubtractHp(int value)
    {
        GameManager.Instance.PlayerManager.curHp = Mathf.Max(GameManager.Instance.PlayerManager.curHp - value, 0);
    }
}
