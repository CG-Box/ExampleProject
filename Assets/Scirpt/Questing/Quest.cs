using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Quest : MonoBehaviour
{
    public List<Goal> Goals {get;set;} = new List<Goal>();
    public string Name {get;set;}
    public string Desciption {get;set;}
    public int ExpReward {get;set;}
    public Item ItemReward { get; set; }
    public bool isCompleted { get; set; }

    public void CheckGoals()
    {
        if(Goals.All(g => g.isCompleted))
        {
            Complete();
            GiveReward();
        }
    }

    void Complete()
    {
        isCompleted = true;
        GameEvents.QuestEv.OnQuestComplete?.Invoke(this);
        //Reset();
    }

    void GiveReward()
    {
        if(ItemReward != null)
        {
            InventoryCollectable.SpawnItem(
                new Item{type = ItemType.HealthPotion, amount = 1 }, new Vector3(3, 5.2f, 0)
            );
        }
    }

    public void Reset() 
    {   
        isCompleted = false;
        foreach (Goal currentGoal in Goals)
        {
            currentGoal.Reset();
        }
    }

    public void LogConsole()
    {
        Debug.Log($"Quest Name: {Name}, isCompleted: {isCompleted}");
        foreach (Goal currentGoal in Goals)
        {
            currentGoal.LogConsole();
        }
    }
}
