using Incantium.Events.Send;
using UnityEditor;
using UnityEngine;

namespace Incantium.Events.Editor.Send
{
    /// <summary>
    /// Class representing the Unity Editor inspector for <see cref="GameObjectEventBus"/>.
    /// </summary>
    [CustomEditor(typeof(GameObjectEventBus))]
    internal sealed class GameObjectEventBusEditor : EventBusEditor<GameObject>
    {
        /// <inheritdoc cref="EventBusEditor{T}.DrawParameterField"/>
        /// <summary>
        /// Method to draw a <see cref="GameObject"/> property field to be invoked from the Unity Editor inspector.
        /// </summary>
        protected override GameObject DrawParameterField(GameObject current)
        {
            return EditorGUILayout.ObjectField(GUIContent.none, current, typeof(GameObject), false) as GameObject;
        }
    }
}