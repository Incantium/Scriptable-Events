# Scriptable Event

`Unity 2022.3 (or higher)`
`.NET Standard 2.1`
`C# 9.0`

## Overview

The Scriptable Event is a custom-made Unity package where you can create event channels in the form of the
[ScriptableObjects](https://docs.unity3d.com/ScriptReference/ScriptableObject.html). This makes it possible to create
static event channels between two sections of your game, which can communicate without needing to know each other.

## Installation instructions

- Open the [Package Manager](https://docs.unity3d.com/Manual/upm-ui.html) in a Unity project.
- Click on the "+" button to add a new package.
- Click on "Install package from git URL...".
- Put in `https://github.com/Incantium/Scriptable-Event.git`.
- Click on "Install" or press enter.
- Enjoy!

## Limitations

- This package includes pre-build solutions for many event channel types (like the primitives, vectors, and 
  GameObject). Custom event types for custom classes, interfaces, and enums, must be created by yourself, unfortunately.

## Workflow

### Step 1: Create a new instance



### Step 2: Listen to the event



### Step 3: Call the event



## Advanced topics

### What is an event channel within this package?

Simply said, an event channel in this package is a 
[ScriptableObjects](https://docs.unity3d.com/ScriptReference/ScriptableObject.html) that contains one 
[C# event](https://learn.microsoft.com/en-us/dotnet/standard/events/).

Events in C# are based on the [observer design pattern](https://refactoring.guru/design-patterns/observer), which 
enables a subscriber to register and receive notifications from a provider. An event sender pushes a notification, and 
an event receiver receives that notification.

The C# event is encapsulated within a 
[ScriptableObjects](https://docs.unity3d.com/ScriptReference/ScriptableObject.html) to make a event statically 
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

A method invocation between two different scripts is within software engineering called a dependency. Simply said, 
script A calls script B, so A is dependent on B's answer. In most cases, this is fine. However, it becomes a problem 
when script A needs to be tested independently. Because of its dependency to B, it cannot be tested without the 
inclusion of B. And when B is dependent on C, and so on, testing will become on the level of the whole game. This is
less ideal.

The event channels are similar to dependencies, but less strict. They are like optional dependencies. A may give a 
shout, but B is not required to answer. This is the effect of the event channels.

In essence, the event channels decouple the code to make it easier testable.

### When should I use an event channel and when shouldn't I?

Here below is the general rule you should use when deciding when to use an event channel:

> "Only use an event channel when two separate codebases at a large distance needs to communicate."

A perfect valid example when to use an event channel is when to update the UI from the player stats. As a good practice
rule, the UI or the player should not be 

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

### 
