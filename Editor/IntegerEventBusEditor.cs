using UnityEditor;
using UnityEngine;

namespace Incantium.Events.Editor
{
    /// <summary>
    /// Class representing the Unity Editor inspector for <see cref="IntegerEventBus"/>.
    /// </summary>
    [CustomEditor(typeof(IntegerEventBus))]
    internal sealed class IntegerEventBusEditor : EventBusEditor<int>
    {
        /// <inheritdoc cref="EventBusEditor{T}.DrawParameterField"/>
        /// <summary>
        /// Method to draw a <see cref="int"/> property field to be invoked from the Unity Editor inspector.
        /// </summary>
        protected override int DrawParameterField(int current)
        {
            return EditorGUILayout.IntField(GUIContent.none, current);
        }
    }
}