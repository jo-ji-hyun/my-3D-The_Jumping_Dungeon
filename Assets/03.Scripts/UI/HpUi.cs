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

    float GetPercentage()
    {
        return GameManager.Instance.PlayerManager.curHp / GameManager.Instance.PlayerManager.maxHp;
    }
}
