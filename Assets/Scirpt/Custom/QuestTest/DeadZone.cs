using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DeadZone : MonoBehaviour
{
    public static event HandleGoalCollected OnGoalTaken;
	public delegate void HandleGoalCollected(Goal questGoal);

    public static event Action<Goal> OnGoalComplete;

    Goal currentGoal = null;

    public Quest_SO questSO = null;
    private Quest_SO _currentQuest = null;


    public static event Action<Quest_SO> OnQuestTaken;
    public static event Action<Quest_SO> OnQuestComplete;

    void OnTriggerEnter2D (Collider2D collider)
    {
        //HadleSimpleGoal(collider);
        HadleSimpleQuest(collider);
    }

    void HadleSimpleQuest (Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            if(_currentQuest == null)
            {
                if(questSO == null)
                {
                    Debug.LogError("Quest must be defined");
                    return;
                }
                _currentQuest = questSO;

                OnQuestTaken?.Invoke(_currentQuest);
            }
            else
            {
                foreach(Goal curGoal in _currentQuest.Goals)
                {
                    curGoal.ChangeAmount(+1);
                }
                _currentQuest.CheckGoals();
                if(_currentQuest.IsCompleted())
                {
                    OnQuestComplete?.Invoke(_currentQuest);
                    _currentQuest.Reset();
                    _currentQuest = null;
                }
            }
   
        }
    }
    void HadleSimpleGoal (Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            if(currentGoal == null)
            {
                currentGoal = new Goal();
                currentGoal.Desciption = "Goal Description";
                currentGoal.RequiredAmount = 2;
                currentGoal.CurrentAmount = 0;
                currentGoal.isCompleted = false;
                //currentGoal.Quest = new Quest();

                OnGoalTaken?.Invoke(currentGoal);
            }
            else
            {
                currentGoal.CurrentAmount++;
                currentGoal.Check();
                if(currentGoal.isCompleted)
                {
                    OnGoalComplete?.Invoke(currentGoal);
                    currentGoal = null;
                }
            }
   
        }
    }
}
