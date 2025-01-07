using Incantium.Events.Request;
using UnityEditor;

namespace Incantium.Events.Editor.Request
{
    /// <summary>
    /// Class representing the Unity Editor inspector for <see cref="BooleanEventTruck"/>.
    /// </summary>
    [CustomEditor(typeof(BooleanEventTruck))]
    internal sealed class BooleanEventTruckEditor : EventTruckEditor<bool> {}
}