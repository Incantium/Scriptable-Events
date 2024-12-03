using UnityEditor;
using UnityEngine;

namespace Incantium.Events.Editor
{
    [CustomEditor(typeof(EventBus))]
    internal sealed class EventBusEditor : UnityEditor.Editor
    {
        private EventBus eventBus;

        private void OnEnable() => eventBus = target as EventBus;
        
        public override void OnInspectorGUI()
        {
            var list = eventBus.onSend?.GetInvocationList();
            
            EventExtensions.InvocationList(list);
            InvokeButton();
            ResetButton();
        }
        
        private void InvokeButton()
        {
            if (!GUILayout.Button("Invoke")) return;
            
            eventBus.onSend?.Invoke();
        }

        private void ResetButton()
        {
            if (!GUILayout.Button("Reset")) return;

            eventBus.onSend = null;
        }
    }
    
    public abstract class EventBusEditor<T> : UnityEditor.Editor
    {
        private EventBus<T> eventBus;
        private T parameter;

        /// <summary>
        /// Method to draw the property field of the parameter in this event bus.
        /// </summary>
        /// <param name="current">The saved parameter value.</param>
        /// <returns>The set parameter value.</returns>
        /// <remarks>Solely use <see cref="EditorGUILayout"/> to draw the property field.</remarks>
        protected abstract T DrawParameterField(T current);

        private void OnEnable() => eventBus = target as EventBus<T>;
        
        public override void OnInspectorGUI()
        {
            var list = eventBus.onSend?.GetInvocationList();
            
            EventExtensions.InvocationList(list);
            InvokeButton();
            ResetButton();
        }
        
        private void InvokeButton()
        {
            EditorGUILayout.BeginHorizontal();
            
            var pressed = GUILayout.Button("Invoke");
            
            parameter = DrawParameterField(parameter);
            
            EditorGUILayout.EndHorizontal();
            
            if (!pressed) return;
            
            eventBus.onSend?.Invoke(parameter);
        }

        private void ResetButton()
        {
            if (!GUILayout.Button("Reset")) return;

            eventBus.onSend = null;
        }
    }
    
    public abstract class EventBusEditor<T1, T2> : UnityEditor.Editor
    {
        private EventBus<T1, T2> eventBus;
        private T1 param1;
        private T2 param2;

        protected abstract T1 DrawParameterField1(T1 current);
        protected abstract T2 DrawParameterField2(T2 current);

        private void OnEnable() => eventBus = target as EventBus<T1, T2>;
        
        public override void OnInspectorGUI()
        {
            var list = eventBus.onSend?.GetInvocationList();
            
            EventExtensions.InvocationList(list);
            InvokeButton();
            ResetButton();
        }
        
        private void InvokeButton()
        {
            param1 = DrawParameterField1(param1);
            param2 = DrawParameterField2(param2);
            
            if (!GUILayout.Button("Invoke")) return;
            
            eventBus.onSend?.Invoke(param1, param2);
        }

        private void ResetButton()
        {
            if (!GUILayout.Button("Reset")) return;

            eventBus.onSend = null;
        }
    }
    
    public abstract class EventBusEditor<T1, T2, T3> : UnityEditor.Editor
    {
        private EventBus<T1, T2, T3> eventBus;
        private T1 param1;
        private T2 param2;
        private T3 param3;

        protected abstract T1 DrawParameterField1(T1 current);
        protected abstract T2 DrawParameterField2(T2 current);
        protected abstract T3 DrawParameterField3(T3 current);

        private void OnEnable() => eventBus = target as EventBus<T1, T2, T3>;
        
        public override void OnInspectorGUI()
        {
            var list = eventBus.onSend?.GetInvocationList();
            
            EventExtensions.InvocationList(list);
            InvokeButton();
            ResetButton();
        }
        
        private void InvokeButton()
        {
            param1 = DrawParameterField1(param1);
            param2 = DrawParameterField2(param2);
            param3 = DrawParameterField3(param3);
            
            if (!GUILayout.Button("Invoke")) return;
            
            eventBus.onSend?.Invoke(param1, param2, param3);
        }

        private void ResetButton()
        {
            if (!GUILayout.Button("Reset")) return;

            eventBus.onSend = null;
        }
    }
}