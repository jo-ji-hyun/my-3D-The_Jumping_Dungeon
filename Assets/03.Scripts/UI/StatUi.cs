using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // === image�� ����ϱ� ���� ===
using TMPro; // === TextMeshPro�� ����ϱ� ���� ===

public class StatUi : MonoBehaviour
{
    // === ������ �̹����� Inspectorâ���� �Ҵ� ===
    public Image hpbar;
    public Image staminabar;

    // === ��ġ�� ������ ===
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

    // === �ǽð����� ��ġ�� ������ ===
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
