		SneakyTactician  <SneakyTactician@outlook.com>
	[Version 0.0.0.7]
		### GUI
			*Added buttons to the main menu to allow the user to join and host a multiplayer game
		### API
			*API is now capable of sending and recieving objects in a very dynamic and elegant way
		### Bugs
			*Discovered issue [#14](https://github.com/SneakyTactician/EarthWithMagic/issues/14)
    [Version 0.0.0.6]
		### GUI
			*Stone is now rendered
		### API
			*Stone is now generated in world
			*Abstracted pathfinding so that we can support any algorithm with a little tweaking/a bridge between how each algorithm stores the path found
			*Pathfinding now forbides living creatures from moving on tiles with marble.
		### Tweaks
			*Ordering a unit now clears previous orders

	[Version 0.0.0.5]
		### GUI
			*Living creatures are now being rendered
			*Living creatures can now be individually selected and order to a location

		### Bugs
			*Discovered that main menu fails to show when pressing escape (Issue #11)

	[Version 0.0.0.4]
		### GUI
			*Now displays new game button
			*Now recieves mouse input as events
			*Mouse now displays
			*Escape now toggles the main menu
			*Clicking a main menu button now hides the main menu
			*Exit button now exits the game
			*User can now choose the size of the world

		#### API
			* Now using Monogame 
			* Now supports a load game progress bar

		### Bugs
			*Solved a bug that didn't allow for more than one GUI object recieving mouse input (b88e0815)

	[Version 0.0.0.3]
		### Features
			*End turn button is now rendered
		#### API
			*Support for creature movement
		### Tweaks
			*Changed many data structures under the hood

	[Version 0.0.0.2]
		### Features
			*Living creatures are now rendered

		#### API
			*Living creatures are now supported

	[Version 0.0.0.1]
		
		### Features
			*The world displays when told to generate a new world

		#### API
			*World generates properly