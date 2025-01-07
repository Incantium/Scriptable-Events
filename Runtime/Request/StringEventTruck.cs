using UnityEngine;

namespace Incantium.Events.Request
{
    /// <summary>
    /// Class for a <see cref="string"/> requesting event. Request messages to a connected object without needing a
    /// direct dependency.
    /// </summary>
    /// <seealso href="https://github.com/Incantium/Scriptable-Event/blob/main/API~/EventTruck.md">EventTruck</seealso>
    [CreateAssetMenu(menuName = "Events/Request/String", order = 5)]
    public sealed class StringEventTruck : EventTruck<string> {}
}