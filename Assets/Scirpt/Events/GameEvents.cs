using System;

public class GameEvents
{ 
  public class CollectEv
  {
    public delegate void HandleCollectItem(Item item);
    public static HandleCollectItem OnItemCollect;
  }

  public class QuestEv
  {  
    public delegate void HandleQuestComplete(Quest quest);
    public static HandleQuestComplete OnQuestComplete;
  }

  public class CombatEv
  {
    public static Action<bool> OnEnemyDeath;
  }

  public class UiEv
  {
    public delegate bool HandleMenuOpen();
    public static HandleMenuOpen OnMenuOpen;

    public static Action onMenuClose;

    public static Action<int> onLevelLoad;
  }
}

// use example
// GameEvents.OnItemCollect += FunctionName; //register event
// GameEvents.OnItemCollect -= FunctionName; //unregister event
// GameEvents.OnItemCollect?.Invoke(Item item); //call event