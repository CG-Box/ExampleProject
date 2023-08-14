using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour, IDataPersistence
{
    [SerializeField] protected string savedId;
    [SerializeField] protected string fieldName = "CollectedDictionaryDefault";

    protected bool collected = false;

    private SerializableDictionary<string, bool> collectableDictionary;

    public delegate void AlreadyCollectedDelegate(); 
    public AlreadyCollectedDelegate AlreadyCollectedFunction;

    [ContextMenu("Generate guid for id")]
    private void GenerateGuid() 
    {
        savedId = System.Guid.NewGuid().ToString();
    }

    private SerializableDictionary<string, bool> GetField(GameData data)
    {
        //collectableDictionary = (SerializableDictionary<string, bool>)(data.scene.GetType().GetField(fieldName).GetValue(data.scene));
        var obj = data.scene;
        var type = obj.GetType();
        var field = type.GetField(fieldName);
        if(field == null)
        {
            Debug.LogError("Error with field name <"+fieldName+">, GameData scene fields and string name must be the same");
            return null;
        }
        object value = field.GetValue(obj);
        return (SerializableDictionary<string, bool>)value;
    }

    public void LoadData(GameData data)
    {        
        collectableDictionary = GetField(data);

        collectableDictionary.TryGetValue(savedId, out collected);
        if (collected) 
        {
            AlreadyCollectedFunction?.Invoke();
        }
    }

    public void SaveData(GameData data)
    {
        collectableDictionary = GetField(data);

        if (collectableDictionary.ContainsKey(savedId))
        {
            collectableDictionary.Remove(savedId);
        }
        collectableDictionary.Add(savedId, collected);
    }    
}
