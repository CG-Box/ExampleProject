using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{
    List<Key> keysList = new List<Key>();

    public void AddKey(Key newKey)
    {
        keysList.Add(newKey);
    }

    public void RemoveKey(Key removedKey)
    {
        keysList.Remove(removedKey);
    }
    public void RemoveKey(string checkedKeyName)
    {
        foreach (Key key in keysList)
        {
            if(key.KeyName == checkedKeyName)
            {
                keysList.Remove(key);
                break;
            }
        }
    }

    public bool ContainsKey(string checkedKeyName)
    {
        bool hasKey = false;
        foreach (Key key in keysList)
        {
            if(key.KeyName == checkedKeyName)
            {
                hasKey = true;
                break;
            }
        }
        return hasKey;
    }

    public void PrintKeys()
    {
        Debug.Log("****** Keys in holder ******");
        foreach (Key key in keysList)
        {
            Debug.Log(key.KeyName);
        }
    }
}
