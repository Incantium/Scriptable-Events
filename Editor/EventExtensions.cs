using System;
using UnityEditor;
using UnityEngine;

namespace Incantium.Events.Editor
{
    /// <summary>
    /// Class representing additional reusable methods to draw delegates within the Unity Editor.
    /// </summary>
    internal static class EventExtensions
    {
        /// <summary>
        /// Method to draw the Unity Editor list of all connected methods to this <see cref="Delegate"/> list.
        /// </summary>
        /// <param name="del">The <see cref="Delegate"/> to draw within the Unity Editor.</param>
        /// <remarks>When no methods are connected, this method will leave a help box with a message.</remarks>
        internal static void DrawInvocationList(this MulticastDelegate del)
        {
            var list = del?.GetInvocationList();
            
            if (list is not { Length: > 0 })
            {
                EditorGUILayout.HelpBox("No callbacks registered.", MessageType.Info, true);
                return;
            }

            DrawHeader();
            DrawList(list);
        }

        /// <summary>
        /// Method to draw the header of the list.
        /// </summary>
        private static void DrawHeader()
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Target:", EditorStyles.boldLabel);
            EditorGUILayout.LabelField("Method:", EditorStyles.boldLabel);
            EditorGUILayout.EndHorizontal();
        }

        /// <summary>
        /// Method to draw the list. Each member field cannot be edited through the Unity Editor.
        /// </summary>
        /// <param name="list">The list of delegates to draw.</param>
        private static void DrawList(Delegate[] list)
        {
            EditorGUI.BeginDisabledGroup(true);
                
            foreach (var del in list)
            {
                DrawField(del);
                
                EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
            }
            
            EditorGUI.EndDisabledGroup();
        }

        /// <summary>
        /// Method to draw the delegate to the Unity Editor. One of the following scenario's can occur:
        /// <ul>
        ///     <li>There is no target for the delegate due to the method being static.</li>
        ///     <li>The target is an <see cref="MonoBehaviour"/>.</li>
        ///     <li>The delegate is from another method.</li>
        /// </ul>
        /// </summary>
        /// <param name="del">The delegate to draw.</param>
        private static void DrawField(Delegate del)
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