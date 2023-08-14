Hello there! #speaker:Student #layout:right
-> main

=== main ===
Can you help me?
+ [Take Quest] #quest: SurviveQuest
    Thanks dude
    -> END
+ [Don't Help]->Mid
+ [Ignore]
    You are so egoistic!
    ->END

=== Mid ===
Did you hear that?
+ [Strange]
    That makes me feel so <color=\#FF0000>creepy</color> !!
+ [Nothing]
    Oh, well that makes me feel <color=\#00FF00>better</color> too. 
    
- I hope it's over.

Well, do you think we can survive?
+ [Yes] #quest: SurviveQuest
    Your are so cute.
    Now i'm happy!!
    -> END
+ [No]
    We all die!!
    -> END