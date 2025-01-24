# Scriptable Events

![Unity version](https://img.shields.io/badge/2022.3+-cccccc?logo=unity)
![.NET version](https://img.shields.io/badge/Standard_2.1-5027d5?logo=dotnet)
![C# version](https://custom-icon-badges.demolab.com/badge/9.0-67217a?logo=cshrp)

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

- This package cannot be properly used without having a basic understanding of C#, Unity
  [MonoBehaviour](https://docs.unity3d.com/6000.0/Documentation/ScriptReference/MonoBehaviour.html), and
  [ScriptableObjects](https://docs.unity3d.com/ScriptReference/ScriptableObject.html).
- The event channels in this package are all method invocation obfuscation. How and when a method is called is
  difficult to trace through the usage of an event channel. 
- This package includes pre-build solutions for many event channel types (like the primitives, vectors, and
  GameObject). Custom event types for custom classes, interfaces, and enums, must be created by yourself, unfortunately.

## Workflow

Creating and using an event channel is very simple. The first three steps will teach you the basics of creating an
implementation for a pre-build event channel. For a custom event channel, see step 4 & 5.

In this short tutorial, we are going to create an event channel whereby the player updates the health bar within the UI.

1. [Create a new instance.md](Documentation~/1.%20Create%20a%20new%20instance.md)
2. [Listen to the event.md](Documentation~/2.%20Listen%20to%20the%20event.md)
3. [Call the event.md](Documentation~/3.%20Call%20the%20event.md)
4. [Custom events.md](Documentation~/4.%20Custom%20events.md)
5. [Custom inspector.md](Documentation~/5.%20Custom%20inspector.md)

## Advanced topics

### What is an event channel within this package?

Simply said, an event channel in this package is a 
[ScriptableObject](https://docs.unity3d.com/ScriptReference/ScriptableObject.html) that contains one 
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

This package includes three different event truck abstractions and multiple implementations. These are:

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

| Class                                        | Description                                                 |
|----------------------------------------------|-------------------------------------------------------------|
| [EventBus](API~/EventBus.md)                 | Abstract class for a sending event channel.                 |
| [EventTruck](API~/EventTruck.md)             | Abstract class for a sending requesting channel.            |

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

### When should I use an event channel?

Here below is the general rule you should use when deciding when to use an event channel:

> "Only use an event channel when two separate codebases at a large distance needs to communicate."

Within this rule, "a large distance" means that the two codebases exists in their own metaphorical space and do not 
naturally work together. An example is the player and the UI. In many games, the UI must be updated when the player 
receives damage. However, the codebase of the player and the UI are separate from each other, often even build by 
different teams. In this context, it is natural to use an event channel.

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

### When shouldn't I use an event channel?

In essence, when other reliable ways are possible to communicate between scripts. Event channels cannot differentiate
between which listens or how many listen. Because of this, you need a new event channel for each one of them if you
want to call them separately. In such cases, you better should use other alternatives.

A couple of examples where not to use an event channel are:

- Scripts on the same [GameObject](https://docs.unity3d.com/6000.0/Documentation/ScriptReference/GameObject.html). In
  these cases, just use 
  [GetComponent](https://docs.unity3d.com/6000.0/Documentation/ScriptReference/GameObject.GetComponent.html), as it is
  more widely used. This also is true for close-proximity (in parent, in children).
- Communication on hit, like with 
  [OnCollisionEnter](https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Collider.OnCollisionEnter.html) or
  [OnTriggerEnter](https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Collider.OnTriggerEnter.html). In these
  scenarios, it is better to use 
  [TryGetComponent](https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Component.TryGetComponent.html) in 
  combination with an interface.

### Why are sending event channels called a "bus" and requesting a "truck"?

In software development, that is called an inside joke!

However, they also make a little bit of symbolic sense. A bus takes in people and delivers each person to a bus station. 
A truck goes on a request to take something and returns fully loaded. In both cases, you can also see it in the opposite 
way, but this package hides that fact.
