using Incantium.Events.Request;
using UnityEditor;
using UnityEngine;

namespace Incantium.Events.Editor.Request
{
    /// <summary>
    /// Class representing the Unity Editor inspector for <see cref="GameObjectEventTruck"/>.
    /// </summary>
    [CustomEditor(typeof(GameObjectEventTruck))]
    internal sealed class GameObjectEventTruckEditor : EventTruckEditor<GameObject> {}
}