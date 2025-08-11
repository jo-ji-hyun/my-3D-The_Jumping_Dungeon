using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCount : MonoBehaviour
{
    // === ���� ������ ������ â ===
    public GameObject gameOverPanel;


    private void Start()
    {
        gameOverPanel.SetActive(false);
    }

    public void OnStartButton()
    {
        GameManager.Instance.ReStartGame();
    }

    public void GameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }
}
