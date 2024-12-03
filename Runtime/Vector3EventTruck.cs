using UnityEngine;

namespace Incantium.Events
{
    /// <summary>
    /// Class for the <see cref="Vector3"/> request event. Subscribe and invoke <see cref="EventTruck{T}.onRequest"/> to
    /// connect multiple objects together without a direct dependency.
    /// </summary>
    /// <seealso href="https://github.com/Incantium/Scriptable-Event/blob/main/Documentation~/EventTruck.md">EventTruck
    /// </seealso>
    [CreateAssetMenu(menuName = "Events/Request/Vector3", order = 7)]
    public sealed class Vector3EventTruck : EventTruck<Vector3> {}
}