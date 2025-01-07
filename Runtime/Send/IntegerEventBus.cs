using UnityEngine;

namespace Incantium.Events.Send
{
    /// <summary>
    /// Class for a <see cref="int"/> sending event. Send messages to all connected objects without needing a direct
    /// dependency.
    /// </summary>
    /// <seealso href="https://github.com/Incantium/Scriptable-Event/blob/main/API~/EventBus.md">EventBus</seealso>
    [CreateAssetMenu(menuName = "Events/Send/Integer", order = 2)]
    public sealed class IntegerEventBus : EventBus<int> {}
}