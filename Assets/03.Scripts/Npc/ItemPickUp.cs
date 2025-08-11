using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public ItemData itemData;

    private void OnTriggerEnter(Collider other)
    {
        // === 플레이어가 획득시 ===
        if (other.CompareTag("Player"))
        {
            // === 인벤토리 스크립트에 아이템을 추가 ===
            if (Inventory.Instance != null)
            {
                Inventory.Instance.GetItem(itemData);

                Destroy(gameObject);
            }
        }
    }
}
