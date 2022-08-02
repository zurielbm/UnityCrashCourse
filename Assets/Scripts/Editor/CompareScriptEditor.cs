using UnityEngine;
using System.Collections;
using UnityEditor;


[CustomEditor(typeof(CompareScript))]
public class CompareScriptEditor : Editor
{ 
    public override void OnInspectorGUI()
    {
        CompareScript myTarget = (CompareScript)target;
        DrawDefaultInspector();
        myTarget.PlayerPref = EditorGUILayout.TextField("Latitude", myTarget.PlayerPref);
        myTarget.JSON = EditorGUILayout.TextField("Longitude", myTarget.JSON);

        GUILayout.BeginHorizontal();
        EditorGUILayout.TextArea(myTarget.GetPlayerPref, GUILayout.MaxWidth(200));

        EditorGUILayout.TextArea( myTarget.GetJSON, GUILayout.MaxWidth(200));
        GUILayout.EndHorizontal();

    }
}
