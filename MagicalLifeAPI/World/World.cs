using MagicalLifeAPI.Util;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.CompilerServices;
using DijkstraAlgorithm.Pathing;
using MagicalLifeAPI.Entities;
using MagicalLifeAPI.Entities.Movement;
using MagicalLifeAPI.Entities.Util;
using MagicalLifeAPI.Universal;
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
        public Tile[,,] Tiles { get; private set; }

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

        /// <summary>
        /// Generates a new world with the specified height, width, depth, and world generator.
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="depth"></param>
        /// <param name="generator"></param>
        public World(int width, int height, int depth, WorldGenerator generator)
        {
            this.Tiles = this.GenerateWorld(height, width, depth, generator);

            WorldEventArgs worldEventArgs = new WorldEventArgs(this);
            this.WorldGeneratedHandler(worldEventArgs);
            StandardPathFinder.BuildPathGraph(this);

            this.TurnStartHandler(new WorldEventArgs(this));
        }

        private void TestMove()
        {
            Living found = TestFindEntity(this.Tiles).Living[0];
            Tile start = TestFindEntity(this.Tiles);
            Path pth = StandardPathFinder.GetFastestPath(start, this.Tiles[10, 2, 1]);

            Extensions.EnqueueCollection(found.QueuedMovement, pth.Segments);
            World wrld = this;
            EntityWorldMovement.MoveEntity(ref found, ref wrld);
            this.Tiles = wrld.Tiles;
        }

        private Tile TestFindEntity(Tile[,,] tiles)
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
                        if (tiles[x, y, z].Living.Count > 0)
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
        private Tile[,,] GenerateWorld(int height, int width, int depth, WorldGenerator generator)
        {
            string[,,] stage1 = generator.AssignBiomes(height, width, depth);
            Tile[,,] stage2 = generator.GenerateLandType(stage1);

            stage2 = generator.GenerateNaturalFeatures(stage2);
            stage2 = generator.GenerateMinerals(stage2);
            stage2 = generator.GenerateVegetation(stage2);
            stage2 = generator.GenerateDetails(stage2);

            return stage2;
        }

        public void EndTurn()
        {
            this.TurnEndHandler(new WorldEventArgs(this));
            this.TurnStartHandler(new WorldEventArgs(this));
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
        protected virtual void TurnStartHandler(WorldEventArgs e)
        {
            EventHandler<WorldEventArgs> handler = TurnStart;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// Raises the world generated event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void TurnEndHandler(WorldEventArgs e)
        {
            EventHandler<WorldEventArgs> handler = TurnEnd;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}