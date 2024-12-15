using UnityEngine;

namespace Incantium.Events
{
    /// <summary>
    /// Class for the <see cref="float"/> request event. Subscribe and invoke <see cref="EventTruck{T}.onRequest"/> to
    /// connect multiple objects together without a direct dependency.
    /// </summary>
    /// <seealso href="https://github.com/Incantium/Scriptable-Event/blob/main/API~/EventTruck.md">EventTruck</seealso>
    [CreateAssetMenu(menuName = "Events/Request/Float", order = 3)]
    public sealed class FloatEventTruck : EventTruck<float> {}
}