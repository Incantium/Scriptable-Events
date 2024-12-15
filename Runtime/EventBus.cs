using System;
using UnityEngine;

namespace Incantium.Events 
{
    /// <summary>
    /// Class for a default sending event. Subscribe and invoke <see cref="onSend"/> to connect multiple objects
    /// together without a direct dependency.
    /// </summary>
    /// <seealso href="https://github.com/Incantium/Scriptable-Event/blob/main/API~/EventBus.md">EventBus</seealso>
    [CreateAssetMenu(menuName = "Events/Send/Default", order = 1)]
    public sealed class EventBus : ScriptableObject
    {
        /// <summary>
        /// Event to be subscribed and invoked.
        /// </summary>
        public Action onSend;
    }
    
    /// <summary>
    /// Class for a single typed sending event. Subscribe and invoke <see cref="onSend"/> to connect multiple objects
    /// together without a direct dependency.
    /// </summary>
    /// <typeparam name="T">The first parameter typing.</typeparam>
    /// <seealso href="https://github.com/Incantium/Scriptable-Event/blob/main/API~/EventBus.md">EventBus</seealso>
    public abstract class EventBus<T> : ScriptableObject
    {
        /// <inheritdoc cref="EventBus.onSend"/>
        public Action<T> onSend;
    }
    
    /// <summary>
    /// Class for a dual typed sending event. Subscribe and invoke <see cref="onSend"/> to connect multiple objects
    /// together without a direct dependency.
    /// </summary>
    /// <typeparam name="T1">The first parameter typing.</typeparam>
    /// <typeparam name="T2">The second parameter typing.</typeparam>
    /// <seealso href="https://github.com/Incantium/Scriptable-Event/blob/main/API~/EventBus.md">EventBus</seealso>
    public abstract class EventBus<T1, T2> : ScriptableObject
    {
        /// <inheritdoc cref="EventBus.onSend"/>
        public Action<T1, T2> onSend;
    }
    
    /// <summary>
    /// Class for a triple typed sending event. Subscribe and invoke <see cref="onSend"/> to connect multiple objects
    /// together without a direct dependency.
    /// </summary>
    /// <typeparam name="T1">The first parameter typing.</typeparam>
    /// <typeparam name="T2">The second parameter typing.</typeparam>
    /// <typeparam name="T3">The third parameter typing.</typeparam>
    /// <seealso href="https://github.com/Incantium/Scriptable-Event/blob/main/API~/EventBus.md">EventBus</seealso>
    public abstract class EventBus<T1, T2, T3> : ScriptableObject
    {
        /// <inheritdoc cref="EventBus.onSend"/>
        public Action<T1, T2, T3> onSend;
    }
}