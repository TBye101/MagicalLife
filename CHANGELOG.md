SneakyTactician  <SneakyTactician@outlook.com>

---

## [Version 0.1.2]

#### API
*Now supports the tilling of dirt
*Skills are now in
*Harvest skill now has impact on the speed of harvesting resources
*Removed Serilog dependency
*Inventories are now baked in for creatures
*Increased camera performance, 100x100 worlds are possible (~22 fps)

#### GUI
*Tilling dirt is now available from the in game GUI
*2K support (2560x1440)
*Certain windows are now movable
*Creatures can now be clicked upon to see their skills/creature window
*Added the new log texture
*Skills/creature window now has an inventory tab
*Zooming out now supported

#### Bugs

---

## [Version 0.1.1]

#### API
*Audio now has multiple channels/can play multiple sounds simultaneously
*Audio now has a surround sound effect
	*Audio listening is set from the center of the screen
*API now works anywhere C# can run
*Dedicated server now runs on Mac and Linux in addition to windows
*Trees now in as a resource
*Trees are now harvestable
*Oak Trees are now in
*Maple Trees are now in
*Pine trees are now in
*Now handles the dropping of an item on a tile that already has an item of a different type on it.

#### GUI
*Trees now render
*Axe button now allows for the user to mark which trees to chop down

#### Bugs
*Items now render properly again
*Reduced the occurrences of a saving bug

---

## [Version 0.1.0] 

#### API
* Saving a game is now supported
* Loading a game is now supported
* Errors are now logged
* Job system is now client side
* Job system now has enhanced support for dependencies
* Job system now has enhanced support for "bound" (same worker) jobs
* Graphics API reworked to support animations, as well as any future different types of rendering

#### Server
* The newgame command now requires a 3rd parameter, the world's name

#### GUI
* The host game button has been replaced by the load game button
* Added listbox support
* Added the load game listbox
* Load game menu now works
* Added a back button to the in game escape menu
* Input boxes no longer error when reopening menus and backspacing
* The placeholder texture for the mine action button has been replaced
* Stone rubble texture has been replaced
* Pickaxe icon in map when tile is queue up to be mined has changed
* Added the ability to zoom in
* Characters now have new texture
* Characters now have animations

#### Bugs

* Fixed a mining command bug
* Fixed a memory Leak

---

## [Version 0.0.9]

#### API
* Added internal support for having items in tiles
* Added item addition, removal, and search functionality
* Added a grass tile
* Added the stone chunk item
* Mining jobs are now possible
* Added internal support for sfx/sound events

#### Server
* Separated server loading and server starting into two separate commands
* Now handles player connections and disconnections in a safer way

#### GUI
* Grass textures now connect to form smoother patterns
* Now showing logos for MonoGame and FMOD
* Player can now mark stone to be mined

#### Sound
* Buttons now play a clicking sound when clicked upon
* Stone now plays a pickaxe hitting noise while it is being mined

#### Bugs
* Fixed issue [#17](https://github.com/SneakyTactician/MagicalLife/issues/17)
* Fixed issue [#57](https://github.com/SneakyTactician/MagicalLife/issues/57)
* Fixed an issue sometimes causing the character to be unselectable
* Discovered and fixed issue [#50](https://github.com/SneakyTactician/MagicalLife/issues/50)

* Discovered issue [#51](https://github.com/SneakyTactician/MagicalLife/issues/51)

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