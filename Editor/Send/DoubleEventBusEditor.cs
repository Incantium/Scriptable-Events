using Incantium.Events.Send;
using UnityEditor;
using UnityEngine;

namespace Incantium.Events.Editor.Send
{
    /// <summary>
    /// Class representing the Unity Editor inspector for <see cref="DoubleEventBus"/>.
    /// </summary>
    [CustomEditor(typeof(DoubleEventBus))]
    internal sealed class DoubleEventBusEditor : EventBusEditor<double>
    {
        /// <inheritdoc cref="EventBusEditor{T}.DrawParameterField"/>
        /// <summary>
        /// Method to draw a <see cref="double"/> property field to be invoked from the Unity Editor inspector.
        /// </summary>
        protected override double DrawParameterField(double current)
        {
            return EditorGUILayout.DoubleField(GUIContent.none, current);
        }
    }
}