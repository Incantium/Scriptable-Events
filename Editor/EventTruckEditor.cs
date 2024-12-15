using UnityEditor;
using UnityEngine;

namespace Incantium.Events.Editor
{
    public abstract class EventTruckEditor<T> : UnityEditor.Editor
    {
        /// <inheritdoc cref="EventBusEditor.eventBus"/>
        private EventTruck<T> eventTruck;
        
        /// <inheritdoc cref="EventBusEditor.active"/>
        private bool active => EditorApplication.isPlaying && eventTruck.onRequest != null;

        /// <inheritdoc cref="EventBusEditor.OnEnable"/>
        private void OnEnable() => eventTruck = target as EventTruck<T>;

        /// <inheritdoc cref="EventBusEditor.OnInspectorGUI"/>
        public override void OnInspectorGUI()
        {
            eventTruck.onRequest?.DrawInvocationList();
            InvokeButton();
            ResetButton();
        }

        /// <inheritdoc cref="EventBusEditor{T}.InvokeButton"/>
        private void InvokeButton()
        {
            EditorGUI.BeginDisabledGroup(!active);
            var pressed = GUILayout.Button("Request");
            EditorGUI.EndDisabledGroup();
            
            if (!pressed || eventTruck.onRequest == null) return;
            
            var result = eventTruck.onRequest.Invoke();
            
            Debug.Log(result);
        }
        
        /// <inheritdoc cref="EventBusEditor.ResetButton"/>
        private void ResetButton()
        {
            EditorGUI.BeginDisabledGroup(!active);
            var pressed = GUILayout.Button("Reset");
            EditorGUI.EndDisabledGroup();
            
            if (!pressed || eventTruck.onRequest == null) return;

            eventTruck.onRequest = null;
        }
    }
    
    public abstract class EventTruckEditor<T, TResult> : UnityEditor.Editor
    {
        /// <inheritdoc cref="EventBusEditor.eventBus"/>
        private EventTruck<T, TResult> eventTruck;
        
        /// <inheritdoc cref="EventBusEditor{T}.parameter"/>
        private T param;
        
        /// <inheritdoc cref="EventBusEditor.active"/>
        private bool active => EditorApplication.isPlaying && eventTruck.onRequest != null;
        
        /// <inheritdoc cref="EventBusEditor{T}.DrawParameterField"/>
        protected abstract T DrawParameterField(T current);

        /// <inheritdoc cref="EventBusEditor.OnEnable"/>
        private void OnEnable() => eventTruck = target as EventTruck<T, TResult>;

        /// <inheritdoc cref="EventBusEditor.OnInspectorGUI"/>
        public override void OnInspectorGUI()
        {
            eventTruck.onRequest?.DrawInvocationList();
            InvokeButton();
            ResetButton();
        }

        /// <inheritdoc cref="EventBusEditor{T}.InvokeButton"/>
        private void InvokeButton()
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUI.BeginDisabledGroup(!active);
            
            var pressed = GUILayout.Button("Request");
            
            param = DrawParameterField(param);
            
            EditorGUI.EndDisabledGroup();
            EditorGUILayout.EndHorizontal();
            
            if (!pressed || eventTruck.onRequest == null) return;
            
            var result = eventTruck.onRequest.Invoke(param);
            
            Debug.Log(result);
        }
        
        /// <inheritdoc cref="EventBusEditor.ResetButton"/>
        private void ResetButton()
        {
            EditorGUI.BeginDisabledGroup(!active);
            var pressed = GUILayout.Button("Reset");
            EditorGUI.EndDisabledGroup();
            
            if (!pressed || eventTruck.onRequest == null) return;

            eventTruck.onRequest = null;
        }
    }
    
    public abstract class EventTruckEditor<T1, T2, TResult> : UnityEditor.Editor
    {
        /// <inheritdoc cref="EventBusEditor.eventBus"/>
        private EventTruck<T1, T2, TResult> eventTruck;
        
        /// <inheritdoc cref="EventBusEditor{T}.parameter"/>
        private T1 param1;
        
        /// <inheritdoc cref="EventBusEditor{T}.parameter"/>
        private T2 param2;
        
        /// <inheritdoc cref="EventBusEditor.active"/>
        private bool active => EditorApplication.isPlaying && eventTruck.onRequest != null;
        
        /// <inheritdoc cref="EventBusEditor{T}.DrawParameterField"/>
        protected abstract T1 DrawParameterField1(T1 current);
        
        /// <inheritdoc cref="EventBusEditor{T}.DrawParameterField"/>
        protected abstract T2 DrawParameterField2(T2 current);
        
        /// <inheritdoc cref="EventBusEditor.OnEnable"/>
        private void OnEnable() => eventTruck = target as EventTruck<T1, T2, TResult>;

        /// <inheritdoc cref="EventBusEditor.OnInspectorGUI"/>
        public override void OnInspectorGUI()
        {
            eventTruck.onRequest?.DrawInvocationList();
            InvokeButton();
            ResetButton();
        }

        /// <inheritdoc cref="EventBusEditor{T}.InvokeButton"/>
        private void InvokeButton()
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUI.BeginDisabledGroup(!active);
            
            var pressed = GUILayout.Button("Request");
            
            param1 = DrawParameterField1(param1);
            param2 = DrawParameterField2(param2);
            
            EditorGUI.EndDisabledGroup();
            EditorGUILayout.EndHorizontal();
            
            if (!pressed || eventTruck.onRequest == null) return;
            
            var result = eventTruck.onRequest.Invoke(param1, param2);
            
            Debug.Log(result);
        }
        
        /// <inheritdoc cref="EventBusEditor.ResetButton"/>
        private void ResetButton()
        {
            EditorGUI.BeginDisabledGroup(!active);
            var pressed = GUILayout.Button("Reset");
            EditorGUI.EndDisabledGroup();
            
            if (!pressed || eventTruck.onRequest == null) return;

            eventTruck.onRequest = null;
        }
    }
}