using UnityEditor;

namespace Incantium.Events.Editor
{
    /// <summary>
    /// Class representing the Unity Editor inspector for <see cref="FloatEventTruck"/>.
    /// </summary>
    [CustomEditor(typeof(FloatEventTruck))]
    internal sealed class FloatEventTruckEditor : EventTruckEditor<float> {}
}