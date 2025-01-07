using Incantium.Events.Send;
using UnityEditor;
using UnityEngine;

namespace Incantium.Events.Editor.Send
{
    /// <summary>
    /// Class representing the Unity Editor inspector for <see cref="Vector2EventBus"/>.
    /// </summary>
    [CustomEditor(typeof(Vector2EventBus))]
    internal sealed class Vector2EventBusEditor : EventBusEditor<Vector2>
    {
        /// <inheritdoc cref="EventBusEditor{T}.DrawParameterField"/>
        /// <summary>
        /// Method to draw a <see cref="Vector2"/> property field to be invoked from the Unity Editor inspector.
        /// </summary>
        protected override Vector2 DrawParameterField(Vector2 current)
        {
            return EditorGUILayout.Vector2Field(GUIContent.none, current);
        }
    }
}