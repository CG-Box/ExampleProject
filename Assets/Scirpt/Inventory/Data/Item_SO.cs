using UnityEngine;
using System;

/*
public enum ItemType 
{
    HealthPotion,
    ManaPotion,
    Medkit,
    Sword,
    Coin
}*/

[CreateAssetMenu(fileName = "Item_SO", menuName = "SriptableObjects/Item_SO", order = 2)]
public class Item_SO: ScriptableObject
{
    public ItemType type;
    public int amount = 1;
    [SerializeField]private bool canStack = false;
    [SerializeField]private Sprite sprite;

    public static Transform CollectableTransform;

    public bool IsStackale
    {
        get
        {
            return canStack;
        }
    }
    public Sprite GetSprite()
    {
        return sprite;
    }
}
