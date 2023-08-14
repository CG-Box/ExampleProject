using UnityEngine;
using System;

[Serializable]
public class Goal
{
    public Quest Quest {get;set;}
    public string Desciption = null;
    public bool isCompleted = false;
    public int RequiredAmount = 0;
    public int CurrentAmount = 0;

    public virtual void Init()
    {

    }

    public void Check()
    {
        if(CurrentAmount >= RequiredAmount)
        {
            Complete();
        }
    }

    public virtual void Complete()
    {
        isCompleted = true;
        Quest?.CheckGoals();
    }

    public void ForceComplete()
    {
        CurrentAmount = RequiredAmount;
        isCompleted = true;
        Quest?.CheckGoals();
    }

    public void ChangeAmount(int xAmount)
    {
        CurrentAmount += xAmount;
        this.Check();
        Quest?.CheckGoals();
    }

    public void Reset()
    {
        CurrentAmount = 0;
        isCompleted = false;  
    }

    public void LogConsole()
    {
        Debug.Log($"Goal Desciption: {Desciption}");
        Debug.Log($"CurrentAmount: {CurrentAmount}, RequiredAmount: {RequiredAmount}, isCompleted: {isCompleted}");
    }
}
