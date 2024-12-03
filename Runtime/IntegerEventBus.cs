using UnityEngine;

namespace Incantium.Events
{
    /// <summary>
    /// Class for the <see cref="int"/> sending event. Subscribe and invoke <see cref="EventBus{T}.onSend"/> to connect
    /// multiple objects together without a direct dependency.
    /// </summary>
    /// <seealso href="https://github.com/Incantium/Scriptable-Event/blob/main/Documentation~/EventBus.md">EventBus
    /// </seealso>
    [CreateAssetMenu(menuName = "Events/Send/Integer", order = 2)]
    public sealed class IntegerEventBus : EventBus<int> {}
}