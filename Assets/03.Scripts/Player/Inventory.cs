using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

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

        Debug.Log("������ ȹ��");

        icon.sprite = item.icon;
        displayDescription.text = item.Description;
        displayDescription.gameObject.SetActive(true);
    }
}
