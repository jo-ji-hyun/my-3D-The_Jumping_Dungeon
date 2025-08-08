using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller;

    private void Awake()
    {
        GameManager.Instance.PlayerManager.Player = this;
        controller = GetComponent<PlayerController>();
    }
}
