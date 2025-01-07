using System;
using Incantium.Events.Send;
using UnityEngine;

namespace Incantium.Events.Request 
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
        /// <returns>The answer from the last connected object if possible.</returns>
        public TResult Request() => onRespond != null ? onRespond() : default;
        
        /// <summary>
        /// Method to call all methods subscribed to <see cref="onRespond"/> for an answer.
        /// </summary>
        /// <returns>An array of answers from each object.</returns>
        public TResult[] RequestAll()
        {
            var list = onRespond?.GetInvocationList();
            
            if (list == null) return Array.Empty<TResult>();
            
            var results = new TResult[list.Length];

            for (var i = 0; i < list.Length; i++)
            {
                if (list[i] is not Func<TResult> function) continue;
                
                results[i] = function.Invoke();
            }

            return results;
        }

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
        
        /// <inheritdoc cref="EventTruck{TResult}.RequestAll"/>
        /// <param name="message">The message to send with the event.</param>
        public TResult[] RequestAll(T message)
        {
            var list = onRespond?.GetInvocationList();
            
            if (list == null) return Array.Empty<TResult>();
            
            var results = new TResult[list.Length];

            for (var i = 0; i < list.Length; i++)
            {
                if (list[i] is not Func<T, TResult> function) continue;
                
                results[i] = function.Invoke(message);
            }

            return results;
        }

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
        
        /// <inheritdoc cref="EventTruck{TResult}.RequestAll"/>
        /// <param name="a">The first message to send with the event.</param>
        /// <param name="b">The second message to send with the event.</param>
        public TResult[] RequestAll(T1 a, T2 b)
        {
            var list = onRespond?.GetInvocationList();
            
            if (list == null) return Array.Empty<TResult>();
            
            var results = new TResult[list.Length];

            for (var i = 0; i < list.Length; i++)
            {
                if (list[i] is not Func<T1, T2, TResult> function) continue;
                
                results[i] = function.Invoke(a, b);
            }

            return results;
        }

        /// <inheritdoc cref="EventBus.Reset"/>
        public void Reset() => onRespond = null;
    }
}