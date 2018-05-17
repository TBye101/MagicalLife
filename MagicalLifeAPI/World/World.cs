using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Filing.Logging;
using MagicalLifeAPI.Networking.Messages;
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
        public ProtoArray<Tile> Tiles { get; set; }

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

        public static World MainWorld { get; set; }

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
            MainWorld = new World();
            MainWorld.Tiles = MainWorld.GenerateWorld(height, width, generator);

            WorldEventArgs worldEventArgs = new WorldEventArgs(MainWorld);
            MainWorld.WorldGeneratedHandler(worldEventArgs);
            //Pathfinding.MainPathFinder.PFinder.Initialize();
            //ServerSendRecieve.SendAll<WorldTransferMessage>(new WorldTransferMessage(World.MainWorld));

            World.TurnStartHandler(new WorldEventArgs(MainWorld));
        }

        /// <summary>
        /// Actually handles generating the world.
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="depth"></param>
        /// <param name="generator"></param>
        /// <returns></returns>
        private ProtoArray<Tile> GenerateWorld(int height, int width, WorldGenerator generator)
        {
            Random r = new Random();
            string[,] stage1 = generator.AssignBiomes(height, width, r);
            ProtoArray<Tile> stage2 = generator.GenerateLandType(stage1, r);

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
            TurnEndHandler(new WorldEventArgs(MainWorld));
            TurnStartHandler(new WorldEventArgs(MainWorld));
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
                handler(World.MainWorld, e);
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
                handler(World.MainWorld, e);
            }
        }
    }
}