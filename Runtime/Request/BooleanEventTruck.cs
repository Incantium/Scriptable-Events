using UnityEngine;

namespace Incantium.Events.Request
{
    /// <summary>
    /// Class for a <see cref="bool"/> requesting event. Request messages to a connected object without needing a direct
    /// dependency.
    /// </summary>
    /// <seealso href="https://github.com/Incantium/Scriptable-Event/blob/main/API~/EventTruck.md">EventTruck</seealso>
    [CreateAssetMenu(menuName = "Events/Request/Boolean", order = 1)]
    public sealed class BooleanEventTruck : EventTruck<bool> {}
}