using UnityEngine;

namespace Incantium.Events.Editor
{
    /// <summary>
    /// Class representing the different styling used within the scriptable event editor scripts.
    /// </summary>
    internal static class Styles
    {
        public static readonly GUIContent SEND = new("Send", "Send a message to all event handlers of the event bus.");
        public static readonly GUIContent REQUEST = new("Request", "Request the value from a event handler of the event truck.");
        public static readonly GUIContent REQUEST_ALL = new("Request All", "Request the value from all event handlers of the event truck.");
        public static readonly GUIContent RESET = new("Reset", "Reset the scriptable event from all event handlers.");
    }
}