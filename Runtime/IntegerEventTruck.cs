using UnityEngine;

namespace Incantium.Events
{
    /// <summary>
    /// Class for the <see cref="int"/> request event. Subscribe and invoke <see cref="EventTruck{T}.onRequest"/> to
    /// connect multiple objects together without a direct dependency.
    /// </summary>
    /// <seealso href="https://github.com/Incantium/Scriptable-Event/blob/main/Documentation~/EventTruck.md">EventTruck
    /// </seealso>
    [CreateAssetMenu(menuName = "Events/Request/Integer", order = 2)]
    public sealed class IntegerEventTruck : EventTruck<int> {}
}