using UnityEditor;
using UnityEngine;

namespace Incantium.Events.Editor
{
    /// <summary>
    /// Class representing the Unity Editor inspector for <see cref="StringEventBus"/>.
    /// </summary>
    [CustomEditor(typeof(StringEventBus))]
    internal sealed class StringEventBusEditor : EventBusEditor<string>
    {
        /// <inheritdoc cref="EventBusEditor{T}.DrawParameterField"/>
        /// <summary>
        /// Method to draw a <see cref="string"/> property field to be invoked from the Unity Editor inspector.
        /// </summary>
        protected override string DrawParameterField(string current)
        {
            return EditorGUILayout.TextField(GUIContent.none, current);
        }
    }
}