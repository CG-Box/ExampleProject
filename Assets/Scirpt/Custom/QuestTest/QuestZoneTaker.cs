using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestZoneTaker : MonoBehaviour
{

    void OnEnable()
    {
        DeadZone.OnGoalTaken += LogQoal;
        DeadZone.OnGoalComplete += LogQoal;

        DeadZone.OnQuestTaken += LogQuest;
        DeadZone.OnQuestComplete += LogQuest;
    }
    void OnDisable()
    {
        DeadZone.OnGoalTaken -= LogQoal;
        DeadZone.OnGoalComplete -= LogQoal;

        DeadZone.OnQuestTaken -= LogQuest;
        DeadZone.OnQuestComplete -= LogQuest;
    }

    void LogQuest(Quest_SO questSO)
    {
        questSO.LogConsole();
    }

    void LogQoal(Goal questGoal)
    {
        Debug.Log("*** Goal info ***");
        Debug.Log("Description: "+questGoal.Desciption);
        Debug.Log("CurrentAmount: "+questGoal.CurrentAmount);

        if(questGoal.isCompleted)
        {
            Debug.Log(":::::::: Goal Complete!!! ::::::::");
        }
    }
}
