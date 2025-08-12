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
        // === ȸ���������� �ٷ� ȸ�� ===
        if (item.type == ItemType.Health)
        {
            AddHp((int)item.consumables[0].value);
            return;
        }

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

    public void AddHp(int value)
    {
        GameManager.Instance.PlayerManager.curHp = Mathf.Min(GameManager.Instance.PlayerManager.curHp + value, GameManager.Instance.PlayerManager.maxHp);
    }
}
