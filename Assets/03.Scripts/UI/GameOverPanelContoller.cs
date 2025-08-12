using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPanelController : MonoBehaviour
{
    private void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.gameOverPanel = this.gameObject;
            this.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("GameManager �ν��Ͻ��� ã�� �� �����ϴ�.");
        }
    }

    public void OnRestartButton()
    {
        GameManager.Instance.ReStartGame();
    } 
}
