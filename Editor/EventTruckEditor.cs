using UnityEditor;
using UnityEngine;

namespace Incantium.Events.Editor
{
    /// <summary>
    /// Class representing the Unity Editor inspector for the default <see cref="EventTruck{T}"/> implementation.
    /// </summary>
    public abstract class EventTruckEditor<T> : UnityEditor.Editor
    {
        /// <inheritdoc cref="EventBusEditor.eventBus"/>
        private EventTruck<T> eventTruck;
        
        /// <inheritdoc cref="EventBusEditor.active"/>
        private bool active => eventTruck.count > 0;

        /// <inheritdoc cref="EventBusEditor.OnEnable"/>
        private void OnEnable() => eventTruck = target as EventTruck<T>;

        /// <inheritdoc cref="EventBusEditor.OnInspectorGUI"/>
        public override void OnInspectorGUI()
        {
            EventExtensions.DrawInvocationList(eventTruck.action);
            InvokeButton();
            InvokeAllButton();
            ResetButton();
        }

        /// <inheritdoc cref="EventBusEditor.InvokeButton"/>
        private void InvokeButton()
        {
            EditorGUI.BeginDisabledGroup(!active);
            var pressed = GUILayout.Button(Styles.REQUEST);
            EditorGUI.EndDisabledGroup();
            
            if (!pressed) return;
            
            var result = eventTruck.Request();
            
            Debug.Log(result);
        }
        
        /// <summary>
        /// Method to draw the invoke all button alongside additional parameter fields if necessary. When the scriptable
        /// event is in use, the user can click to invoke the event from the <see cref="ScriptableObject"/>.
        /// </summary>
        private void InvokeAllButton()
        {
            EditorGUI.BeginDisabledGroup(!active);
            var pressed = GUILayout.Button(Styles.REQUEST_ALL);
            EditorGUI.EndDisabledGroup();
            
            if (!pressed) return;
            
            var result = eventTruck.RequestAll();
            
            Debug.Log(string.Join(',', result));
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
    /// Class representing the Unity Editor inspector for the default <see cref="EventTruck{T,T}"/> implementation.
    /// </summary>
    public abstract class EventTruckEditor<T, TResult> : UnityEditor.Editor
    {
        /// <inheritdoc cref="EventBusEditor.eventBus"/>
        private EventTruck<T, TResult> eventTruck;
        
        /// <inheritdoc cref="EventBusEditor{T}.parameter"/>
        private T param;
        
        /// <inheritdoc cref="EventBusEditor.active"/>
        private bool active => eventTruck.count > 0;
        
        /// <inheritdoc cref="EventBusEditor{T}.DrawParameterField"/>
        protected abstract T DrawParameterField(T current);

        /// <inheritdoc cref="EventBusEditor.OnEnable"/>
        private void OnEnable() => eventTruck = target as EventTruck<T, TResult>;

        /// <inheritdoc cref="EventBusEditor.OnInspectorGUI"/>
        public override void OnInspectorGUI()
        {
            EventExtensions.DrawInvocationList(eventTruck.action);
            InvokeButton();
            InvokeAllButton();
            ResetButton();
        }

        /// <inheritdoc cref="EventBusEditor.InvokeButton"/>
        private void InvokeButton()
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUI.BeginDisabledGroup(!active);
            
            var pressed = GUILayout.Button(Styles.REQUEST);
            
            param = DrawParameterField(param);
            
            EditorGUI.EndDisabledGroup();
            EditorGUILayout.EndHorizontal();
            
            if (!pressed) return;
            
            var result = eventTruck.Request(param);
            
            Debug.Log(result);
        }
        
        /// <inheritdoc cref="EventTruckEditor{T}.InvokeAllButton"/>
        private void InvokeAllButton()
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUI.BeginDisabledGroup(!active);
            
            var pressed = GUILayout.Button(Styles.REQUEST);
            
            param = DrawParameterField(param);
            
            EditorGUI.EndDisabledGroup();
            EditorGUILayout.EndHorizontal();
            
            if (!pressed) return;
            
            var result = eventTruck.RequestAll(param);
            
            Debug.Log(string.Join(',', result));
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
    /// Class representing the Unity Editor inspector for the default <see cref="EventTruck{T,T,T}"/> implementation.
    /// </summary>
    public abstract class EventTruckEditor<T1, T2, TResult> : UnityEditor.Editor
    {
        /// <inheritdoc cref="EventBusEditor.eventBus"/>
        private EventTruck<T1, T2, TResult> eventTruck;
        
        /// <inheritdoc cref="EventBusEditor{T}.parameter"/>
        private T1 param1;
        
        /// <inheritdoc cref="EventBusEditor{T}.parameter"/>
        private T2 param2;
        
        /// <inheritdoc cref="EventBusEditor.active"/>
        private bool active => eventTruck.count > 0;
        
        /// <inheritdoc cref="EventBusEditor{T}.DrawParameterField"/>
        protected abstract T1 DrawParameterField1(T1 current);
        
        /// <inheritdoc cref="EventBusEditor{T}.DrawParameterField"/>
        protected abstract T2 DrawParameterField2(T2 current);
        
        /// <inheritdoc cref="EventBusEditor.OnEnable"/>
        private void OnEnable() => eventTruck = target as EventTruck<T1, T2, TResult>;

        /// <inheritdoc cref="EventBusEditor.OnInspectorGUI"/>
        public override void OnInspectorGUI()
        {
            EventExtensions.DrawInvocationList(eventTruck.action);
            InvokeButton();
            InvokeAllButton();
            ResetButton();
        }

        /// <inheritdoc cref="EventBusEditor.InvokeButton"/>
        private void InvokeButton()
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUI.BeginDisabledGroup(!active);
            
            var pressed = GUILayout.Button(Styles.REQUEST);
            
            param1 = DrawParameterField1(param1);
            param2 = DrawParameterField2(param2);
            
            EditorGUI.EndDisabledGroup();
            EditorGUILayout.EndHorizontal();
            
            if (!pressed) return;
            
            var result = eventTruck.Request(param1, param2);
            
            Debug.Log(result);
        }
        
        /// <inheritdoc cref="EventTruckEditor{T}.InvokeAllButton"/>
        private void InvokeAllButton()
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUI.BeginDisabledGroup(!active);
            
            var pressed = GUILayout.Button(Styles.REQUEST);
            
            param1 = DrawParameterField1(param1);
            param2 = DrawParameterField2(param2);
            
            EditorGUI.EndDisabledGroup();
            EditorGUILayout.EndHorizontal();
            
            if (!pressed) return;
            
            var result = eventTruck.RequestAll(param1, param2);
            
            Debug.Log(string.Join(',', result));
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