using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // === 다른 매니저들 호출 ===
    public PlayerManager PlayerManager { get; private set; }

    // === 게임 오버시 보여줄 창 ===
    public GameObject gameOverPanel;

    // === 게임 클리어시 보여줄 창 ===
    public GameObject gameClearPanel;

    // === 게임 종료 확인 ===
    public bool gameSet = false;

    // === 싱글톤 선언 ===
    public static GameManager Instance { get; private set; }


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        // === PlayerManager 생성 ===
        GameObject playerManagerObject = new GameObject("PlayerManager");
        PlayerManager = playerManagerObject.AddComponent<PlayerManager>();
        playerManagerObject.transform.SetParent(transform);
    }

    public void ReStartGame()
    {
        gameSet = false;

        PlayerManager.Player.controller.ToggleCursor(false);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Time.timeScale = 1.0f;

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        if (gameClearPanel != null)
        {
            gameClearPanel.SetActive(false);
        }

        PlayerManager.curHp = PlayerManager.maxHp;
    }

    public void GameOver()
    {
        gameSet = true;

        PlayerManager.Player.controller.ToggleCursor(true);

        gameOverPanel.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void GameClear()
    {
        gameSet = true;

        PlayerManager.Player.controller.ToggleCursor(true);

        gameClearPanel.SetActive(true);
        Time.timeScale = 0.0f;
    }
}
