using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CollisionEvent), editorForChildClasses: true)]
public class CollisionEventEditor : Editor
{
    #region SerializedProperties 
    SerializedProperty useTag;
    SerializedProperty _colliderTag;
    SerializedProperty _colliderScript;
    SerializedProperty _onTriggerEnter;
    SerializedProperty _onTriggerExit;

    #endregion

    private void OnEnable()
    {
        useTag = serializedObject.FindProperty("useTag");
        _colliderTag = serializedObject.FindProperty("_colliderTag");
        _colliderScript = serializedObject.FindProperty("_colliderScript");
        _onTriggerEnter = serializedObject.FindProperty("_onTriggerEnter");
        _onTriggerExit = serializedObject.FindProperty("_onTriggerExit");
    }

    public override void OnInspectorGUI()
    {
        CollisionEvent targetScript = target as CollisionEvent;

        GUILayout.Space(5); // space in pixels
        GUILayout.Label("Calling functions from script");
        GUILayout.BeginHorizontal(); //start for horizontal group

            if (GUILayout.Button("Print target"))
                targetScript.PrintTarget();

            if (GUILayout.Button("Call debug log"))
                Debug.Log($"Debug log called {useTag}");

        GUILayout.EndHorizontal(); //end for horizontal group
        GUILayout.Space(10); // space in pixels

        serializedObject.Update(); // for updating fields https://youtu.be/xFtFWmiW7IE?t=231
        EditorGUILayout.PropertyField(useTag);
        if(targetScript.UseTag)
        {
            EditorGUILayout.PropertyField(_colliderTag);
        }
        else
        {
            EditorGUILayout.PropertyField(_colliderScript);
        }
        EditorGUILayout.PropertyField(_onTriggerEnter);
        EditorGUILayout.PropertyField(_onTriggerExit);
        serializedObject.ApplyModifiedProperties();  // updating ends   

        //base.OnInspectorGUI();
    }
}