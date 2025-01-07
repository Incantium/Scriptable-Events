using Incantium.Events.Request;
using UnityEditor;

namespace Incantium.Events.Editor.Request
{
    /// <summary>
    /// Class representing the Unity Editor inspector for <see cref="IntegerEventTruck"/>.
    /// </summary>
    [CustomEditor(typeof(IntegerEventTruck))]
    internal sealed class IntegerEventTruckEditor : EventTruckEditor<int> {}
}