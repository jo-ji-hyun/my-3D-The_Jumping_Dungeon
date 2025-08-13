using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // === �ٸ� �Ŵ����� ȣ�� ===
    public PlayerManager PlayerManager { get; private set; }

    // === ���� ������ ������ â ===
    public GameObject gameOverPanel;

    // === ���� Ŭ����� ������ â ===
    public GameObject gameClearPanel;

    // === ���� ���� Ȯ�� ===
    public bool gameSet = false;

    // === �̱��� ���� ===
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

        // === PlayerManager ���� ===
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
