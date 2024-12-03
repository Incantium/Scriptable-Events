using System;
using UnityEditor;
using UnityEngine;

namespace Incantium.Events.Editor
{
    internal static class EventExtensions
    {
        internal static void InvocationList(Delegate[] list)
        {
            if (list is not { Length: > 0 })
            {
                EditorGUILayout.HelpBox("No callbacks registered.", MessageType.Info, true);
                return;
            }

            CreateHeader();
            CreateList(list);
        }

        private static void CreateHeader()
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Target:", EditorStyles.boldLabel);
            EditorGUILayout.LabelField("Method:", EditorStyles.boldLabel);
            EditorGUILayout.EndHorizontal();
        }

        private static void CreateList(Delegate[] list)
        {
            EditorGUI.BeginDisabledGroup(true);
                
            foreach (var del in list)
            {
                CreateField(del);
                
                EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
            }
            
            EditorGUI.EndDisabledGroup();
        }

        private static void CreateField(Delegate del)
        {
            EditorGUILayout.BeginHorizontal();
            
            if (del.Target == null) EditorGUILayout.LabelField("Static Method");
            else if (del.Target is MonoBehaviour script) EditorGUILayout.ObjectField(GUIContent.none, script, script.GetType(), false);
            else EditorGUILayout.LabelField(del.Target?.ToString());

            EditorGUILayout.LabelField(del.Method.Name);
                
            EditorGUILayout.EndHorizontal();
        } 
    }
}