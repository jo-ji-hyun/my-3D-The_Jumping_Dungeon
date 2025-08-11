using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    // === ¾ÆÀÌÅÛ È¹µæ½Ã Ç¥½ÃÇØÁÙ Ã¢ ===
    public Image icon;
    public TextMeshProUGUI displayDescription;

    // === ¾ÆÀÌÅÛÀ» ÀúÀåÇÒ ¸®½ºÆ® ===
    public List<ItemData> inventory = new();

    // === ½Ì±ÛÅæ ===
    public static Inventory Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // === ¾ÆÀÌÅÛ È¹µæ½Ã Ç¥Çö ===
    public void GetItem(ItemData item)
    {
        inventory.Add(item);

        Debug.Log("¾ÆÀÌÅÛ È¹µæ");

        icon.sprite = item.icon;
        displayDescription.text = item.Description;
        displayDescription.gameObject.SetActive(true);
    }
}
