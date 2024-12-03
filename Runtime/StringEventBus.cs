using UnityEngine;

namespace Incantium.Events
{
    /// <summary>
    /// Class for the <see cref="string"/> sending event. Subscribe and invoke <see cref="EventBus{T}.onSend"/> to
    /// connect multiple objects together without a direct dependency.
    /// </summary>
    /// <seealso href="https://github.com/Incantium/Scriptable-Event/blob/main/Documentation~/EventBus.md">EventBus
    /// </seealso>
    [CreateAssetMenu(menuName = "Events/Send/String", order = 5)]
    public sealed class StringEventBus : EventBus<string> {}
}