using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public ItemData itemData;

    private void OnTriggerEnter(Collider other)
    {
        // === �÷��̾ ȹ��� ===
        if (other.CompareTag("Player"))
        {
            // === �κ��丮 ��ũ��Ʈ�� �������� �߰� ===
            if (Inventory.Instance != null)
            {
                Inventory.Instance.GetItem(itemData);

                Destroy(gameObject);
            }
        }
    }
}
