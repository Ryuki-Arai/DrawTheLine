using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Line))]
public class FealdEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Line instance = target as Line;

        if (instance.DeleteLine)
        {
            instance.DeleteTime = 
                EditorGUILayout.FloatField(
                    new GUIContent("DeleteTime", "線を引いてから消滅するまでの時間"), 
                    instance.DeleteTime);
        }
    }
}
