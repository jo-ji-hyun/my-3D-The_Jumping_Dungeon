using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCount : MonoBehaviour
{
    // === 게임 오버시 보여줄 창 ===
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
