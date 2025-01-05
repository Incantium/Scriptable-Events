using UnityEngine;

namespace Incantium.Events
{
    /// <summary>
    /// Class for a <see cref="bool"/> sending event. Send messages to all connected objects without needing a direct
    /// dependency.
    /// </summary>
    /// <seealso href="https://github.com/Incantium/Scriptable-Event/blob/main/API~/EventBus.md">EventBus</seealso>
    [CreateAssetMenu(menuName = "Events/Send/Boolean", order = 1)]
    public sealed class BooleanEventBus : EventBus<bool> {}
}