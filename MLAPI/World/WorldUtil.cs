using System;
using System.Collections.Generic;
using System.Linq;
using MLAPI.DataTypes;
using MLAPI.DataTypes.Collection;
using MLAPI.Entity;
using MLAPI.Entity.Entity_Factory;
using MLAPI.Entity.Humanoid;
using MLAPI.Networking.Messages;
using MLAPI.Networking.Server;
using MLAPI.Networking.World.Modifiers;
using MLAPI.Util.RandomUtils;
using MLAPI.World.Base;
using MLAPI.World.Data;
using Dimension = MLAPI.World.Data.Dimension;

namespace MLAPI.World
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
        public static Tile GetTileById(ProtoArray<Tile> tiles, string str)
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
        public static List<Point2D> GetNeighboringTiles(Point2D tileLocation, Guid dimensionId)
        {
            List<Point2D> neighbors = new List<Point2D>
            {
                new Point2D(tileLocation.X + 1, tileLocation.Y),
                new Point2D(tileLocation.X - 1, tileLocation.Y),
                new Point2D(tileLocation.X, tileLocation.Y + 1),
                new Point2D(tileLocation.X, tileLocation.Y - 1),
                new Point2D(tileLocation.X + 1, tileLocation.Y + 1),
                new Point2D(tileLocation.X + 1, tileLocation.Y - 1),
                new Point2D(tileLocation.X - 1, tileLocation.Y + 1),
                new Point2D(tileLocation.X - 1, tileLocation.Y - 1)
            };


            for (int i = neighbors.Count - 1; i > -1; i--)
            {
                if (!DoesTileExist(neighbors[i], dimensionId))
                {
                    neighbors.RemoveAt(i);
                }
            }

            return neighbors;
        }

        public static List<Point3D> GetNeighboringTiles(Point3D tileLocation)
        {
            List<Point3D> neighbors = new List<Point3D>
            {
                new Point3D(tileLocation.X + 1, tileLocation.Y, tileLocation.DimensionId),
                new Point3D(tileLocation.X - 1, tileLocation.Y, tileLocation.DimensionId),
                new Point3D(tileLocation.X, tileLocation.Y + 1, tileLocation.DimensionId),
                new Point3D(tileLocation.X, tileLocation.Y - 1, tileLocation.DimensionId),
                new Point3D(tileLocation.X + 1, tileLocation.Y + 1, tileLocation.DimensionId),
                new Point3D(tileLocation.X + 1, tileLocation.Y - 1, tileLocation.DimensionId),
                new Point3D(tileLocation.X - 1, tileLocation.Y + 1, tileLocation.DimensionId),
                new Point3D(tileLocation.X - 1, tileLocation.Y - 1, tileLocation.DimensionId)
            };


            for (int i = neighbors.Count - 1; i > -1; i--)
            {
                if (!DoesTileExist(neighbors[i], tileLocation.DimensionId))
                {
                    neighbors.RemoveAt(i);
                }
            }

            return neighbors;
        }

        /// <summary>
        /// Determines if the specified location is actually a tile in the current map.
        /// </summary>
        public static bool DoesTileExist(Point2D tileLocation, Guid dimensionId)
        {
            return DoesTileExist(Point3D.From2D(tileLocation, dimensionId));
        }

        /// <summary>
        /// Determines if the specified location is actually a tile in the current map.
        /// </summary>
        public static bool DoesTileExist(Point3D tileLocation)
        {
            Data.World.Dimensions.TryGetValue(tileLocation.DimensionId, out Dimension dimension);
            if (dimension == null)
            {
                return false;
            }
            else
            {
                return dimension.DoesTileExist(tileLocation.X, tileLocation.Y);
            }

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
        /// Calculates the location within its corresponding chunk that the tile location is at.
        /// </summary>
        /// <param name="tileLocation"></param>
        /// <returns></returns>
        public static Point2D CalculateTileLocationInChunk(Point2D tileLocation)
        {
            int x = tileLocation.X % Chunk.Width;
            int y = tileLocation.Y % Chunk.Height;

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
        public static Point3D FindRandomLocation(Guid dimensionId)
        {
            Dimension dim = Data.World.Dimensions[dimensionId];

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
                return new Point3D(x, y, dimensionId);
            }
            else
            {
                return FindRandomLocation(dimensionId);
            }
        }

        /// <summary>
        /// Spawns a character at a random position in the map without spawning the character in the same space as another character.
        /// </summary>
        /// <param name="playerId"></param>
        public static void SpawnRandomCharacter(Guid playerId, Guid dimensionId)
        {
            Point3D randomLocation = FindRandomLocation(dimensionId);

            HumanFactory humanFactory = new HumanFactory();
            Human human = humanFactory.GenerateHuman(randomLocation, dimensionId, playerId);

            Data.World.GetChunkByTile(dimensionId, randomLocation.X, randomLocation.Y).Creatures.Add(human.Id, human);

            if (Data.World.Mode == Networking.EngineMode.ServerOnly)
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
        public static Living GetCreature(Point3D tileLocation)
        {
            Chunk chunk = Data.World.GetChunkByTile(tileLocation.DimensionId, tileLocation.X, tileLocation.Y);
            chunk.GetCreature(tileLocation, out Living creature);
            return creature;
        }

        /// <summary>
        /// Determines if a player has a character within the world somewhere.
        /// </summary>
        /// <returns></returns>
        public static bool PlayerHasCharacter(Guid playerId)
        {
            foreach (KeyValuePair<Guid, Dimension> item in Data.World.Dimensions)
            {
                for (int x = 0; x < item.Value.Width; x++)
                {
                    for (int y = 0; y < item.Value.Height; y++)
                    {
                        Chunk chunk = item.Value.GetChunk(x, y);
                        if (chunk.Creatures.Any(living => living.Value.PlayerId.Equals(playerId)))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Gets the location of the top left/first tile coordinate from the specified chunk coordinate.
        /// </summary>
        /// <param name="chunkCoordinate"></param>
        /// <returns></returns>
        public static Point2D GetFirstTileLocation(Point2D chunkCoordinate)
        {
            return new Point2D(chunkCoordinate.X * Chunk.Width, chunkCoordinate.Y * Chunk.Height);
        }

        /// <summary>
        /// Gets the location of the bottom right/last tile coordinate from the specified chunk coordinate.
        /// </summary>
        /// <param name="chunkCoordinate"></param>
        /// <returns></returns>
        public static Point2D GetLastTileLocation(Point2D chunkCoordinate)
        {
            Point2D first = GetFirstTileLocation(chunkCoordinate);
            first.X += Chunk.Width - 1;
            first.Y += Chunk.Height - 1;
            return first;
        }

        /// <summary>
        /// Returns the dimension that has the specified name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static KeyValuePair<Guid, Dimension> GetDimensionByName(string name)
        {
            return World.Data.World.Dimensions.First(x => x.Value.DimensionName.Equals(name));
        }

        public static ProtoArray<Chunk> GenerateBlankChunks(int chunkWidth, int chunkHeight)
        {
            ProtoArray<Chunk> blank = new ProtoArray<Chunk>(chunkWidth, chunkHeight);

            for (int x = 0; x < chunkWidth; x++)
            {
                for (int y = 0; y < chunkHeight; y++)
                {
                    blank[x, y] = new Chunk(
                        new Dictionary<Guid, Living>(), new ProtoArray<Tile>(Chunk.Width, Chunk.Height), new Point2D(x, y));
                }
            }

            return blank;
        }
    }
}