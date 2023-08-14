using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCookies : Quest
{
 
    void Start()
    {
        Name = "Collect Cookies";
        Desciption = "Collect all hot cookies in a level";
        ItemReward =  new Item{type = ItemType.Medkit, amount = 1 };

        Goals.Add(new KillGoal(this, 0, "Kill 3 cookies", false, 0, 3));

        Goals.ForEach(g => g.Init());
    }
}
