using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.Universal;
using ProtoBuf;
using System;

namespace MagicalLifeAPI.World
{
    /// <summary>
    /// The world, which contains all of the tiles.
    /// </summary>
    [ProtoContract]
    public class World : Unique
    {
        /// <summary>
        /// A 3D array that holds every tile in the current world.
        /// </summary>
        [ProtoMember(1)]
        public Tile[,] Tiles { get; set; }

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

        public static World mainWorld { get; set; }

        /// <summary>
        /// If true, it is the player's turn. If not, AI logic and other logic should be running.
        /// </summary>
        [ProtoMember(2)]
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
            Pathfinding.MainPathFinder.PFinder.Initialize();

            World.TurnStartHandler(new WorldEventArgs(mainWorld));
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