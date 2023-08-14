using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Quest_SO", menuName = "SriptableObjects/Quest_SO", order = 1)]
public class Quest_SO : ScriptableObject
{
    [Header ("Quest Goals")] 
    [SerializeField]
    public List<Goal> Goals = null;

    [Header ("Quest Information")] 
    [SerializeField]
    protected string Name = "DefaultQuestName";

    [SerializeField]
    [TextArea (minLines: 2, maxLines: 4)]
    protected string Desciption = null;

    [SerializeField]
    protected int ExpReward = 0;
    [SerializeField]
    protected bool isCompleted = false;

    [SerializeField]
    private bool wasCompletedBefore = false;
    public bool WasCompletedBefore
    {
        get
        {
            return wasCompletedBefore;
        }
    }

    [Header ("Reward Options")] 
    [SerializeField]
    protected List<Item> ItemsReward = null;

    [SerializeField]
    protected Vector3 RewardPosition = new Vector3(0, 5f, 0);

    public bool IsCompleted()
    {
        return isCompleted;
    }
    public void CheckGoals()
    {   
        int completedGoalsAmount = 0;
        foreach (Goal currentGoal in Goals)
        {
            currentGoal.Check();
            if(currentGoal.isCompleted)
            {
                completedGoalsAmount++;
            }
        }
        if(completedGoalsAmount == Goals.Count)
        {
            Complete();
            GiveReward();
        }

        //if(Goals.All(g => g.isCompleted)){} //using System.Linq;
    }

    void Complete()
    {
        isCompleted = true;
        wasCompletedBefore = true;
    }

    void GiveReward()
    {
        if(ItemsReward.Count > 0)
        {
            for(int i=0; i<ItemsReward.Count; i++)
            {   
                Vector3 currentPosition = RewardPosition;
                currentPosition.y += i; 
                InventoryCollectable.SpawnItem(
                    ItemsReward[i].Clone(), currentPosition
                );
            }
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
