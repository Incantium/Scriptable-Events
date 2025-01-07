using UnityEngine;

namespace Incantium.Events.Send
{
    /// <summary>
    /// Class for a <see cref="double"/> sending event. Send messages to all connected objects without needing a direct
    /// dependency.
    /// </summary>
    /// <seealso href="https://github.com/Incantium/Scriptable-Event/blob/main/API~/EventBus.md">EventBus</seealso>
    [CreateAssetMenu(menuName = "Events/Send/Double", order = 4)]
    public sealed class DoubleEventBus : EventBus<double> {}
}