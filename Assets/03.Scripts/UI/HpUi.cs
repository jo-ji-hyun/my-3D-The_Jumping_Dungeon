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

    // === float로 계산 ===
    float GetPercentage()
    {
        return (float)GameManager.Instance.PlayerManager.curHp / GameManager.Instance.PlayerManager.maxHp;
    }
}
