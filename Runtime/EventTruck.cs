using System;
using UnityEngine;

namespace Incantium.Events 
{
    /// <summary>
    /// Class for a requesting event. Subscribe and invoke <see cref="onRequest"/> to connect multiple objects together
    /// without a direct dependency.
    /// </summary>
    /// <typeparam name="TResult">The return typing.</typeparam>
    /// <seealso href="https://github.com/Incantium/Scriptable-Event/blob/main/API~/EventTruck.md">EventTruck</seealso>
    public abstract class EventTruck<TResult> : ScriptableObject
    {
        /// <inheritdoc cref="EventBus.onSend"/>
        public Func<TResult> onRequest;
    }
    
    /// <summary>
    /// Class for a request event bus with one parameter. Subscribe and invoke <see cref="onRequest"/> to connect
    /// multiple objects together without a direct dependency.
    /// </summary>
    /// <typeparam name="T">The parameter typing.</typeparam>
    /// <typeparam name="TResult">The return typing.</typeparam>
    /// <seealso href="https://github.com/Incantium/Scriptable-Event/blob/main/API~/EventTruck.md">EventTruck</seealso>
    public abstract class EventTruck<T, TResult> : ScriptableObject
    {
        /// <inheritdoc cref="EventBus.onSend"/>
        public Func<T, TResult> onRequest;
    }
    
    /// <summary>
    /// Class for a request event bus with two parameters. Subscribe and invoke <see cref="onRequest"/> to connect
    /// multiple objects together without a direct dependency.
    /// </summary>
    /// <typeparam name="T1">The first parameter typing.</typeparam>
    /// <typeparam name="T2">The second parameter typing.</typeparam>
    /// <typeparam name="TResult">The return typing.</typeparam>
    /// <seealso href="https://github.com/Incantium/Scriptable-Event/blob/main/API~/EventTruck.md">EventTruck</seealso>
    public abstract class EventTruck<T1, T2, TResult> : ScriptableObject
    {
        /// <inheritdoc cref="EventBus.onSend"/>
        public Func<T1, T2, TResult> onRequest;
    }
}