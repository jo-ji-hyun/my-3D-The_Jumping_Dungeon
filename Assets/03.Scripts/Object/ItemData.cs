using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Consumable,  // 소비템
    Health,       // 즉시 발동
    Resource       // 나머지
}

public enum ConsumableType
{
    Health
}

[Serializable]
public class ItemDataConsumable
{
    public ConsumableType type;
    public float value;
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]

public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string Description;
    public ItemType type;
    public Sprite icon;

    [Header("Consumable")]
    public ItemDataConsumable[] consumables;
}
