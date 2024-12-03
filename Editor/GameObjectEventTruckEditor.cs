using UnityEditor;
using UnityEngine;

namespace Incantium.Events.Editor
{
    /// <summary>
    /// Class representing the Unity Editor inspector for <see cref="GameObjectEventTruck"/>.
    /// </summary>
    [CustomEditor(typeof(GameObjectEventTruck))]
    internal sealed class GameObjectEventTruckEditor : EventTruckEditor<GameObject> {}
}