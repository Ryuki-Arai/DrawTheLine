#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DrawLine))]
public class FealdEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        DrawLine instance = target as DrawLine;

        if (instance.DeleteLine)
        {
            instance.DeleteTime = 
                EditorGUILayout.FloatField(
                    new GUIContent("DeleteTime", "���������Ă�����ł���܂ł̎���"), 
                    instance.DeleteTime);
        }
    }
}
#endif