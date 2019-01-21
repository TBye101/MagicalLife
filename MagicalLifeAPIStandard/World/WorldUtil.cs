using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entity;
using MagicalLifeAPI.Entity.Entity;
using MagicalLifeAPI.Entity.Humanoid;
using MagicalLifeAPI.Networking.Messages;
using MagicalLifeAPI.Networking.Server;
using MagicalLifeAPI.Networking.World.Modifiers;
using MagicalLifeAPI.Util;
using MagicalLifeAPI.World.Base;
using MagicalLifeAPI.World.Data;
using System;
using System.Collections.Generic;

namespace MagicalLifeAPI.World
{
    /// <summary>
    /// Holds some utilities for world stuff.
    /// </summary>
    public static class WorldUtil
    {
        /// <summary>
        /// Returns a tile based on it's location in string format.
        /// </summary>
        /// <param name="world"></param>
        /// <param name="tiles"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Tile GetTileByID(ProtoArray<Tile> tiles, string str)
        {
            int x = 0;
            int y = 0;

            string xstr = str;
            xstr = xstr.Replace("{X:", "");
            xstr = xstr.Replace(" Y:", ", ");
            xstr = xstr.Replace("}", "");

            string[] splits = xstr.Split(new string[] { "," }, System.StringSplitOptions.RemoveEmptyEntries);
            x = int.Parse(splits[0]);
            y = int.Parse(splits[1]);

            return tiles[x, y];
        }

        /// <summary>
        /// Returns all the tiles that neighbor the specified tile.
        /// </summary>
        /// <returns></returns>
        public static List<Point2D> GetNeighboringTiles(Point2D tileLocation, int dimension)
        {
            List<Point2D> neighborCandidates = new List<Point2D>();
            List<Point2D> neighbors = new List<Point2D>();

            neighborCandidates.Add(new Point2D(tileLocation.X + 1, tileLocation.Y));
            neighborCandidates.Add(new Point2D(tileLocation.X - 1, tileLocation.Y));
            neighborCandidates.Add(new Point2D(tileLocation.X, tileLocation.Y + 1));
            neighborCandidates.Add(new Point2D(tileLocation.X, tileLocation.Y - 1));
            neighborCandidates.Add(new Point2D(tileLocation.X + 1, tileLocation.Y + 1));
            neighborCandidates.Add(new Point2D(tileLocation.X + 1, tileLocation.Y - 1));
            neighborCandidates.Add(new Point2D(tileLocation.X - 1, tileLocation.Y + 1));
            neighborCandidates.Add(new Point2D(tileLocation.X - 1, tileLocation.Y - 1));

            foreach (Point2D item in neighborCandidates)
            {
                if (DoesTileExist(item, dimension))
                {
                    neighbors.Add(item);
                }
            }

            return neighbors;
        }

        /// <summary>
        /// Determines if the specified location is actually a tile in the current map.
        /// </summary>
        /// <param name="tileLocation"></param>
        /// <returns></returns>
        public static bool DoesTileExist(Point2D tileLocation, int dimension)
        {
            return World.Data.World.Dimensions[dimension].DoesTileExist(tileLocation.X, tileLocation.Y);
        }

        /// <summary>
        /// Determines what chunk a map location is part of, and returns the chunk coordinates of that chunk.
        /// </summary>
        /// <param name="mapLocation"></param>
        /// <returns></returns>
        public static Point2D CalculateChunkLocation(Point2D mapLocation)
        {
            int x = mapLocation.X / Chunk.Width;
            int y = mapLocation.Y / Chunk.Height;

            return new Point2D(x, y);
        }

        /// <summary>
        /// Gets a tile from a chunk via its map location.
        /// </summary>
        /// <param name="mapLocation">The location of the tile.</param>
        /// <param name="chunk">The chunk the tile is within.</param>
        /// <returns></returns>
        public static Tile GetTile(Point2D mapLocation, Chunk chunk)
        {
            int x = mapLocation.X % Chunk.Width;
            int y = mapLocation.Y % Chunk.Height;

            return chunk.Tiles[x, y];
        }

        /// <summary>
        /// Finds a random location that can be walked upon by a creature.
        /// </summary>
        /// <param name="dimension"></param>
        /// <returns></returns>
        public static Point2D FindRandomLocation(int dimension)
        {
            Dimension dim = World.Data.World.Dimensions[dimension];

            //The coordinates of the random chunk
            int randomChunkX = StaticRandom.Rand(0, dim.Width);
            int randomChunkY = StaticRandom.Rand(0, dim.Height);

            //The coordinates of the tile within the chunk
            int randomX = StaticRandom.Rand(0, Chunk.Width);
            int randomY = StaticRandom.Rand(0, Chunk.Height);

            //The map coordinates of where to spawn the creature.
            int x = (randomChunkX * Chunk.Width) + randomX;
            int y = (randomChunkY * Chunk.Height) + randomY;

            if (dim[x, y].IsWalkable)
            {
                return new Point2D(x, y);
            }
            else
            {
                return WorldUtil.FindRandomLocation(dimension);
            }
        }

        /// <summary>
        /// Spawns a character at a random position in the map without spawning the character in the same space as another character.
        /// </summary>
        /// <param name="playerID"></param>
        public static void SpawnRandomCharacter(Guid playerID, int dimension)
        {
            Point2D randomLocation = FindRandomLocation(dimension);

            HumanFactory humanFactory = new HumanFactory();
            Human human = humanFactory.GenerateHuman(randomLocation, dimension, playerID);

            World.Data.World.GetChunkByTile(dimension, randomLocation.X, randomLocation.Y).Creatures.Add(human.ID, human);

            if (World.Data.World.Mode == Networking.EngineMode.ServerOnly)
            {
                ServerSendRecieve.SendAll(new WorldModifierMessage(new LivingCreatedModifier(human)));
            }
        }

        /// <summary>
        /// Returns the creature at the specified point.
        /// Returns null if it is not at the specified location.
        /// </summary>
        /// <param name="tileLocation"></param>
        /// <returns></returns>
        public static Living GetCreature(Point2D tileLocation, int dimension)
        {
            Chunk chunk = Data.World.GetChunkByTile(dimension, tileLocation.X, tileLocation.Y);
            chunk.GetCreature(tileLocation, out Living creature);
            return creature;
        }
    }
}