using Incantium.Events.Request;
using UnityEditor;

namespace Incantium.Events.Editor.Request
{
    /// <summary>
    /// Class representing the Unity Editor inspector for <see cref="DoubleEventTruck"/>.
    /// </summary>
    [CustomEditor(typeof(DoubleEventTruck))]
    internal sealed class DoubleEventTruckEditor : EventTruckEditor<double> {}
}