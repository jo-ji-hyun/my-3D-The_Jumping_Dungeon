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
            GameManager.Instance.PlayerManager.Player.controller.playerRigidbody.AddForce(14.0f * Vector3.up, ForceMode.Force);
        }
    }

    // === 레이저를 쏘아 벽인지 확인 ===
    bool IsWall()
    {
        Ray[] rays = new Ray[7]
        {
            new Ray(transform.position + (transform.forward * 0.1f) + (transform.up * 0.1f), Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.1f) + (transform.up * 0.1f),Vector3.down),
            new Ray(transform.position + (transform.right * 0.1f) + (transform.up * 0.1f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.1f) +(transform.up * 0.1f), Vector3.down),
            new Ray(transform.position, transform.forward),
            new Ray(transform.position, transform.right),
            new Ray(transform.position, -transform.right)
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
