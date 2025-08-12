using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeightManager : MonoBehaviour
{
    // === �÷��̾�, Ŭ���� ��ǥ ===
    public Transform player;
    public Transform target;

    public Text victoryText;
    public Text defeatText;

    [Header("Marker")]
    // === ������ ��Ŀ ===
    public RectTransform marker;

    // === ��Ŀ ����, �ְ� ���� ===
    private float _min_MarkerY = -100f;
    private float _max_MarkerY = +100f;

    // === ���� ����,�ְ� ���� ===
    private float _min_PlayerY = 1.0f;
    private float _max_PlayerY = 55.0f;

    void Update()
    {
        if (player != null && target != null)
        {
            float heightDifference = target.position.y - player.position.y;

            // === �ǳ��� �����ִ��� Ȯ�� ===
            if(victoryText != null || defeatText != null)
            {
                if (GameManager.Instance.gameSet == true)
                {
                    victoryText.text = player.position.y.ToString("F1") + "m";
                }
                else
                {
                    defeatText.text = heightDifference.ToString("F1") + "m";
                }
            }

        }

        UpdateArrowPosition();
    }

    private void UpdateArrowPosition()
    {
        if (player != null && marker != null)
        {
            float normalizedHeight = Mathf.InverseLerp(_min_PlayerY, _max_PlayerY, player.position.y);

            float newArrowY = Mathf.Lerp(_min_MarkerY, _max_MarkerY, normalizedHeight);

            marker.anchoredPosition = new Vector2(marker.anchoredPosition.x, newArrowY);
        }
    }

}
