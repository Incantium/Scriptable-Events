using UnityEditor;

namespace Incantium.Events.Editor
{
    /// <summary>
    /// Class representing the Unity Editor inspector for <see cref="DoubleEventTruck"/>.
    /// </summary>
    [CustomEditor(typeof(DoubleEventTruck))]
    internal sealed class DoubleEventTruckEditor : EventTruckEditor<double> {}
}