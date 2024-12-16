using UnityEngine;

namespace Incantium.Events
{
    /// <summary>
    /// Class for the <see cref="double"/> sending event. Subscribe and invoke <see cref="EventBus{T}.onSend"/> to connect
    /// multiple objects together without a direct dependency.
    /// </summary>
    /// <seealso href="https://github.com/Incantium/Scriptable-Event/blob/main/API~/EventBus.md">EventBus</seealso>
    [CreateAssetMenu(menuName = "Events/Send/Double", order = 4)]
    public sealed class DoubleEventBus : EventBus<double> {}
}