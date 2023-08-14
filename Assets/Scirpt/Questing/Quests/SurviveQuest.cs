using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurviveQuest : Quest
{
 
    void Start()
    {
        Name = "Survive Quest";
        Desciption = "Collect all coins in a level";
        ItemReward =  new Item{type = ItemType.Medkit, amount = 1 };

        Goals.Add(new CollectGoal(this, ItemType.ManaPotion, "Collect 3 cakes", false, 3, 0));

        Goals.ForEach(g => g.Init());

        Debug.Log("Survive Quest start");
        RegisterEvent();
    }

    void RegisterEvent()
    {
        GameEvents.QuestEv.OnQuestComplete += QuestEndFunction; //register event
    }
    void QuestEndFunction(Quest endQuest)
    {
        endQuest.LogConsole();
    }
}
