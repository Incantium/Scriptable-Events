using UnityEngine;

namespace Incantium.Events
{
    /// <summary>
    /// Class for a <see cref="double"/> requesting event. Request messages to a connected object without needing a direct
    /// dependency.
    /// </summary>
    /// <seealso href="https://github.com/Incantium/Scriptable-Event/blob/main/API~/EventTruck.md">EventTruck</seealso>
    [CreateAssetMenu(menuName = "Events/Request/Double", order = 4)]
    public sealed class DoubleEventTruck : EventTruck<double> {}
}