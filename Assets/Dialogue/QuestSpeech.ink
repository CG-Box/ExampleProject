INCLUDE globals.ink
{ surviveQuestRudeSpeech : -> WasRude}
{ (surviveQuestTaken == false && surviveQuestDialogueShowed == false) : -> TakingQuest }
{ (surviveQuestTaken == false && surviveQuestDialogueShowed == true) : -> QuestIgnored }
{ (surviveQuestTaken == true && surviveQuestDialogueShowed == true) : -> QuestAccepted | -> QuestFromAnotherSource}
#speaker:Student #layout:right
=== TakingQuest ===
Can you help me{surviveQuestDialogueShowed: now}? 
~ surviveQuestDialogueShowed = true
* [Take Quest] #quest: SurviveQuest
    ~ surviveQuestTaken = true
    Thanks dude  -> END
* [Don't Help]
    You are so egoistic! -> END
* [Ignore]
    -> END

=== QuestAccepted ===
You helping me so much dude. Thanks-> END
    
=== QuestIgnored ===
Why you didn't help me?
* [I'm sorry] -> TakingQuest
* [I have no time now] -> END
* [Cause you are stupid]
    ~ surviveQuestRudeSpeech = true
    -> END
    
=== WasRude ===
You are so rude!
I'm not talking with you anymore
->END

=== QuestFromAnotherSource ===
You read my mind! -> END