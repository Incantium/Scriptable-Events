using UnityEditor;

namespace Incantium.Events.Editor
{
    /// <summary>
    /// Class representing the Unity Editor inspector for <see cref="BooleanEventTruck"/>.
    /// </summary>
    [CustomEditor(typeof(BooleanEventTruck))]
    internal sealed class BooleanEventTruckEditor : EventTruckEditor<bool> {}
}