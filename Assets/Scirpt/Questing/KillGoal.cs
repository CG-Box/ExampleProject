using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillGoal : Goal
{
    public int EnemyId {get;set;}

    public KillGoal(Quest quest, int enemyId, string description, bool completed, int requiredAmount, int currentAmount)
    {
        this.Quest = quest;
        this.EnemyId = enemyId;
        this.Desciption = description;
        this.isCompleted = completed;
        this.RequiredAmount = requiredAmount;
        this.CurrentAmount = currentAmount;
    }

    public override void Init()
    {
        base.Init();
        //CombatEvents.onEnemyDeath += EnemyDied;
    }

    public void EnemyDied()
    {
        int diedEnemyId = 1;
        if(this.EnemyId == diedEnemyId)
        {
            this.CurrentAmount++;
            Check();
        }
    }
}
