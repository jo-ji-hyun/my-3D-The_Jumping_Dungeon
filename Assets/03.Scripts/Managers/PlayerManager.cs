using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Player Player
    {
        get { return _player; }
        set { _player = value; }
    }
    private Player _player;
}
