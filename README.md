<p align="center"><img src="Assets/Logo/logo.png" alt="MagicalLife" height="300px"></p>

Thanks for the logo Batarian711!

# Magical Life
A fantasy world that imagines what a Rimworld style game could truly do if it had more elements in common with an RPG.

Master Branch:
[![Build status](https://ci.appveyor.com/api/projects/status/utahvkv3dvsp330m/branch/master?svg=true)](https://ci.appveyor.com/project/SneakyTactician/magicallife/branch/master)
[![Codacy Badge](https://api.codacy.com/project/badge/Grade/d8fc3d3cd10a4b6890660dffbcae158a)](https://www.codacy.com/app/sneakytactician/MagicalLife?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=SneakyTactician/MagicalLife&amp;utm_campaign=Badge_Grade)
[![](https://tokei.rs/b1/github/SneakyTactician/MagicalLife?category=code)](https://github.com/SneakyTactician/MagicalLife)
[![](https://tokei.rs/b1/github/SneakyTactician/MagicalLife?category=blanks)](https://github.com/SneakyTactician/MagicalLife)
[![](https://tokei.rs/b1/github/SneakyTactician/MagicalLife?category=files)](https://github.com/SneakyTactician/MagicalLife)
[![](https://tokei.rs/b1/github/SneakyTactician/MagicalLife?category=lines)](https://github.com/SneakyTactician/MagicalLife)
[![](https://tokei.rs/b1/github/SneakyTactician/MagicalLife?category=comments)](https://github.com/SneakyTactician/MagicalLife)

Development Branch:
[![Build status](https://ci.appveyor.com/api/projects/status/utahvkv3dvsp330m?svg=true)](https://ci.appveyor.com/project/SneakyTactician/magicallife)

## Project Needs
* Textures
* Sound Effects
* Songs/Soundtrack
* Quests/Written story/Lore

* Programmers
* Testers

If you can provide one of the above things, let me know!

You can email me at SneakyTactician@outlook.com or create an issue in this repository.

I would appreciate the help.
Thanks!

## Features
* Multiplayer support
* Hardware accelerated graphics via Monogame

Check out the [demo](https://youtu.be/NV8WLheFxtM) to see the latest progress!

## Roadmap (In no particular order)
AKA TODO:

~~Not buggy graphics~~

~~Items~~

~~Character Actions (such as mining or building)~~

~~Save/Load Game~~

~~Natural objects such as trees~~

Character Classes and ~~XP system~~

~~Inventory~~

Agriculture

Traders

Creatures (Enemies and Animals)

AI

Spells/Abilities

Fantasy Loot

Dungeons

Randomized Quests


Mod support: Always a priority

# Installation Instructions

1. Download and install the [.Net Framework 4.7.1 Runtime](https://www.microsoft.com/en-US/download/details.aspx?id=56116)
2. Find and download a release from the releases tab of this project
3. Extract the release
4. Enjoy!

# Development Instructions

1. Download and install *any* version of [Visual Studio 2017](https://visualstudio.microsoft.com/downloads/)
2. Download and install [Monogame 3.6](http://www.monogame.net/2017/03/01/monogame-3-6/) for Visual Studio.
3. Download and install the [2012 VC++ x64 Redistributable](https://www.microsoft.com/en-us/download/details.aspx?id=30679)
4. Clone this repository
5. Open the solution, and set the solution configuration to *debug, x64*. 
6. That's all!

Hint: Due to something weird with Monogame in Visual Studio, I advise *building* the GUI or Dedicated server (Depending on what you want to debug) everytime you make a code change and want to run this game. Hitting *start* doesn't always seem to compile your changes/insert breakpoints when working with Monogame.

# Vision

A polished game with aspects similar to [RimWorld](https://store.steampowered.com/app/294100/RimWorld/),
but with magic and aspects of RPG.

## Goals

* High replayability value
* Balanced gameplay
* Fun multiplayer game experience

#### Dungeons
* Should be kinda scary (Scary sound, Scary visuals, nasty monsters)
* Dungeons are spawned in the world with random difficulties
	* Go into one at your own risk
	* Higher the difficulty, the higher the reward
	* Some components for spellcasting or tech components might be found here
* Unlike games like D&D there are no restrictions on how many characters go exploring a dungeon
	* A large population might enable you to raid a more difficult dungeon, abeit with high casualties

#### Economy
* Based on supply and demand
* Everything the merchants sell has to come from somewhere
	* If supplies dry up, merchants don't have much to sell, and prices spike
* You can have your colonists do trade routes with other players, trading goods for other goods or money at a preagreed rate

#### Multiplayer
* Should support at least 10 players running on a dedicated server
* Diplomacy system enabling various treaties (As well as war)
	* Peace treaty, trade treaty, defensive pact, Alliance
* You can claim territory by building a special structure
	* Other players cannot do anything besides pass through unless you give them the correct permissions

#### Enemies
* Enemies will be based upon various mythology, such as Greek mythology, Norse mythology...

#### World
* Procedurally generated world
* Custom world sizes
* Other "Dimensions", with different creatures, plant life, and materials

#### Food
* Everything needs to eat
* You start the game with two different bags of seeds
	* Seed bags never run out
* To get a new type of seed, you have to purchase it from a merchant, or craft a lot of the crop into a seed bag
* Merchants only carry a few seeds of a type, so on a large multiplayer server you will have to trade for it

## Tech and Magic
* Both technology and magic are availible
	* Technology is based more upon resource processing and research
	* Magic is based upon character leveling up, learning new spells, and gathering components for permenent spells 

#### Classes
* Various character classes exist
	* Wizard, Cleric, Thief, Paladin, Necromancer (Evil Cleric), Monk, Warrior, Knight
		*Each of these can have subclasses
* Characters with classes like above are not really capable of participating in the tech progression
	* They aren't allowed to research technology or construct tech items
* When a character levels up, they can choose to gain various abilities
	* At low levels, they are allowed to instantly choose which abilities they get when leveling up
	* At high levels, they may level up, but to actually get a new ability and spend ability points they need to be trained by a trainer in that specific skill

#### Skills
* Everything is a skill
* Construction, Mining, Hauling, shooting, melee, research, trading
* Even things from RPG classes are skills
	* Just because the wizard gained the ability to cast a new spell, doesn't mean he is good at casting that spell
	* Fighters have to get good at the various moves and abilities they learn

#### Technologies
* The tech tree starts in basically the stone age
* You know how to make fire, hunt, and make crude weapons and tools
* Tech tree ends in the far off future, where everything is digital, artificial intelligence runs your base, and the dying can be healed of everything

#### Magic
* There is a spell for doing almost everything
* Spellcasters only know a few spells to begin with
	* They have to find scrolls with the correct words to memorize
* Some spells are permenent, others are one time effects
	*Permenent spells require components, and have a high mana cost
	* Permenent spells can be destroyed/dispelled
* Examples of permenent spells
	*Light, grow crops, intruder alarm...
* Temporary spells
	* Terraform land, fireball, energy bolt, magic barrier...
* Spellcasters only have so much mana, so they can only cast so many spells until they run out
	*Mana is regenerated by sleepa
* Casters of the same type can work together
	* Ex: Two clerics could work together to cast a spell with mana requirements higher than they could meet alone
	
# Credits

## Contributors
Lynngr - Did all of the artwork

ockenyberg - Made all of the sound effects

Batarian711 - Created the logo for this project

## Assembly Descriptions

### MagicalLifeAPIStandard
* The main game API, manages most things except for graphics and server commands

### MagicalLifeAPIClientStandard
* Manages how the client interprets messages from the server

### MagicalLifeDedicatedServerCore
* Controls the server
* Run server commands

### MagicalLifeGUIWindows
* Windows only graphical client

### MagicalLifeModdingAPI
* Exposes the functionality in MagicalLifeAPIStandard in a more restricted/managed manner
* Handles conflicts between mods, mod loading, and mod communication

### MagicalLifeServerStandard
* Handles server functionality such as:
	* Sending information to clients
	* Handling information from clients
	* Generating the world
* Handles both dedicated and local server logic

### MagicalLifeSettingsStandard
* Holds some settings for all of the assemblies in the project

## Libraries Utilized
[MonoGame](http://www.monogame.net/)

Released under the [Microsoft Public License and the MIT License](https://github.com/MonoGame/MonoGame/blob/develop/LICENSE.txt)

#### Does the heavy lifting for graphics, asset loading, and more!
---

[FMOD](https://www.fmod.com/)

Released under the [FMOD END USER LICENCE AGREEMENT](https://www.fmod.com/resources/eula)

#### Audio

---
[MonoGame.Extended](https://github.com/craftworkgames/MonoGame.Extended)

Released under the [MIT License](https://github.com/craftworkgames/MonoGame.Extended/blob/develop/LICENSE)

#### Used to capture keyboard and mouse input

---
[A* Algorithm](https://github.com/roy-t/AStar) by Roy-T

Released under the [MIT License](https://github.com/roy-t/AStar/blob/master/LICENSE)

#### Provides the pathfinding for Magical Life
---
[ProtoBuf-net](https://github.com/mgravell/protobuf-net)

Released under the [Apache License 2.0](https://github.com/mgravell/protobuf-net/blob/master/Licence.txt)

#### Used for quickly serializing objects into a small payload to be sent over the network
---
[Simple TCP](https://github.com/BrandonPotter/SimpleTCP)

Released under the [Apache License 2.0](https://github.com/BrandonPotter/SimpleTCP/blob/master/LICENSE)

#### Utilized to send data over the network
---
[C# Spatial Index (RTree) Library](https://github.com/drorgl/cspatialindexrt)

Released under the [GNU Lesser General Public License](https://github.com/SneakyTactician/MagicalLife/blob/Master/Licenses/GNU%20Lesser%20General%20Public%20License)

#### Used for quickly finding objects nearest to a location, or getting all objects within a certain area.
---


