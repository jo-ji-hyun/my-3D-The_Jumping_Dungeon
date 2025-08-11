using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // === image를 사용하기 위해 ===
using TMPro; // === TextMeshPro를 사용하기 위해 ===

public class StatUi : MonoBehaviour
{
    // === 조절할 이미지를 Inspector창에서 할당 ===
    public Image hpbar;
    public Image staminabar;

    // === 수치를 보여줌 ===
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI staminaText;

    private void Update()
    {
        hpbar.fillAmount = GetPercentage();
        staminabar.fillAmount = GetPercentageStamina();
    }

    private void FixedUpdate()
    {
        UpdateUi();
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

    // === 실시간으로 수치를 보여줌 ===
    private void UpdateUi()
    {
        if (healthText != null)
        {
            healthText.text = $"{GameManager.Instance.PlayerManager.curHp}";
        }

        if (staminaText != null)
        {
            staminaText.text = $"{GameManager.Instance.PlayerManager.curStamina}";
        }
    }
}
