using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGoal : Goal
{
    public ItemType itemType {get;set;}

    public CollectGoal(Quest quest, ItemType itemType, string description, bool completed, int requiredAmount, int currentAmount)
    {
        this.Quest = quest;
        this.itemType = itemType;
        this.Desciption = description;
        this.isCompleted = completed;
        this.RequiredAmount = requiredAmount;
        this.CurrentAmount = currentAmount;
    }

    public override void Init()
    {
        base.Init();
        GameEvents.CollectEv.OnItemCollect += ItemCollect;
    }

    public override void Complete()
    {
        base.Complete();
        GameEvents.CollectEv.OnItemCollect -= ItemCollect;
    }

    public void ItemCollect(Item collectItem)
    {
        if(this.itemType == collectItem.type)
        {
            this.CurrentAmount += collectItem.amount;
            Check();
        }
        //Quest.LogConsole();
    }
}
