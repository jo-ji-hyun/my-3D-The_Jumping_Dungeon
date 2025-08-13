using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbWall : MonoBehaviour
{
    public LayerMask wallLayerMask;

    private void Update()
    {
        // === 벽일 경우===
        if (IsWall())
        {
            Debug.Log("벽에 붙음");
            GameManager.Instance.PlayerManager.Player.controller.playerRigidbody.AddForce(Vector2.up, ForceMode.Force);
        }
    }

    // === 레이저를 쏘아 벽인지 확인 ===
    bool IsWall()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.1f) + (transform.up * 0.1f), Vector3.up),
            new Ray(transform.position + (-transform.forward * 0.1f) + (transform.up * 0.1f),Vector3.up),
            new Ray(transform.position + (transform.right * 0.1f) + (transform.up * 0.1f), Vector3.up),
            new Ray(transform.position + (-transform.right * 0.1f) +(transform.up * 0.1f), Vector3.up)
        };

        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 1.0f, wallLayerMask))
            {
                return true;  // === wallLayerMask 맞을 경우 ===
            }
        }

        return false;        // === wallLayerMask 아닐 경우 ===
    }
}
