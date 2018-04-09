using DijkstraAlgorithm.Pathing;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entities;
using MagicalLifeAPI.Entities.Movement;
using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.Universal;
using MagicalLifeAPI.Util;
using System;

namespace MagicalLifeAPI.World
{
    /// <summary>
    /// The world, which contains all of the tiles.
    /// </summary>
    public class World : Unique
    {
        /// <summary>
        /// A 3D array that holds every tile in the current world.
        /// </summary>
        public Tile[,] Tiles { get; private set; }

        /// <summary>
        /// Raised when the world is finished generating for the first time.
        /// </summary>
        public event EventHandler<WorldEventArgs> WorldGenerated;

        /// <summary>
        /// Raised at the start of each turn.
        /// </summary>
        public static event EventHandler<WorldEventArgs> TurnStart;

        /// <summary>
        /// Raised at the end of each turn.
        /// </summary>
        public static event EventHandler<WorldEventArgs> TurnEnd;

        public static World mainWorld { get; protected set; }

        /// <summary>
        /// If true, it is the player's turn. If not, AI logic and other logic should be running.
        /// </summary>
        public static bool IsPlayersTurn { get; private set; } = false;

        public World()
        {
        }

        /// <summary>
        /// Generates a new world with the specified height, width, depth, and world generator.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="depth"></param>
        /// <param name="generator"></param>
        public static void Initialize(int width, int height, WorldGenerator generator)
        {
            mainWorld = new World();
            mainWorld.Tiles = mainWorld.GenerateWorld(height, width, generator);

            WorldEventArgs worldEventArgs = new WorldEventArgs(mainWorld);
            mainWorld.WorldGeneratedHandler(worldEventArgs);
            StandardPathFinder.BuildPathGraph(mainWorld);

            World.TurnStartHandler(new WorldEventArgs(mainWorld));
        }

        private static Tile TestFindEntity(Tile[,,] tiles)
        {
            int xSize = tiles.GetLength(0);
            int ySize = tiles.GetLength(1);
            int zSize = tiles.GetLength(2);

            int x = 0;
            int y = 0;
            int z = 0;

            //Iterate over each row.
            for (int i = 0; i < xSize; i++)
            {
                //Iterate over each column
                for (int ii = 0; ii < ySize; ii++)
                {
                    //Iterate over the depth of each tile in the z axis.
                    for (int iii = 0; iii < zSize; iii++)
                    {
                        //Each tile can be accessed by the xyz coordinates from this inner loop properly.
                        if (tiles[x, y, z].Living != null)
                        {
                            return tiles[x, y, z];
                        }
                        z++;
                    }
                    y++;
                    z = 0;
                }
                y = 0;
                x++;
            }
            return null;
        }

        /// <summary>
        /// Actually handles generating the world.
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="depth"></param>
        /// <param name="generator"></param>
        /// <returns></returns>
        private Tile[,] GenerateWorld(int height, int width, WorldGenerator generator)
        {
            Random r = new Random();
            string[,] stage1 = generator.AssignBiomes(height, width, r);
            Tile[,] stage2 = generator.GenerateLandType(stage1, r);

            stage2 = generator.GenerateNaturalFeatures(stage2, r);
            stage2 = generator.GenerateMinerals(stage2, r);
            stage2 = generator.GenerateVegetation(stage2, r);
            stage2 = generator.GenerateDetails(stage2, r);

            return stage2;
        }

        public static void EndTurn()
        {
            MasterLog.DebugWriteLine("Turn ended!");
            //TestMove();
            TurnEndHandler(new WorldEventArgs(mainWorld));
            TurnStartHandler(new WorldEventArgs(mainWorld));
        }

        /// <summary>
        /// Raises the world generated event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void WorldGeneratedHandler(WorldEventArgs e)
        {
            EventHandler<WorldEventArgs> handler = WorldGenerated;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// Raises the world generated event.
        /// </summary>
        /// <param name="e"></param>
        public static void TurnStartHandler(WorldEventArgs e)
        {
            EventHandler<WorldEventArgs> handler = TurnStart;
            if (handler != null)
            {
                World.IsPlayersTurn = true;
                handler(World.mainWorld, e);
            }
        }

        /// <summary>
        /// Raises the world generated event.
        /// </summary>
        /// <param name="e"></param>
        public static void TurnEndHandler(WorldEventArgs e)
        {
            EventHandler<WorldEventArgs> handler = TurnEnd;
            if (handler != null)
            {
                World.IsPlayersTurn = false;
                handler(World.mainWorld, e);
            }
        }
    }
}