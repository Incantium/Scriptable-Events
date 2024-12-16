using System;
using UnityEngine;

namespace Incantium.Events 
{
    /// <summary>
    /// Class for a requesting event. Request messages to a connected object without needing a direct dependency.
    /// </summary>
    /// <typeparam name="TResult">The return typing.</typeparam>
    /// <seealso href="https://github.com/Incantium/Scriptable-Event/blob/main/API~/EventTruck.md">EventTruck</seealso>
    public abstract class EventTruck<TResult> : ScriptableObject
    {
        /// <summary>
        /// Event, when subscribed to, will be notified when something else <see cref="Request"/> an answer.
        /// </summary>
        public event Func<TResult> onRespond;

        /// <inheritdoc cref="EventBus.count"/>
        public int count => onRespond != null ? onRespond.GetInvocationList().Length : 0;

        /// <inheritdoc cref="EventBus.action"/>
        internal Func<TResult> action => onRespond;

        /// <summary>
        /// Method to call a method subscribed to <see cref="onRespond"/> for an answer.
        /// </summary>
        /// <returns>The answer from the first connected object if possible.</returns>
        public TResult Request() => onRespond != null ? onRespond() : default;

        /// <inheritdoc cref="EventBus.Reset"/>
        public void Reset() => onRespond = null;
    }
    
    /// <summary>
    /// Class for a request event bus with one parameter. Request messages to a connected object without needing a
    /// direct dependency.
    /// </summary>
    /// <typeparam name="T">The parameter typing.</typeparam>
    /// <typeparam name="TResult">The return typing.</typeparam>
    /// <seealso href="https://github.com/Incantium/Scriptable-Event/blob/main/API~/EventTruck.md">EventTruck</seealso>
    public abstract class EventTruck<T, TResult> : ScriptableObject
    {
        /// <inheritdoc cref="EventTruck{TResult}.onRespond"/>
        public event Func<T, TResult> onRespond;

        /// <inheritdoc cref="EventBus.count"/>
        public int count => onRespond != null ? onRespond.GetInvocationList().Length : 0;

        /// <inheritdoc cref="EventBus.action"/>
        internal Func<T, TResult> action => onRespond;

        /// <inheritdoc cref="EventTruck{TResult}.Request"/>
        /// <summary>
        /// Method to call a method subscribed to <see cref="onRespond"/> for an answer.
        /// </summary>
        /// <param name="message">The message to send with the event.</param>
        public TResult Request(T message) => onRespond != null ? onRespond(message) : default;

        /// <inheritdoc cref="EventBus.Reset"/>
        public void Reset() => onRespond = null;
    }
    
    /// <summary>
    /// Class for a request event bus with two parameters. Request messages to a connected object without needing a
    /// direct dependency.
    /// </summary>
    /// <typeparam name="T1">The first parameter typing.</typeparam>
    /// <typeparam name="T2">The second parameter typing.</typeparam>
    /// <typeparam name="TResult">The return typing.</typeparam>
    /// <seealso href="https://github.com/Incantium/Scriptable-Event/blob/main/API~/EventTruck.md">EventTruck</seealso>
    public abstract class EventTruck<T1, T2, TResult> : ScriptableObject
    {
        /// <inheritdoc cref="EventTruck{TResult}.onRespond"/>
        public event Func<T1, T2, TResult> onRespond;

        /// <inheritdoc cref="EventBus.count"/>
        public int count => onRespond != null ? onRespond.GetInvocationList().Length : 0;

        /// <inheritdoc cref="EventBus.action"/>
        internal Func<T1, T2, TResult> action => onRespond;

        /// <inheritdoc cref="EventTruck{TResult}.Request"/>
        /// <param name="a">The first message to send with the event.</param>
        /// <param name="b">The second message to send with the event.</param>
        public TResult Request(T1 a, T2 b) => onRespond != null ? onRespond(a, b) : default;

        /// <inheritdoc cref="EventBus.Reset"/>
        public void Reset() => onRespond = null;
    }
}