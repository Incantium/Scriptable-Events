using Incantium.Events.Editor.Send;
using Incantium.Events.Request;
using UnityEditor;
using UnityEngine;

namespace Incantium.Events.Editor.Request
{
    /// <summary>
    /// Class representing the Unity Editor inspector for the <see cref="EventTruck{TResult}"/> implementation. This
    /// implementation only views the event channel without a way to invoke it.
    /// </summary>
    /// <seealso cref="EventTruckEditor{TResult}"/>
    public abstract class EventTruckViewer<TResult> : UnityEditor.Editor
    {
        /// <inheritdoc cref="EventBusEditor.eventBus"/>
        private EventTruck<TResult> eventTruck;
        
        /// <inheritdoc cref="EventBusEditor.active"/>
        private bool active => eventTruck.count > 0;

        /// <inheritdoc cref="EventBusEditor.OnEnable"/>
        private void OnEnable() => eventTruck = target as EventTruck<TResult>;

        /// <inheritdoc cref="EventBusEditor.OnInspectorGUI"/>
        public override void OnInspectorGUI()
        {
            EventExtensions.DrawInvocationList(eventTruck.action);
            ResetButton();
        }
        
        /// <inheritdoc cref="EventBusEditor.ResetButton"/>
        private void ResetButton()
        {
            EditorGUI.BeginDisabledGroup(!active);
            var pressed = GUILayout.Button(Styles.RESET);
            EditorGUI.EndDisabledGroup();
            
            if (!pressed) return;

            eventTruck.Reset();
        }
    }
    
    /// <summary>
    /// Class representing the Unity Editor inspector for the <see cref="EventTruck{T,TResult}"/> implementation. This
    /// implementation only views the event channel without a way to invoke it.
    /// </summary>
    /// <seealso cref="EventTruckEditor{T,TResult}"/>
    public abstract class EventTruckViewer<T, TResult> : UnityEditor.Editor
    {
        /// <inheritdoc cref="EventBusEditor.eventBus"/>
        private EventTruck<T, TResult> eventTruck;
        
        /// <inheritdoc cref="EventBusEditor.active"/>
        private bool active => eventTruck.count > 0;

        /// <inheritdoc cref="EventBusEditor.OnEnable"/>
        private void OnEnable() => eventTruck = target as EventTruck<T, TResult>;

        /// <inheritdoc cref="EventBusEditor.OnInspectorGUI"/>
        public override void OnInspectorGUI()
        {
            EventExtensions.DrawInvocationList(eventTruck.action);
            ResetButton();
        }
        
        /// <inheritdoc cref="EventBusEditor.ResetButton"/>
        private void ResetButton()
        {
            EditorGUI.BeginDisabledGroup(!active);
            var pressed = GUILayout.Button(Styles.RESET);
            EditorGUI.EndDisabledGroup();
            
            if (!pressed) return;

            eventTruck.Reset();
        }
    }
    
    /// <summary>
    /// Class representing the Unity Editor inspector for the default <see cref="EventTruck{T1,T2,TResult}"/>
    /// implementation. This implementation only views the event channel without a way to invoke it.
    /// </summary>
    /// <seealso cref="EventTruckEditor{T1,T2,TResult}"/>
    public abstract class EventTruckViewer<T1, T2, TResult> : UnityEditor.Editor
    {
        /// <inheritdoc cref="EventBusEditor.eventBus"/>
        private EventTruck<T1, T2, TResult> eventTruck;
        
        /// <inheritdoc cref="EventBusEditor.active"/>
        private bool active => eventTruck.count > 0;
        
        /// <inheritdoc cref="EventBusEditor.OnEnable"/>
        private void OnEnable() => eventTruck = target as EventTruck<T1, T2, TResult>;

        /// <inheritdoc cref="EventBusEditor.OnInspectorGUI"/>
        public override void OnInspectorGUI()
        {
            EventExtensions.DrawInvocationList(eventTruck.action);
            ResetButton();
        }
        
        /// <inheritdoc cref="EventBusEditor.ResetButton"/>
        private void ResetButton()
        {
            EditorGUI.BeginDisabledGroup(!active);
            var pressed = GUILayout.Button(Styles.RESET);
            EditorGUI.EndDisabledGroup();
            
            if (!pressed) return;

            eventTruck.Reset();
        }
    }
}