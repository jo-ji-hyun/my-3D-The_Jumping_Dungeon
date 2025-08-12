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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        PlayerManager.curHp = PlayerManager.maxHp;
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

}
