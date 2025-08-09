using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // === image�� ����ϱ� ���� ===

public class HpUi : MonoBehaviour
{
    // === ������ �̹����� Inspectorâ���� �Ҵ� ===
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
            // === �÷��̾� ü���� 0�� �Ǹ� GameManager���� ���� ���� ȣ�� ===
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
