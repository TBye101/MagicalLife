using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MagicalLifeAPI.Pathfinding
{
    /// <summary>
    /// Handles who finds the path to destinations.
    /// </summary>
    public static class MainPathFinder
    {
        /// <summary>
        /// The pathfinder.
        /// </summary>
        private static IPathFinder PFinder = new AStar.AStar();

        private static List<IPathFinder> PathFinders = new List<IPathFinder>();

        public static void Initialize()
        {
            World.Data.World.WorldGenerated += World_WorldGenerated;
        }

        private static void World_WorldGenerated(object sender, World.WorldEventArgs e)
        {
            PFinder.Initialize();
        }

        public static List<PathLink> GetRoute(int dimension, Point start, Point end)
        {

        }
    }
}