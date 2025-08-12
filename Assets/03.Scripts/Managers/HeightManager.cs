using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeightManager : MonoBehaviour
{
    // === 플레이어, 클리어 목표 ===
    public Transform player;
    public Transform target;

    public Text victoryText;
    public Text defeatText;

    [Header("Marker")]
    // === 움직일 마커 ===
    public RectTransform marker;

    // === 마커 최저, 최고 높이 ===
    private float _min_MarkerY = -100f;
    private float _max_MarkerY = +100f;

    // === 실제 최저,최고 높이 ===
    private float _min_PlayerY = 1.0f;
    private float _max_PlayerY = 55.0f;

    void Update()
    {
        if (player != null && target != null)
        {
            float heightDifference = target.position.y - player.position.y;

            // === 판넬이 켜져있는지 확인 ===
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
