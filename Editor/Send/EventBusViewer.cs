using Incantium.Events.Send;
using UnityEditor;
using UnityEngine;

namespace Incantium.Events.Editor.Send
{
    /// <summary>
    /// Class representing the Unity Editor inspector for the <see cref="EventBus{T}"/> implementation. This
    /// implementation only views the event channel without a way to invoke it.
    /// </summary>
    /// <typeparam name="T">The first parameter typing.</typeparam>
    /// <seealso cref="EventBusEditor{T}"/>
    public abstract class EventBusViewer<T> : UnityEditor.Editor
    {
        /// <inheritdoc cref="EventBusEditor.eventBus"/>
        private EventBus<T> eventBus;
        
        /// <inheritdoc cref="EventBusEditor.active"/>
        private bool active => eventBus.count > 0;
        
        /// <inheritdoc cref="EventBusEditor.OnEnable"/>
        private void OnEnable() => eventBus = target as EventBus<T>;
        
        /// <inheritdoc cref="EventBusEditor.OnInspectorGUI"/>
        public override void OnInspectorGUI()
        {
            EventExtensions.DrawInvocationList(eventBus.action);
            ResetButton();
        }

        /// <inheritdoc cref="EventBusEditor.ResetButton"/>
        private void ResetButton()
        {
            EditorGUI.BeginDisabledGroup(!active);
            var pressed = GUILayout.Button(Styles.RESET);
            EditorGUI.EndDisabledGroup();
            
            if (!pressed) return;

            eventBus.Reset();
        }
    }
    
    /// <summary>
    /// Class representing the Unity Editor inspector for the <see cref="EventBus{T1,T2}"/> implementation. This
    /// implementation only views the event channel without a way to invoke it.
    /// </summary>
    /// <typeparam name="T1">The first parameter typing.</typeparam>
    /// <typeparam name="T2">The second parameter typing.</typeparam>
    /// <seealso cref="EventBusEditor{T1,T2}"/>
    public abstract class EventBusViewer<T1, T2> : UnityEditor.Editor
    {
        /// <inheritdoc cref="EventBusEditor.eventBus"/>
        private EventBus<T1, T2> eventBus;
        
        /// <inheritdoc cref="EventBusEditor.active"/>
        private bool active => eventBus.count > 0;

        /// <inheritdoc cref="EventBusEditor.OnEnable"/>
        private void OnEnable() => eventBus = target as EventBus<T1, T2>;
        
        /// <inheritdoc cref="EventBusEditor.OnInspectorGUI"/>
        public override void OnInspectorGUI()
        {
            EventExtensions.DrawInvocationList(eventBus.action);
            ResetButton();
        }

        /// <inheritdoc cref="EventBusEditor.ResetButton"/>
        private void ResetButton()
        {
            EditorGUI.BeginDisabledGroup(!active);
            var pressed = GUILayout.Button(Styles.RESET);
            EditorGUI.EndDisabledGroup();
            
            if (!pressed) return;

            eventBus.Reset();
        }
    }
    
    /// <summary>
    /// Class representing the Unity Editor inspector for the <see cref="EventBus{T1,T2,T3}"/> implementation. This
    /// implementation only views the event channel without a way to invoke it.
    /// </summary>
    /// <typeparam name="T1">The first parameter typing.</typeparam>
    /// <typeparam name="T2">The second parameter typing.</typeparam>
    /// <typeparam name="T3">The third parameter typing.</typeparam>
    /// <seealso cref="EventBusEditor{T1,T2,T3}"/>
    public abstract class EventBusViewer<T1, T2, T3> : UnityEditor.Editor
    {
        /// <inheritdoc cref="EventBusEditor.eventBus"/>
        private EventBus<T1, T2, T3> eventBus;
        
        /// <inheritdoc cref="EventBusEditor.active"/>
        private bool active => eventBus.count > 0;

        /// <inheritdoc cref="EventBusEditor.OnEnable"/>
        private void OnEnable() => eventBus = target as EventBus<T1, T2, T3>;
        
        /// <inheritdoc cref="EventBusEditor.OnInspectorGUI"/>
        public override void OnInspectorGUI()
        {
            EventExtensions.DrawInvocationList(eventBus.action);
            ResetButton();
        }

        /// <inheritdoc cref="EventBusEditor.ResetButton"/>
        private void ResetButton()
        {
            EditorGUI.BeginDisabledGroup(!active);
            var pressed = GUILayout.Button(Styles.RESET);
            EditorGUI.EndDisabledGroup();
            
            if (!pressed) return;

            eventBus.Reset();
        }
    }
}