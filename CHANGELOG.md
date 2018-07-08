SneakyTactician  <SneakyTactician@outlook.com>

---

## [Version 0.0.9]

#### API

#### Server

#### GUI

#### Bugs

---

## [Version 0.0.8]

#### API
* World data is now structured differently, and hopefully more efficiently
* Improved serialization and deserialization performance

#### Server
* World generation now no longer spawns the character on a resource

#### Bugs
* Discovered and fixed issue [#21](https://github.com/SneakyTactician/MagicalLife/issues/21)
* Discovered and fixed issue [#22](https://github.com/SneakyTactician/MagicalLife/issues/22)
* Discovered and fixed issue [#24](https://github.com/SneakyTactician/MagicalLife/issues/24)
* Discovered and fixed issue [#25](https://github.com/SneakyTactician/MagicalLife/issues/25)
* Discovered and fixed issue [#26](https://github.com/SneakyTactician/MagicalLife/issues/26)


* Fixed issue [#11](https://github.com/SneakyTactician/MagicalLife/issues/11)
* Fixed issue [#18](https://github.com/SneakyTactician/MagicalLife/issues/18)
* Fixed issue [#27](https://github.com/SneakyTactician/MagicalLife/issues/27)

*Fixed an issue where ordering the character while "hosting" a game would cause the game to crash

---
## [Version 0.0.7]
#### GUI
* Added buttons to the main menu to allow the user to join and host a multiplayer game
* Added labels above the width and length input boxes
* Added a menu to allow the user to host a game over the network
* Added a menu to allow the user to join a game over the network

#### API
* API is now capable of sending and receiving objects in a very dynamic and elegant way
* Now split into three parts: server, client, and the shared API
* Server and client now have a tick system, and movement of creatures is done in real time

#### Bugs
* Discovered and fixed issue [#14](https://github.com/SneakyTactician/EarthWithMagic/issues/14)
* Discovered issue [#15](https://github.com/SneakyTactician/MagicalLife/issues/15)
---        
## [Version 0.0.6]
#### GUI
* Stone is now rendered

#### API
* Stone is now generated in world
* Abstracted pathfinding so that we can support any algorithm with a little tweaking/a bridge between how each algorithm stores the path found
* Pathfinding now forbids living creatures from moving on tiles with marble.

#### Tweaks
* Ordering a unit now clears previous orders
---
## [Version 0.0.5]
#### GUI
* Living creatures are now being rendered
* Living creatures can now be individually selected and order to a location

#### Bugs
* Discovered issue [#11](https://github.com/SneakyTactician/MagicalLife/issues/11)
---
## [Version 0.0.4]
#### GUI
* Now displays new game button
* Now receives mouse input as events
* Mouse now displays
* Escape now toggles the main menu
* Clicking a main menu button now hides the main menu
* Exit button now exits the game
* User can now choose the size of the world

#### API
* Now using Monogame 
* Now supports a load game progress bar

#### Bugs
* Solved a bug that didn't allow for more than one GUI object receiving mouse input (b88e0815)
---
## [Version 0.0.3]
#### Features
* End turn button is now rendered
#### API
* Support for creature movement
#### Tweaks
* Changed many data structures under the hood
---
## [Version 0.0.2]
#### Features
* Living creatures are now rendered

#### API
* Living creatures are now supported
---
## [Version 0.0.1]
		
#### Features
* The world displays when told to generate a new world

#### API
* World generates properly
---