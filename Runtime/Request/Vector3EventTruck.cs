using UnityEngine;

namespace Incantium.Events.Request
{
    /// <summary>
    /// Class for a <see cref="Vector3"/> requesting event. Request messages to a connected object without needing a
    /// direct dependency.
    /// </summary>
    /// <seealso href="https://github.com/Incantium/Scriptable-Event/blob/main/API~/EventTruck.md">EventTruck</seealso>
    [CreateAssetMenu(menuName = "Events/Request/Vector3", order = 7)]
    public sealed class Vector3EventTruck : EventTruck<Vector3> {}
}