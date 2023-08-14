using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class StartDialog : MonoBehaviour
{
    public DialogManager DialogManager;

    private void Awake()
    {
        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("/size:up/Hi, /size:init/my name is Bob.", "Bob"));

        dialogTexts.Add(new DialogData("I am Bill. Popped out to let you know Asset can show other characters.", "Bill"));

        dialogTexts.Add(new DialogData("This Asset, The D'Dialog System has many features.", "Bob"));

        dialogTexts.Add(new DialogData("You can easily change text /color:red/color, /color:white/and /size:up//size:up/size/size:init/ like this.", "Bob"));

        dialogTexts.Add(new DialogData("Just put the command in the string!", "Bob"));

        dialogTexts.Add(new DialogData("You can also change the character's sprite /emote:Sad/like this, /click//emote:Happy/Smile.", "Bob"));

        dialogTexts.Add(new DialogData("If you need an emphasis effect, /wait:0.5/wait... /click/or click command.", "Bob"));

        dialogTexts.Add(new DialogData("Text can be /speed:down/slow... /speed:init//speed:up/or fast.", "Bob"));

        dialogTexts.Add(new DialogData("You don't even need to click on the window like this.../speed:0.1/ tada!/close/", "Bob"));

        dialogTexts.Add(new DialogData("/speed:0.1/AND YOU CAN'T SKIP THIS SENTENCE.", "Bob", null, false));

        dialogTexts.Add(new DialogData("And here we go, the haha sound! /click//sound:haha/haha.", "Bob", null, false));

        dialogTexts.Add(new DialogData("That's it! Please check the documents. Good luck to you.", "Bill"));

        DialogManager.Show(dialogTexts);

    }

    public float timeRemaining = 15;
    public bool timerIsRunning = false;
    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                RunSelection();
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    private void RunSelection() 
    {
        var dialogTexts = new List<DialogData>();
        var Text1 = new DialogData("What is 2 times 5?");
        Text1.SelectList.Add("Correct", "10");
        Text1.SelectList.Add("Wrong", "7");
        Text1.SelectList.Add("Whatever", "Why should I care?");

        Text1.Callback = () => Check_Correct();

        dialogTexts.Add(Text1);

        DialogManager.Show(dialogTexts);
    }

    private void Check_Correct()
    {
        var dialogTexts = new List<DialogData>();
        if (DialogManager.Result == "Correct")
        {
            dialogTexts.Add(new DialogData("You are right."));

            DialogManager.Show(dialogTexts);
        }
        else if (DialogManager.Result == "Wrong")
        {

            dialogTexts.Add(new DialogData("You are wrong."));

            DialogManager.Show(dialogTexts);
        }
        else
        {
            dialogTexts.Add(new DialogData("Right. You don't have to get the answer."));

            DialogManager.Show(dialogTexts);
        }
    }
}

