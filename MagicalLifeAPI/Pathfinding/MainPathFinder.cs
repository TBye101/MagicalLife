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
        public static IPathFinder PFinder = new AStar.AStar();

        public static void Initialize()
        {
            World.Data.World.WorldGenerated += World_WorldGenerated;
        }

        private static void World_WorldGenerated(object sender, World.WorldEventArgs e)
        {
            PFinder.Initialize();
        }
    }
}