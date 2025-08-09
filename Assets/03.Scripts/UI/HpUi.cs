using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // === image를 사용하기 위해 ===

public class HpUi : MonoBehaviour
{
    // === 조절할 이미지를 Inspector창에서 할당 ===
    public Image hpbar;

    private void Update()
    {
        hpbar.fillAmount = GetPercentage();
    }

    public void TakeDamage(float damage)
    {
        GameManager.Instance.PlayerManager.curHp -= damage;

        if (GameManager.Instance.PlayerManager.curHp <= 0)
        {
            // === 플레이어 체력이 0이 되면 GameManager에게 게임 오버 호출 ===
            GameManager.Instance.GameOver();
        }
    }

    float GetPercentage()
    {
        return GameManager.Instance.PlayerManager.curHp / GameManager.Instance.PlayerManager.maxHp;
    }

    public void Add(float value)
    {
        GameManager.Instance.PlayerManager.curHp = Mathf.Min(GameManager.Instance.PlayerManager.curHp + value, GameManager.Instance.PlayerManager.maxHp);
    }

    public void Subtract(float value)
    {
        GameManager.Instance.PlayerManager.curHp = Mathf.Max(GameManager.Instance.PlayerManager.curHp - value, 0f);
    }
}
