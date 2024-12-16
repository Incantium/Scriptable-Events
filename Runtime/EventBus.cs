using System;
using UnityEngine;

namespace Incantium.Events 
{
    /// <summary>
    /// Class for a default sending event. Send messages to all connected objects without needing a direct dependency.
    /// </summary>
    /// <seealso href="https://github.com/Incantium/Scriptable-Event/blob/main/API~/EventBus.md">EventBus</seealso>
    [CreateAssetMenu(menuName = "Events/Send/Default", order = 0)]
    public sealed class EventBus : ScriptableObject
    {
        /// <summary>
        /// Event, when subscribed to, will be notified when something else <see cref="Send"/> a message.
        /// </summary>
        public event Action onReceive;

        /// <summary>
        /// Amount of event handlers connected to this event.
        /// </summary>
        public int count => onReceive != null ? onReceive.GetInvocationList().Length : 0;

        /// <summary>
        /// The delegate of the event.
        /// </summary>
        internal Action action => onReceive;

        /// <summary>
        /// Method to call all methods subscribed to <see cref="onReceive"/> to deliver a message.
        /// </summary>
        public void Send() => onReceive?.Invoke();

        /// <summary>
        /// Method to remove all methods from this event.
        /// </summary>
        public void Reset() => onReceive = null;
    }
    
    /// <summary>
    /// Class for a single typed sending event. Send messages to all connected objects without needing a direct
    /// dependency.
    /// </summary>
    /// <typeparam name="T">The first parameter typing.</typeparam>
    /// <seealso href="https://github.com/Incantium/Scriptable-Event/blob/main/API~/EventBus.md">EventBus</seealso>
    public abstract class EventBus<T> : ScriptableObject
    {
        /// <inheritdoc cref="EventBus.onReceive"/>
        public event Action<T> onReceive;

        /// <inheritdoc cref="EventBus.count"/>
        public int count => onReceive != null ? onReceive.GetInvocationList().Length : 0;

        /// <inheritdoc cref="EventBus.action"/>
        internal Action<T> action => onReceive;

        /// <inheritdoc cref="EventBus.Send"/>
        /// <param name="message">The message to send with the event.</param>
        public void Send(T message) => onReceive?.Invoke(message);
        
        /// <inheritdoc cref="EventBus.Reset"/>
        public void Reset() => onReceive = null;
    }
    
    /// <summary>
    /// Class for a dual typed sending event. Send messages to all connected objects without needing a direct
    /// dependency.
    /// </summary>
    /// <typeparam name="T1">The first parameter typing.</typeparam>
    /// <typeparam name="T2">The second parameter typing.</typeparam>
    /// <seealso href="https://github.com/Incantium/Scriptable-Event/blob/main/API~/EventBus.md">EventBus</seealso>
    public abstract class EventBus<T1, T2> : ScriptableObject
    {
        /// <inheritdoc cref="EventBus.onReceive"/>
        public event Action<T1, T2> onReceive;

        /// <inheritdoc cref="EventBus.count"/>
        public int count => onReceive != null ? onReceive.GetInvocationList().Length : 0;

        /// <inheritdoc cref="EventBus.action"/>
        internal Action<T1, T2> action => onReceive;
        
        /// <inheritdoc cref="EventBus.Send"/>
        /// <param name="a">The first message to send with the event.</param>
        /// <param name="b">The second message to send with the event.</param>
        public void Send(T1 a, T2 b) => onReceive?.Invoke(a, b);
        
        /// <inheritdoc cref="EventBus.Reset"/>
        public void Reset() => onReceive = null;
    }
    
    /// <summary>
    /// Class for a triple typed sending event. Send messages to all connected objects without needing a direct
    /// dependency.
    /// </summary>
    /// <typeparam name="T1">The first parameter typing.</typeparam>
    /// <typeparam name="T2">The second parameter typing.</typeparam>
    /// <typeparam name="T3">The third parameter typing.</typeparam>
    /// <seealso href="https://github.com/Incantium/Scriptable-Event/blob/main/API~/EventBus.md">EventBus</seealso>
    public abstract class EventBus<T1, T2, T3> : ScriptableObject
    {
        /// <inheritdoc cref="EventBus.onReceive"/>
        public event Action<T1, T2, T3> onReceive;

        /// <inheritdoc cref="EventBus.count"/>
        public int count => onReceive != null ? onReceive.GetInvocationList().Length : 0;

        /// <inheritdoc cref="EventBus.action"/>
        internal Action<T1, T2, T3> action => onReceive;

        /// <inheritdoc cref="EventBus.Send"/>
        /// <param name="a">The first message to send with the event.</param>
        /// <param name="b">The second message to send with the event.</param>
        /// <param name="c">The third message to send with the event.</param>
        public void Send(T1 a, T2 b, T3 c) => onReceive?.Invoke(a, b, c);
        
        /// <inheritdoc cref="EventBus.Reset"/>
        public void Reset() => onReceive = null;
    }
}