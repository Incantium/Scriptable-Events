using UnityEditor;
using UnityEngine;

namespace Incantium.Events.Editor
{
    public abstract class EventTruckEditor<T> : UnityEditor.Editor
    {
        private EventTruck<T> eventTruck;

        private void OnEnable() =>  eventTruck = target as EventTruck<T>;

        public override void OnInspectorGUI()
        {
            var list = eventTruck.onRequest?.GetInvocationList();
            
            EventExtensions.InvocationList(list);
            InvokeButton();
            ResetButton();
        }

        private void InvokeButton()
        {
            if (!ButtonPressed("Request") || eventTruck.onRequest == null) return;

            var result = eventTruck.onRequest.Invoke();
            
            Debug.Log(result);
        }
        
        private void ResetButton()
        {
            if (!ButtonPressed("Reset")) return;

            eventTruck.onRequest = null;
        }

        private bool ButtonPressed(string text)
        {
            GUI.enabled = Application.isPlaying && eventTruck.onRequest != null;
            var pressed = GUILayout.Button(text);
            GUI.enabled = true;
            
            return pressed;
        }
    }
    
    public abstract class EventTruckEditor<T, TResult> : UnityEditor.Editor
    {
        private EventTruck<T, TResult> eventTruck;
        private T param;
        
        /// <summary>
        /// Method to draw the property field of the parameter in this event bus.
        /// </summary>
        /// <param name="current">The saved parameter value.</param>
        /// <returns>The set parameter value.</returns>
        /// <remarks>Solely use <see cref="EditorGUILayout"/> to draw the property field.</remarks>
        protected abstract T DrawParameterField(T current);

        private void OnEnable() =>  eventTruck = target as EventTruck<T, TResult>;

        public override void OnInspectorGUI()
        {
            var list = eventTruck.onRequest?.GetInvocationList();
            
            EventExtensions.InvocationList(list);
            InvokeButton();
            ResetButton();
        }

        private void InvokeButton()
        {
            EditorGUILayout.BeginHorizontal();
            
            GUI.enabled = Application.isPlaying && eventTruck.onRequest != null;
            var pressed = GUILayout.Button("Request");
            
            param = DrawParameterField(param);
            GUI.enabled = true;
            
            EditorGUILayout.EndHorizontal();
            
            if (!pressed || eventTruck.onRequest == null) return;
            
            var result = eventTruck.onRequest.Invoke(param);
            
            Debug.Log(result);
        }
        
        private void ResetButton()
        {
            if (!ButtonPressed("Reset")) return;

            eventTruck.onRequest = null;
        }

        private bool ButtonPressed(string text)
        {
            GUI.enabled = Application.isPlaying && eventTruck.onRequest != null;
            var pressed = GUILayout.Button(text);
            GUI.enabled = true;
            
            return pressed;
        }
    }
    
    public abstract class EventTruckEditor<T1, T2, TResult> : UnityEditor.Editor
    {
        private EventTruck<T1, T2, TResult> eventTruck;
        private T1 param1;
        private T2 param2;
        
        protected abstract T1 DrawParameterField1(T1 current);
        
        protected abstract T2 DrawParameterField2(T2 current);
        
        private void OnEnable() =>  eventTruck = target as EventTruck<T1, T2, TResult>;

        public override void OnInspectorGUI()
        {
            var list = eventTruck.onRequest?.GetInvocationList();
            
            EventExtensions.InvocationList(list);
            InvokeButton();
            ResetButton();
        }

        private void InvokeButton()
        {
            EditorGUILayout.BeginHorizontal();
            
            GUI.enabled = Application.isPlaying && eventTruck.onRequest != null;
            var pressed = GUILayout.Button("Request");
            
            param1 = DrawParameterField1(param1);
            param2 = DrawParameterField2(param2);
            
            GUI.enabled = true;
            
            EditorGUILayout.EndHorizontal();
            
            if (!pressed || eventTruck.onRequest == null) return;
            
            var result = eventTruck.onRequest.Invoke(param1, param2);
            
            Debug.Log(result);
        }
        
        private void ResetButton()
        {
            if (!ButtonPressed("Reset")) return;

            eventTruck.onRequest = null;
        }

        private bool ButtonPressed(string text)
        {
            GUI.enabled = Application.isPlaying && eventTruck.onRequest != null;
            var pressed = GUILayout.Button(text);
            GUI.enabled = true;
            
            return pressed;
        }
    }
}