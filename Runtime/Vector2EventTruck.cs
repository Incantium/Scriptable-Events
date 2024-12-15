using UnityEngine;

namespace Incantium.Events
{
    /// <summary>
    /// Class for the <see cref="Vector2"/> request event. Subscribe and invoke <see cref="EventTruck{T}.onRequest"/> to
    /// connect multiple objects together without a direct dependency.
    /// </summary>
    /// <seealso href="https://github.com/Incantium/Scriptable-Event/blob/main/API~/EventTruck.md">EventTruck</seealso>
    [CreateAssetMenu(menuName = "Events/Request/Vector2", order = 6)]
    public sealed class Vector2EventTruck : EventTruck<Vector2> {}
}