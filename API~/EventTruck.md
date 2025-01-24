# [EventTruck](../Runtime/Request/EventTruck.cs)

Class in `Incantium.Events.Request` | Assembled in [`Incantium.ScriptableEvents`](../README.md)

Extends [`ScriptableObject`](https://docs.unity3d.com/ScriptReference/ScriptableObject.html)

## Description

The EventTruck is a [ScriptableObject](https://docs.unity3d.com/6000.0/Documentation/Manual/class-scriptableobject.html)
that other scripts can subscribe to and listen to invocations from other scripts. It is similar to the 
[EventBus](EventBus.md) with one notable change: it expects a return value.

The main use case is to decouple code that needs to be developed and tested separately. In many circumstances, game
objects that are depended on other systems (through references) cannot be tested in isolation without their references
being set. The EventTruck solves this problem by creating a common point to which the dependent system are coupled.

## Example

```csharp
using Incantium.Events.Request;
using UnityEngine;

public class ExampleClass : MonoBehaviour
{
    [SerializeField]
    private EventTruck<string> eventBus;

    // Subscribe to the event anywhere you want.
    private void Start() => eventBus.onRespond += Response;

    // Don't forget to unsubscribe from the event at some point.
    private void OnDestroy() => eventBus.onRespond -= Response;

    // Listen to the event.
    private string Response() => "Hello World!";
    
    // Invoke the event when needed.
    public void OnClick()
    {
        var response = eventBus.Request();
        Debug.Log(response);
    }
}
```

## Notes

> **Info**: This package includes basic event truck implementations for boolean, integer, float, double, string, 
> Vector2, Vector3, and GameObject.

## Variables

### :green_book: `Action` onRespond;

Event, when subscribed to, will be notified when something else [request](#green_book-void-request) an answer.

### :green_book: `int` count

Amount of event handlers connected to this event.

## Methods

### :green_book: `T` Request()

Method to call a method subscribed to [onRespond](#green_book-action-onrespond) for an answer.

### :green_book: `T[]` RequestAll()

Method to call all methods subscribed to [onRespond](#green_book-action-onrespond) for an answer.

### :green_book: `void` Reset()

Method to remove all methods from this event.
