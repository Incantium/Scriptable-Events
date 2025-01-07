using UnityEngine;

namespace Incantium.Events.Request
{
    /// <summary>
    /// Class for a <see cref="Vector2"/> requesting event. Request messages to a connected object without needing a
    /// direct dependency.
    /// </summary>
    /// <seealso href="https://github.com/Incantium/Scriptable-Event/blob/main/API~/EventTruck.md">EventTruck</seealso>
    [CreateAssetMenu(menuName = "Events/Request/Vector2", order = 6)]
    public sealed class Vector2EventTruck : EventTruck<Vector2> {}
}