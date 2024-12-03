using UnityEditor;
using UnityEngine;

namespace Incantium.Events.Editor
{
    /// <summary>
    /// Class representing the Unity Editor inspector for <see cref="Vector2EventTruck"/>.
    /// </summary>
    [CustomEditor(typeof(Vector2EventTruck))]
    internal sealed class Vector2EventTruckEditor : EventTruckEditor<Vector2> {}
}