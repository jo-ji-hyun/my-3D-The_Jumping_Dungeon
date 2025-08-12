using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    // === 아이템 획득시 표시해줄 창 ===
    public Image icon;
    public TextMeshProUGUI displayDescription;

    // === 아이템을 저장할 리스트 ===
    public List<ItemData> inventory = new();

    // === 싱글톤 ===
    public static Inventory Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // === 아이템 획득시 표현 ===
    public void GetItem(ItemData item)
    {
        inventory.Add(item);
        // === 회복아이템은 바로 회복 ===
        if (item.type == ItemType.Health)
        {
            AddHp((int)item.consumables[0].value);
            return;
        }

        icon.sprite = item.icon;
        displayDescription.text = item.Description;
        displayDescription.gameObject.SetActive(true);
    }

    // === 아이템 사용시 ===
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
