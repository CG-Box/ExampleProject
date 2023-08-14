using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public enum ItemType 
{
    HealthPotion,
    ManaPotion,
    Medkit,
    Sword,
    Coin
}

[Serializable]
public class Item
{
    public ItemType type;
    public int amount;
    public bool canStack = false;
    public Sprite GetSprite()
    {
        switch(type)
        {
            default:
            case ItemType.HealthPotion: return ItemAssets.Instance.healthPotionSprite;
            case ItemType.ManaPotion:   return ItemAssets.Instance.manaPotionSprite;
            case ItemType.Medkit:       return ItemAssets.Instance.medkitSprite;
            case ItemType.Sword:        return ItemAssets.Instance.swordSprite;
            case ItemType.Coin:         return ItemAssets.Instance.coinSprite;
        }
    }

    public bool IsStackale()
    {
        switch(type)
        {
            default:
            case ItemType.HealthPotion: return true;
            case ItemType.ManaPotion:   return true;
            case ItemType.Medkit:       return false;
            case ItemType.Sword:        return false;
            case ItemType.Coin:         return true;
        }
    }

    public static Item Clone(Item originalItem)
    {
        Item copyItem = new Item();
        copyItem.type = originalItem.type;
        copyItem.amount = originalItem.amount;
        copyItem.canStack = originalItem.canStack;
        return copyItem;
    }
    public Item Clone()
    {
        return Clone(this);
    }
}
