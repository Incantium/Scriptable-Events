# Scriptable Events

`Unity 2022.3 (or higher)`
`.NET Standard 2.1`
`C# 9.0`

## Overview

The Scriptable Events is a custom-made Unity package where you can create event channels in the form of the
[ScriptableObjects](https://docs.unity3d.com/ScriptReference/ScriptableObject.html). This makes it possible to let 
multiple scripts communicate without needing to know each other.

## Installation instructions

- Open the [Package Manager](https://docs.unity3d.com/Manual/upm-ui.html) in a Unity project.
- Click on the "+" button to add a new package.
- Click on "Install package from git URL...".
- Put in `https://github.com/Incantium/Scriptable-Event.git`.
- Click on "Install" or press enter.
- Enjoy!

## Limitations

- The event channels in this package are all method invocation obfuscation. How and when a method is called is
  difficult to trace through the usage of an event channel. 
- This package includes pre-build solutions for many event channel types (like the primitives, vectors, and
  GameObject). Custom event types for custom classes, interfaces, and enums, must be created by yourself, unfortunately.

## Workflow

Creating and using an event channel is very simple. The first three steps will teach you the basics of creating a 
pre-build event channel implementation. For a custom event channel, see step 4 & 5.

In this short tutorial, we are going to create an event channel whereby the player updates the health bar within the UI.

### Step 1: Create a new instance

Before writing any code, it is important to first create the event channel you desire as a 
[ScriptableObjects](https://docs.unity3d.com/ScriptReference/ScriptableObject.html). For the pre-build event channel
implementations, go to "Create ⇾ Events" in the Create window. Here, you can choose between a Send 
([event bus](#what-is-an-event-bus)), or a Request ([event truck](#what-is-an-event-truck)) channel. Give the newly
created event channel a fitting name; that is the only way to specify its purpose for the game you are making.

Within this tutorial, we will create a new float event bus under "Create ⇾ Events ⇾ Send ⇾ Float".

### Step 2: Listen to the event

```csharp
using Incantium.Events;
using UnityEngine;

/// <summary>
/// Class responsible for updating the health bar when the proper event has been received.
/// </summary>
public class HealthBar : MonoBehaviour
{
    [SerializeField] 
    [Tooltip("The event bus listening to changes within health.")]
    private FloatEventBus eventBus;

    private void OnEnable() => eventBus.onReceive += UpdateHealthBar;

    private void OnDisable() => eventBus.onReceive -= UpdateHealthBar;

    /// <summary>
    /// Method to update the health bar with a new value. This method is called when the event channel is called.
    /// </summary>
    /// <param name="health">The new health to display.</param>
    private void UpdateHealthBar(float health)
    {
        // Update health bar.
    }
}
```



> **Warning**: Do not forget to remove the event handler (the method after the +=) when listening to the event channel
> is not needed anymore. Methods added to the event channel will persist between Unity Editor play sessions (because
> an event channel is an [ScriptableObjects](https://docs.unity3d.com/ScriptReference/ScriptableObject.html)). 
> Forgetting to remove the event handler can lead to unwanted side effects. You can manually remove all the event 
> handlers from an event channel by clicking on the "Reset" button in the Unity inspector or by calling the `Reset()` 
> method

### Step 3: Call the event



### Step 4 & 5: Custom events

This package includes pre-build solutions for many event channel types, like the primitives, vectors, and
GameObject. However, this package also offers the capability to the creation of a custom event channel from a custom
class, interface or even an enum. You can read [here](Documentation~/Create%20a%20custom%20typed%20event%20channel.md)
how to create a custom event channel.

### Step 5: Custom inspector

The custom event as created with the workflow above will not show its custom inspector view. To create that, read 
[here](Documentation~/Create%20a%20custom%20typed%20editor%20inspector.md) the full instructions to create the custom
inspector for every custom event channel.

## Advanced topics

### What is an event channel within this package?

Simply said, an event channel in this package is a 
[ScriptableObjects](https://docs.unity3d.com/ScriptReference/ScriptableObject.html) that contains one 
[C# event](https://learn.microsoft.com/en-us/dotnet/standard/events/).

Events in C# are based on the [observer design pattern](https://refactoring.guru/design-patterns/observer), which 
enables a subscriber to register and receive notifications from a provider. An event sender pushes a notification, and 
an event receiver receives that notification.

The C# event is encapsulated within a 
[ScriptableObjects](https://docs.unity3d.com/ScriptReference/ScriptableObject.html) to make an event statically 
accessible throughout the whole Unity project as a serialized instance. This makes it possible to predefine multiple
event channels beforehand.

This package gives access to two kinds of event channels: The event bus & -truck.

### What is an event bus?

![Event Bus Flow](Images~/Event%20Bus%20Flow.png)

The [event bus](API~/EventBus.md) is a **send** event channel. This kind of event channel can be used to notify one 
(or multiple) other receivers. 

This package includes four different event bus abstractions and multiple implementations. These are:

- A default event bus, with no typing. This event bus can be used to invoke a method on another script(s) without a 
  required context.
- A single-typed event bus. This event bus can be used to send one value to another script(s). This package includes
  pre-build implementations for boolean, integer, float, double, 
  [Vector2](https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Vector2.html), 
  [Vector3](https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Vector3.html), and
  [GameObject](https://docs.unity3d.com/6000.0/Documentation/ScriptReference/GameObject.html). 
- A dual-typed event bus to send two values.
- A triple event bus to send three values.

> **Note**: The image above shows a one-to-many relation. However, it is possible to use the event bus as a many-to-many
> relationship by having multiple senders.

### What is an event truck?

![Event Truck Flow](Images~/Event%20Truck%20Flow.png)

The [event truck](API~/EventTruck.md) is a **request** event channel. This kind of event channel can be used to request
a value from one (or multiple) other receivers.

- A single-typed event truck. This event truck can be used to request one value from another script(s). This package 
  includes pre-build implementations for boolean, integer, float, double,
  [Vector2](https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Vector2.html),
  [Vector3](https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Vector3.html), and
  [GameObject](https://docs.unity3d.com/6000.0/Documentation/ScriptReference/GameObject.html).
- A dual-typed event truck to request two values.
- A triple event truck to request three values.

> **Note**: The image above shows a one-to-many relation. However, it is possible to use the event truck as a 
> many-to-many relationship. This requires the use of the [RequestAll](API~/EventTruck.md) method.

## References

| Class                                        | Description                                                            |
|----------------------------------------------|------------------------------------------------------------------------|
| [EventBus](API~/EventBus.md)                 |                                                                        |
| [EventBusEditor](API~/EventBusEditor.md)     |                                                                        |
| [EventTruck](API~/EventTruck.md)             |                                                                        |
| [EventTruckEditor](API~/EventTruckEditor.md) |                                                                        |

## Frequently Asked Questions

### Which Unity versions are compatible with this package?

This package is heavily tested in `Unity 2022.3.44f1` and `Unity 6000.0.25f1`. It is expected that this package also
works in older and newer versions of the Unity Editor because it is not dependent on any other Unity package.

### Why should I use an event channel instead of a direct method invocation?

A method invocation between two different scripts/classes is within software engineering called a dependency. Simply 
said, script A calls script B, so A is dependent on B's answer. In most cases, this is fine. However, it becomes a 
problem when script A needs to be tested independently. Because of its dependency to B, it cannot be tested without the 
inclusion of B. And when B is dependent on C, and so on, testing will become on the level of the whole game. This is
less ideal.

The event channels are similar to dependencies, but less strict. They are like optional dependencies. A may give a 
shout, but B is not required to answer. This is the effect of the event channels.

In essence, the event channels decouple the code to make it easier testable.

### When should I use an event channel and when shouldn't I?

Here below is the general rule you should use when deciding when to use an event channel:

> "Only use an event channel when two separate codebases at a large distance needs to communicate."

Within this rule, "a large distance" means that the two codebases exists in their own metaphorical space and do not 
naturally work together. An example is the player scripts and the UI. In many games, the UI must be updated when the
player receives damage. However, the codebase of the player and the UI are separate from each other, often even build
by different teams. In this context, it is natural to use an event channel.

The second reason to use an event channel is when the two codebases are separated within different scenes. The usage of
[additive scenes](https://docs.unity3d.com/6000.0/Documentation/ScriptReference/SceneManagement.LoadSceneMode.Additive.html)
is a feature more Unity game developers should use effectively. However, direct invocation of a script in another scene 
is impossible; this can only be done through a 
[ScriptableObjects](https://docs.unity3d.com/ScriptReference/ScriptableObject.html), which all event channels are. 

The third valid reason to make use of an event channel is to make different systems independent (testable) from each 
other. Because an event channel is an optional subscription, no 
[null pointer exceptions](https://learn.microsoft.com/en-us/dotnet/api/system.nullreferenceexception?view=net-9.0) will 
be thrown when no one replies. As such, the different systems can be tested independently of each other, without the 
requirement to each other.

However, event channels are not always the most optimal solution. In truth, all event channels are obfuscation of 
method invocation, as it is not apparent if a method listens, if any at all. This problem is mitigated by the custom
inspector implemented for all event channel types. However, this inspector only shows the methods that listen, in
runtime, when they start listening, and not sooner. This is the largest drawback of the event channel.
