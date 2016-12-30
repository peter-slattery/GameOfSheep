# GameOfSheep
Repo for GameOfSheep

## Table of Contents
- [Project Goals](#project_goals)
- [Setup](#setup)
	- [Unity Information](#unity_information)
	- [Tools](#tools)
- [Conventions](#conventions)
- [Project Structure](#project_structure)
- [Modules](#modules)

<a name="project_goals"></a>
## Project Goals 

<a name="setup"></a>
## Setup

<a name="unity_information"></a>
### Unity Information
**Version:** Unity 5.6 (Currently in Beta)

<a name="tools"></a>
### Tools
**UnityYAMLMerge**<br>
[Information on setting up UnityYAMLMerge](https://docs.unity3d.com/Manual/SmartMerge.html) is here.
We found that this wasn't super helpful in setting it up. [The walkthrough we used is here](http://kihira.uk/unity-and-git-getting-them-to-play-nicely/).
*Note: The walkthrough is for windows. Make sure you change the paths accordingly, and either remove the `.exe` extentions, or change them to `.app`*

**KDiff3**<br>
In the process of setting up UnityYAMLMerge, we decided to use KDiff3 as our backup. [KDiff3 is here](https://sourceforge.net/projects/kdiff3/files/)<br>
*Note: You need to put the KDiff3.app file in `Applications/KDiff3'*

**ZenJect**<br>
We are using [Zenject](https://github.com/modesttree/Zenject) to handle dependency injection, as well as the framework around which we are building modules of the game. Our goal is to create as much independent, tested, documented and reusable code as possible over the course of this project.

<a name="conventions"></a>
## Conventions
**IOC Context**<br>

**Class Factories**<br>
Any class which needs to be instantiated at runtime should define its own factory class in itself.

**Facade, Model, Controller Design Pattern** <br>
In attempting to merge Unity's native Entity-Controller methodology, with a Model-View-Controller architecture which follows Dependency Injection, and Inversion of Control, we have arrived at what we are calling the Facade-Data-Controller Pattern.

Each Game System is composed of a Facade, a Model and a Controller.

***Facade:*** Facades act as both the public face of a Game System, and as an IOC Context. Facades instantiate and inject dependencies into the classes of the given system, thus acting as the Systems IOC Context.

Facades also act as a public interface for the System as a whole, following the Facade design pattern. Because Facade's act as the connection between the System and the larger game context, we are using them to represent the system as a whole.<br> 
*For Example:* a Factory called SheepDogFactory is actually responsible for instantiating the SheepDogFacade on a game object, either empty or from a prefab, injecting dependencies into the Facade, and causing the Facade to Initialize the rest of the system.

***Model:*** Model classes simply provide references to various data relevant to the internal workings of the System. 
- This data can be accessed and modified either directly by other classes in the System, or through accessors in the Facade for extra-System references.<p>
*Model Targets:* All Models which extend from ModelBase contain a field for an instance of a class inheriting from abstract class Targets. Children of class Targets store additional data which should be set within the System to be acted on by Components (see below). Components attached to a System may request access to the System's Model's Targets instance, cast it to an interface defined by the Component, and use the data relevant to the Component. This decouples the function of the System from reusable, auxilliary functions.<br>
- *For Example:* SheepDogModel contains an instance of SheepDogTarget which implements IMovable. The component GroundedMovement (which extends class Movement) requests SheepDogFacade.Targets() as IMovable. If the cast succeeds, GroundBasedMovement acts on the contained data, returning if the cast fails.

***Controller:*** The Controller of a given System implements the logic of the System. It acts on its Model and any dependencies to carry out the function of the System. In the case of Game Actors, like Sheep, and Wolves, the Controller may be a State Manager. In the case of more general systems like Wind, it simply executes the functionality of the System itself.

**Registries** <br>
Registries act as the binding between Systems. A Registry should not be critical to the functionality of a System. Instead, if present it should augment the execution of that System.<p>
Any given Registry has two requirements:

1. Expose hooks as delegate methods which can be subscribed to.
2. Expose public functions through which to call delegates.

*For Example:* The Sheep System should function fully by itself. However, it can request a reference to the Bark Registry from the Scene Context. If it is not null, the Sheep Facade subscribes to the Bark Registry's OnBark delegate method. On the other end, the SheepDog can request and store a reference to the Bark Registry. When the SheepDog System receives the Bark command from some Input Handler, it handles the state change, audio and animations internally. If a reference to the Bark Registry exists, it calls the Bark Registry's Bark function, which in turn calls OnBark for all subscribed Systems.

**Components** <br>

**Spawns** <br>

**Class Settings**<br>
Any class which has data that might be desirable to have hand-edited in editor should define a Serializable class called Settings within it. It should request an instance of its Settings class at [Inject], and have a default values fallback in the event that one is not provided.

~~~~
class DogData {
	...
	[System.Serializable]
	public class Settings {
		... Settings Here ...
	}
}
~~~~

<a name="project_structure"></a>
## Project Structure

### Modules
We have broken the game down into its component modules (see below). Each module is given its own folder structure, mimicing the structure of the overall project. 
<br>This should encourage:

- Limited dependencies between Modules
- Test Scenes for each feature of a Module
- Final Installers for each Module 
- Test Installers for each Test Scene
- Integration Installers and Test Integration Installers to ensure combined Modules operate as expected.


<a name="modules"></a>
## Module List
### Audio - [ReadMe](Assets/Modules/Audio/README.md)
**Summary**<br>
<br>
---
### Camera - [ReadMe](Assets/Modules/Camera/README.md)
**Summary**<br>
Handles management of functionality which is Camera dependent. This includes Level of Detail objects, dynamic cinematic moments, managing camera focus and transitioning between discrete camera states and effects.
<br> 
---
### Environment - [ReadMe](Assets/Modules/Environment/README.md)
**Summary**<br>
Handles management of environmental effects. Defines a central manager which coordinates features such as Wind, Precipitation, and Atmosphere.
<br>
---
### Position Modifier [ReadMe](Assets/Modules/PositionModifier/README.md)
**Summary**<br>
Extended in Movement and Flocking, provides a common interface for requesting an altered position based on some ruleset (should all potential positions for this entity adhere to the ground? should they be influenced by wind? etc).
<br>
---
### Movement - [ReadMe](Assets/Modules/Movement/README.md)
**Summary**<br>
Extends PositionModifier. Provides a common interface for evaluating movement around the world. Defines a number of rulesets (GroundBasedMovement, WaterBasedMovement, WalkAndSwimMovement etc.) which modify desired positions to account for environmental concerns.
<br>
---
### Flocking - [ReadMe](Assets/Modules/Flocking/README.md)
**Summary**<br>
Extends PositionModifier. Provides a common interface for evaluating movement based on a flock. Defines a Generic Flock Manager which can utilize subclasses of Flocking Algorithms to evaluate Flocking Entities positions in the world.
<br>
---
### Levels - [ReadMe](Assets/Modules/Levels/README.md)
**Summary**<br>
<br>
---

### Sheep - [ReadMe](Assets/Modules/Sheep/README.md)
**Summary**<br>
<br>
---
### SheepDog - [ReadMe](Assets/Modules/SheepDog/README.md)
**Summary**<br>
<br>
---