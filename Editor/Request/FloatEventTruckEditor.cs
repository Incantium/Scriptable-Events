using Incantium.Events.Request;
using UnityEditor;

namespace Incantium.Events.Editor.Request
{
    /// <summary>
    /// Class representing the Unity Editor inspector for <see cref="FloatEventTruck"/>.
    /// </summary>
    [CustomEditor(typeof(FloatEventTruck))]
    internal sealed class FloatEventTruckEditor : EventTruckEditor<float> {}
}