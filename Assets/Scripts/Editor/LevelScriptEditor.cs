using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(LevelScript))]
public class LevelScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        LevelScript myTarget = (LevelScript)target;

        myTarget.latitude = EditorGUILayout.TextField("Latitude", myTarget.latitude);
        myTarget.longitude = EditorGUILayout.TextField("Longitude", myTarget.longitude);

        

       // DrawDefaultInspector();

       
        if (GUILayout.Button("Get Weather"))
        {
            myTarget.clicked();

        }
    }
}