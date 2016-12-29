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

**Per Class Settings**<br>
Any class which has data that might be desirable to have hand-edited in editor should define a Serializable class called Settings within it. It should request an instance of its Settings class at [Inject], and have a default values fallback in the event that one is not provided.

**Per Class Factories**<br>
Any class which needs to be instantiated at runtime should define its own factory class in itself.

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
