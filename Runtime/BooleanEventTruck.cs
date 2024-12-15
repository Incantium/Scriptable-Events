using UnityEngine;

namespace Incantium.Events
{
    /// <summary>
    /// Class for the <see cref="bool"/> request event. Subscribe and invoke <see cref="EventTruck{T}.onRequest"/> to
    /// connect multiple objects together without a direct dependency.
    /// </summary>
    /// <seealso href="https://github.com/Incantium/Scriptable-Event/blob/main/API~/EventTruck.md">EventTruck</seealso>
    [CreateAssetMenu(menuName = "Events/Request/Boolean", order = 4)]
    public sealed class BooleanEventTruck : EventTruck<bool> {}
}