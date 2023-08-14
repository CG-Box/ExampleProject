using UnityEngine;
using System;


[CreateAssetMenu(fileName = "Key_ScriptObject", menuName = "SriptableObjects/Key_ScriptObject", order = 5)]
public class KeySO: ScriptableObject
{
    [SerializeField]private string keyName = "default_key_name";

    [SerializeField]private Color keyColor = Color.white;

    public string KeyName
    {
        get
        {
            return keyName;
        }
    }
    public Color KeyColor
    {
        get
        {
            return keyColor;
        }
    }

    public KeySO (string name)
    {
        keyName = name;
    }
    public KeySO (string name, Color color)
    {
        keyName = name;
        keyColor = color;
    }
}
