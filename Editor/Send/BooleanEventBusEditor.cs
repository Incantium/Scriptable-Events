using Incantium.Events.Send;
using UnityEditor;
using UnityEngine;

namespace Incantium.Events.Editor.Send
{
    /// <summary>
    /// Class representing the Unity Editor inspector for <see cref="BooleanEventBus"/>.
    /// </summary>
    [CustomEditor(typeof(BooleanEventBus))]
    internal sealed class BooleanEventBusEditor : EventBusEditor<bool>
    {
        /// <inheritdoc cref="EventBusEditor{T}.DrawParameterField"/>
        /// <summary>
        /// Method to draw a <see cref="bool"/> property field to be invoked from the Unity Editor inspector.
        /// </summary>
        protected override bool DrawParameterField(bool current)
        {
            return EditorGUILayout.Toggle(GUIContent.none, current);
        }
    }
}