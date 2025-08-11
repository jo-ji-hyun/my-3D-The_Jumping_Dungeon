using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Consumable,
    Resource
}

public enum ConsumableType
{
    Health,
    // stamina
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
    public GameObject dropPrefabs;

    [Header("Consumable")]
    public ItemDataConsumable[] consumables;
}
