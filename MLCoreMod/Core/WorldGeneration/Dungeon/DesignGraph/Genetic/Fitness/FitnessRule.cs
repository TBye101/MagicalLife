using System;
using System.Collections.Generic;
using System.Text;

namespace MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph.Genetic.Fitness
{
    /// <summary>
    /// Used to assign points for following a specific dungeon design rule.
    /// </summary>
    public abstract class FitnessRule
    {
        /// <summary>
        /// Returns the total points possible for the current design graph.
        /// </summary>
        /// <returns></returns>
        public abstract double GetTotalPoints(DungeonNode graphStart);

        /// <summary>
        /// Returns the score of this design graph for this rule.
        /// </summary>
        /// <param name="graphStart"></param>
        /// <returns></returns>
        public abstract double GetCurrentPoints(DungeonNode graphStart);
    }
}
