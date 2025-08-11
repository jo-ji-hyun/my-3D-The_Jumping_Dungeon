using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    // === ������ ȹ��� ǥ������ â ===
    public Image icon;
    public TextMeshProUGUI displayDescription;

    // === �������� ������ ����Ʈ ===
    public List<ItemData> inventory = new();

    // === �̱��� ===
    public static Inventory Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // === ������ ȹ��� ǥ�� ===
    public void GetItem(ItemData item)
    {
        inventory.Add(item);

        icon.sprite = item.icon;
        displayDescription.text = item.Description;
        displayDescription.gameObject.SetActive(true);
    }

    // === ������ ���� ===
    public void UseItem()
    {
        inventory.Clear();

        icon.sprite = null;
        displayDescription.text = null;
        displayDescription.gameObject.SetActive(false);
    }

}
