using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // === image�� ����ϱ� ���� ===

public class StatUi : MonoBehaviour
{
    // === ������ �̹����� Inspectorâ���� �Ҵ� ===
    public Image hpbar;
    public Image staminabar;

    private void Update()
    {
        hpbar.fillAmount = GetPercentage();
        staminabar.fillAmount = GetPercentageStamina();
    }

    // === float�� ��� ===
    float GetPercentage()
    {
        return (float)GameManager.Instance.PlayerManager.curHp / GameManager.Instance.PlayerManager.maxHp;
    }

    // === float�� ��� ===
    float GetPercentageStamina()
    {
        return (float)GameManager.Instance.PlayerManager.curStamina / GameManager.Instance.PlayerManager.maxStamina;
    }
}
