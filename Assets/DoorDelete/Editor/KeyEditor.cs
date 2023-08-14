using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Key), editorForChildClasses: true)]
public class KeyEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        //GUI.enabled = Application.isPlaying;

        Key targetScript = target as Key;
        if (GUILayout.Button("Init Key by SO"))
            targetScript.InitKey();
    }
}