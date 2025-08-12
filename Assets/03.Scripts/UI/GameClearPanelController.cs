using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearPanelController : MonoBehaviour
{
    private void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.gameClearPanel = this.gameObject;
            this.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("GameManager 인스턴스를 찾을 수 없습니다.");
        }
    }

    public void OnRestartButton()
    {
        GameManager.Instance.ReStartGame();
    }
}
