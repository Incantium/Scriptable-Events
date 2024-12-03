using UnityEditor;
using UnityEngine;

namespace Incantium.Events.Editor
{
    /// <summary>
    /// Class representing the Unity Editor inspector for <see cref="Vector3EventTruck"/>.
    /// </summary>
    [CustomEditor(typeof(Vector3EventTruck))]
    internal sealed class Vector3EventTruckEditor : EventTruckEditor<Vector3> {}
}