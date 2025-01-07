using Incantium.Events.Send;
using UnityEditor;
using UnityEngine;

namespace Incantium.Events.Editor.Send
{
    /// <summary>
    /// Class representing the Unity Editor inspector for <see cref="Vector3EventBus"/>.
    /// </summary>
    [CustomEditor(typeof(Vector3EventBus))]
    internal sealed class Vector3EventBusEditor : EventBusEditor<Vector3>
    {
        /// <inheritdoc cref="EventBusEditor{T}.DrawParameterField"/>
        /// <summary>
        /// Method to draw a <see cref="Vector3"/> property field to be invoked from the Unity Editor inspector.
        /// </summary>
        protected override Vector3 DrawParameterField(Vector3 current)
        {
            return EditorGUILayout.Vector3Field(GUIContent.none, current);
        }
    }
}