# [EventBus](../Runtime/EventTruck.cs)

Class in `Incantium.Events` | Assembled in [`Incantium.ScriptableEvent`](../README.md)

Extends [`ScriptableObject`](https://docs.unity3d.com/ScriptReference/ScriptableObject.html)

## Description



## Example

```csharp
using Incantium.Events;
using UnityEngine;

public class ExampleClass : MonoBehaviour
{
    [SerializeField]
    private EventTruck<string> eventTruck;

    // Subscribe to the event anywhere you want.
    private void Start() => eventTruck.onRespond += Response;

    // Don't forget to unsubscribe from the event at some point.
    private void OnDestroy() => eventTruck.onRespond -= Response;

    // Listen to the event.
    private string Response() => "Hello World!";
    
    // Invoke the event when needed.
    public void OnClick()
    {
        var result = eventTruck.Request();
        
        Debug.Log(result);
    }
}
```

## Notes

> **Info**: This package includes basic event bus implementations for boolean, integer, float, double, string, Vector2, 
> Vector3, and GameObject.

## Variables

### :green_book: `UnityAction` onRequest

Subscribe to this event to send and receive notifications.
