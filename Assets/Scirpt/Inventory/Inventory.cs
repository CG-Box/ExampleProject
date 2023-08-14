using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory
{    
    private List<Item> itemList;
    private Action<Item> UseItemAction;

    public event EventHandler OnItemListChanged;

    public Inventory(Action<Item> UseItemAction)
    {
        this.UseItemAction = UseItemAction;
        itemList = new List<Item>();

        /*
        AddItem(new Item{type = ItemType.Sword, amount = 1});
        AddItem(new Item{type = ItemType.HealthPotion, amount = 1});
        AddItem(new Item{type = ItemType.ManaPotion, amount = 1});
        AddItem(new Item{type = ItemType.Medkit, amount = 1});
        AddItem(new Item{type = ItemType.Coin, amount = 5});*/
    }

    public void AddItem(Item newItem)
    {
        if(newItem.IsStackale())
        {   
            bool alreadyExist = false;
            foreach(Item item in itemList)
            {
                if(item.type == newItem.type)
                {
                    alreadyExist = true;
                    item.amount += newItem.amount;
                }

            }
            if(!alreadyExist)
            {
                itemList.Add(newItem);
            }
        }
        else
        {
            itemList.Add(newItem);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }
    public void RemoveItem(Item delItem)
    {
        if(delItem.IsStackale())
        {   
            Item itemExist = null;
            foreach(Item item in itemList)
            {
                if(item.type == delItem.type)
                {
                    itemExist = item;
                    item.amount -= delItem.amount;
                }

            }
            if(itemExist != null && itemExist.amount <= 0)
            {
                itemList.Remove(itemExist);
            }
        }
        else
        {
            itemList.Remove(delItem);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void UseItem(Item useItem)
    {
        UseItemAction(useItem);
    }
    
    public List<Item> GetItemList()
    {
        return itemList;
    }
    public void LoadItemList(List<Item> loadItemList)
    {
        itemList = loadItemList;
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }
}
