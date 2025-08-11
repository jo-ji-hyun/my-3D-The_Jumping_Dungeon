using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // === image를 사용하기 위해 ===

public class StatUi : MonoBehaviour
{
    // === 조절할 이미지를 Inspector창에서 할당 ===
    public Image hpbar;
    public Image staminabar;

    private void Update()
    {
        hpbar.fillAmount = GetPercentage();
        staminabar.fillAmount = GetPercentageStamina();
    }

    // === float로 계산 ===
    float GetPercentage()
    {
        return (float)GameManager.Instance.PlayerManager.curHp / GameManager.Instance.PlayerManager.maxHp;
    }

    // === float로 계산 ===
    float GetPercentageStamina()
    {
        return (float)GameManager.Instance.PlayerManager.curStamina / GameManager.Instance.PlayerManager.maxStamina;
    }
}
