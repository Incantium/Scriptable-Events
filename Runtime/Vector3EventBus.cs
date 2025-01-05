using UnityEngine;

namespace Incantium.Events
{
    /// <summary>
    /// Class for a <see cref="Vector3"/> sending event. Send messages to all connected objects without needing a direct
    /// dependency.
    /// </summary>
    /// <seealso href="https://github.com/Incantium/Scriptable-Event/blob/main/API~/EventBus.md">EventBus</seealso>
    [CreateAssetMenu(menuName = "Events/Send/Vector3", order = 7)]
    public sealed class Vector3EventBus : EventBus<Vector3> {}
}