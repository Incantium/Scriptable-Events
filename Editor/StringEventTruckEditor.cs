using UnityEditor;

namespace Incantium.Events.Editor
{
    /// <summary>
    /// Class representing the Unity Editor inspector for <see cref="StringEventTruck"/>.
    /// </summary>
    [CustomEditor(typeof(StringEventTruck))]
    internal sealed class StringEventTruckEditor : EventTruckEditor<string> {}
}