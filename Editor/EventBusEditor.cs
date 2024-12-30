using UnityEditor;
using UnityEngine;

namespace Incantium.Events.Editor
{
    /// <summary>
    /// Class representing the Unity Editor inspector for the default <see cref="EventBus"/> implementation.
    /// </summary>
    [CustomEditor(typeof(EventBus))]
    internal sealed class EventBusEditor : UnityEditor.Editor
    {
        /// <summary>
        /// The scriptable event.
        /// </summary>
        private EventBus eventBus;
        
        /// <summary>
        /// True if the Unity Editor is in play mode and there are methods connected to the event, otherwise false.
        /// </summary>
        private bool active => eventBus.count > 0;

        /// <summary>
        /// Method called when the event scriptable object comes into focus. This will save the correct event for later
        /// usage.
        /// </summary>
        private void OnEnable() => eventBus = target as EventBus;
        
        /// <summary>
        /// Method called to draw the inspector for this scriptable event. This method will do the following:
        /// <ul>
        ///     <li>Firstly, it will draw the methods connected to the scriptable event.</li>
        ///     <li>Secondly, it will draw an invoke button to invoke the scriptable event from the
        ///     <see cref="ScriptableObject"/>.</li>
        ///     <li>Thirdly, it will draw a reset button to remove all methods from the scriptable event from the
        ///     <see cref="ScriptableObject"/>.</li>
        /// </ul>
        /// </summary>
        public override void OnInspectorGUI()
        {
            EventExtensions.DrawInvocationList(eventBus.action);
            InvokeButton();
            ResetButton();
        }
        
        /// <summary>
        /// Method to draw the invoke button alongside additional parameter fields if necessary. When the scriptable
        /// event is in use, the user can click to invoke the event from the <see cref="ScriptableObject"/>.
        /// </summary>
        private void InvokeButton()
        {
            EditorGUI.BeginDisabledGroup(!active);
            var pressed = GUILayout.Button(Styles.SEND);
            EditorGUI.EndDisabledGroup();
            
            if (!pressed) return;
            
            eventBus.Send();
        }

        /// <summary>
        /// Method to draw the reset button within the Unity Editor. When the scriptable event is in use, the user can
        /// click from the <see cref="ScriptableObject"/> to remove all methods connected to the event.
        /// </summary>
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
    /// Class representing the Unity Editor inspector for the default <see cref="EventBus{T}"/> implementation.
    /// </summary>
    /// <typeparam name="T">The first parameter typing.</typeparam>
    public abstract class EventBusEditor<T> : UnityEditor.Editor
    {
        /// <inheritdoc cref="EventBusEditor.eventBus"/>
        private EventBus<T> eventBus;
        
        /// <summary>
        /// A temporary field to store data used for invoking the scriptable event.
        /// </summary>
        private T parameter;
        
        /// <inheritdoc cref="EventBusEditor.active"/>
        private bool active => eventBus.count > 0;

        /// <summary>
        /// Method to draw the property field of the parameter.
        /// </summary>
        /// <param name="current">The saved parameter value.</param>
        /// <returns>The set parameter value.</returns>
        /// <remarks>Solely use <see cref="EditorGUILayout"/> to draw the property field.</remarks>
        protected abstract T DrawParameterField(T current);

        /// <inheritdoc cref="EventBusEditor.OnEnable"/>
        private void OnEnable() => eventBus = target as EventBus<T>;
        
        /// <inheritdoc cref="EventBusEditor.OnInspectorGUI"/>
        public override void OnInspectorGUI()
        {
            EventExtensions.DrawInvocationList(eventBus.action);
            InvokeButton();
            ResetButton();
        }
        
        /// <inheritdoc cref="EventBusEditor.InvokeButton"/>
        private void InvokeButton()
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUI.BeginDisabledGroup(!active);
            
            var pressed = GUILayout.Button(Styles.SEND);
            
            parameter = DrawParameterField(parameter);
            
            EditorGUI.EndDisabledGroup();
            EditorGUILayout.EndHorizontal();
            
            if (!pressed) return;
            
            eventBus.Send(parameter);
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
    /// Class representing the Unity Editor inspector for the default <see cref="EventBus{T,T}"/> implementation.
    /// </summary>
    /// <typeparam name="T1">The first parameter typing.</typeparam>
    /// <typeparam name="T2">The second parameter typing.</typeparam>
    public abstract class EventBusEditor<T1, T2> : UnityEditor.Editor
    {
        /// <inheritdoc cref="EventBusEditor.eventBus"/>
        private EventBus<T1, T2> eventBus;
        
        /// <inheritdoc cref="EventBusEditor{T}.parameter"/>
        private T1 param1;
        
        /// <inheritdoc cref="EventBusEditor{T}.parameter"/>
        private T2 param2;
        
        /// <inheritdoc cref="EventBusEditor.active"/>
        private bool active => eventBus.count > 0;

        /// <inheritdoc cref="EventBusEditor{T}.DrawParameterField"/>
        protected abstract T1 DrawParameterField1(T1 current);
        
        /// <inheritdoc cref="EventBusEditor{T}.DrawParameterField"/>
        protected abstract T2 DrawParameterField2(T2 current);

        /// <inheritdoc cref="EventBusEditor.OnEnable"/>
        private void OnEnable() => eventBus = target as EventBus<T1, T2>;
        
        /// <inheritdoc cref="EventBusEditor.OnInspectorGUI"/>
        public override void OnInspectorGUI()
        {
            EventExtensions.DrawInvocationList(eventBus.action);
            InvokeButton();
            ResetButton();
        }
        
        /// <inheritdoc cref="EventBusEditor.InvokeButton"/>
        private void InvokeButton()
        {
            EditorGUI.BeginDisabledGroup(!active);
            
            var pressed = GUILayout.Button(Styles.SEND);
            
            param1 = DrawParameterField1(param1);
            param2 = DrawParameterField2(param2);
            
            EditorGUI.EndDisabledGroup();
            
            if (!pressed) return;
            
            eventBus.Send(param1, param2);
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
    /// Class representing the Unity Editor inspector for the default <see cref="EventBus{T,T,T}"/> implementation.
    /// </summary>
    /// <typeparam name="T1">The first parameter typing.</typeparam>
    /// <typeparam name="T2">The second parameter typing.</typeparam>
    /// <typeparam name="T3">The third parameter typing.</typeparam>
    public abstract class EventBusEditor<T1, T2, T3> : UnityEditor.Editor
    {
        /// <inheritdoc cref="EventBusEditor.eventBus"/>
        private EventBus<T1, T2, T3> eventBus;
        
        /// <inheritdoc cref="EventBusEditor{T}.parameter"/>
        private T1 param1;
        
        /// <inheritdoc cref="EventBusEditor{T}.parameter"/>
        private T2 param2;
        
        /// <inheritdoc cref="EventBusEditor{T}.parameter"/>
        private T3 param3;
        
        /// <inheritdoc cref="EventBusEditor.active"/>
        private bool active => eventBus.count > 0;

        /// <inheritdoc cref="EventBusEditor{T}.DrawParameterField"/>
        protected abstract T1 DrawParameterField1(T1 current);
        
        /// <inheritdoc cref="EventBusEditor{T}.DrawParameterField"/>
        protected abstract T2 DrawParameterField2(T2 current);
        
        /// <inheritdoc cref="EventBusEditor{T}.DrawParameterField"/>
        protected abstract T3 DrawParameterField3(T3 current);

        /// <inheritdoc cref="EventBusEditor.OnEnable"/>
        private void OnEnable() => eventBus = target as EventBus<T1, T2, T3>;
        
        /// <inheritdoc cref="EventBusEditor.OnInspectorGUI"/>
        public override void OnInspectorGUI()
        {
            EventExtensions.DrawInvocationList(eventBus.action);
            InvokeButton();
            ResetButton();
        }
        
        /// <inheritdoc cref="EventBusEditor.InvokeButton"/>
        private void InvokeButton()
        {
            EditorGUI.BeginDisabledGroup(!active);
            
            var pressed = GUILayout.Button(Styles.SEND);
            
            param1 = DrawParameterField1(param1);
            param2 = DrawParameterField2(param2);
            param3 = DrawParameterField3(param3);
            
            EditorGUI.EndDisabledGroup();
            
            if (!pressed) return;
            
            eventBus.Send(param1, param2, param3);
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