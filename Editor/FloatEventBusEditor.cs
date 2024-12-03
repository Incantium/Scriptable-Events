using UnityEditor;
using UnityEngine;

namespace Incantium.Events.Editor
{
    /// <summary>
    /// Class representing the Unity Editor inspector for <see cref="FloatEventBus"/>.
    /// </summary>
    [CustomEditor(typeof(FloatEventBus))]
    internal sealed class FloatEventBusEditor : EventBusEditor<float>
    {
        /// <inheritdoc cref="EventBusEditor{T}.DrawParameterField"/>
        /// <summary>
        /// Method to draw a <see cref="bool"/> property field to be invoked from the Unity Editor inspector.
        /// </summary>
        protected override float DrawParameterField(float current)
        {
            return EditorGUILayout.FloatField(GUIContent.none, current);
        }
    }
}