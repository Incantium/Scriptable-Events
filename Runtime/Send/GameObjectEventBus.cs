using UnityEngine;

namespace Incantium.Events.Send
{
    /// <summary>
    /// Class for a <see cref="GameObject"/> sending event. Send messages to all connected objects without needing a
    /// direct dependency.
    /// </summary>
    /// <seealso href="https://github.com/Incantium/Scriptable-Event/blob/main/API~/EventBus.md">EventBus</seealso>
    [CreateAssetMenu(menuName = "Events/Send/GameObject", order = 8)]
    public sealed class GameObjectEventBus : EventBus<float> {}
}