using System;
using UnityEditor;
using UnityEngine;

namespace Incantium.Events.Editor
{
    /// <summary>
    /// Class representing additional reusable methods to draw delegates and their event handlers within the Unity
    /// Editor.
    /// </summary>
    internal static class EventExtensions
    {
        /// <summary>
        /// Method to draw all the event handlers of this <see cref="Delegate"/> to the Unity Editor inspector as a
        /// list.
        /// </summary>
        /// <param name="del">The <see cref="Delegate"/> to draw the event handlers within the Unity Editor.</param>
        /// <remarks>When no event handlers are connected, this method will leave a help box with a message.</remarks>
        internal static void DrawInvocationList(MulticastDelegate del)
        {
            var list = del?.GetInvocationList();
            
            if (list is not { Length: > 0 })
            {
                EditorGUILayout.HelpBox("No event handlers registered.", MessageType.Info, true);
                return;
            }

            DrawHeader();
            DrawList(list);
        }

        /// <summary>
        /// Method to draw the header of the event handlers.
        /// </summary>
        private static void DrawHeader()
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Target:", EditorStyles.boldLabel);
            EditorGUILayout.LabelField("Method:", EditorStyles.boldLabel);
            EditorGUILayout.EndHorizontal();
        }

        /// <summary>
        /// Method to draw the event handlers. Each member field cannot be edited through the Unity Editor.
        /// </summary>
        /// <param name="list">The event handlers of the delegate to draw.</param>
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
        /// Method to draw an event handler to the Unity Editor. One of the following scenario's can occur:
        /// <ul>
        ///     <li>There is no target for the event handler due to the method being static.</li>
        ///     <li>The target of the event handler is an <see cref="MonoBehaviour"/>.</li>
        ///     <li>The event handler is from another method.</li>
        /// </ul>
        /// </summary>
        /// <param name="del">The event handler to draw.</param>
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