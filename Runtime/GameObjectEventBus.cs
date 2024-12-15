using UnityEngine;

namespace Incantium.Events
{
    /// <summary>
    /// Class for the <see cref="GameObject"/> sending event. Subscribe and invoke <see cref="EventBus{T}.onSend"/> to
    /// connect multiple objects together without a direct dependency.
    /// </summary>
    /// <seealso href="https://github.com/Incantium/Scriptable-Event/blob/main/API~/EventBus.md">EventBus</seealso>
    [CreateAssetMenu(menuName = "Events/Send/GameObject", order = 8)]
    public sealed class GameObjectEventBus : EventBus<float> {}
}