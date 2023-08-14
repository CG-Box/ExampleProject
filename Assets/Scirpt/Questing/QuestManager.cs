using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class QuestManager : MonoBehaviour
{
    //Full rework needed
    public static void StartQuest(string questName)
    {
        if(questsList.Length == 1)
        {
            Array.Resize(ref questsList, 2);
            GetQuest();
        }
        foreach (Quest quest in questsList)
        {
            Type type = quest.GetType();
            string typeStr = type.ToString();

            Debug.Log("quest type: "+typeStr);

            if(typeStr == questName)
            {
                GameObject Player = GameObject.FindWithTag("Player");
                if(Player)
                {
                    Player.AddComponent<SurviveQuest>();
                }
            }
        }
    }

    private static Quest[] questsList = new Quest[1];
    private static void GetQuest()
    {
        GameObject Manager = GameObject.Find("QuestManager");
        questsList = Manager.GetComponents<Quest>();
    }
}
