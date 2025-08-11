using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GameManager : MonoBehaviour
{
    // === �ٸ� �Ŵ����� ȣ�� ===
    public PlayerManager PlayerManager { get; private set; }


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
        Time.timeScale = 1;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void GameOver()
    {
        Time.timeScale = 0;
    }

}
