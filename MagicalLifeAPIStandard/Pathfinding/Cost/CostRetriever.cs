using MagicalLifeAPI.Entity;
using MagicalLifeAPI.World.Base;
using System.Collections.Generic;

namespace MagicalLifeAPI.Pathfinding.Cost
{
    /// <summary>
    /// Handles all rules involving the costs of moving between two tiles.
    /// </summary>
    public static class CostRetriever
    {
        /// <summary>
        /// Contains all of the rules that collectively calculate the movement cost between two tiles.
        /// </summary>
        private static List<IAddMovementCost> MovementCostRules = new List<IAddMovementCost>();

        public static void AddMovementCostRule(IAddMovementCost rule)
        {
            MovementCostRules.Add(rule);
        }

        public static void RemoveMovementCostRule(IAddMovementCost rule)
        {
            MovementCostRules.Remove(rule);
        }

        /// <summary>
        /// Returns the total cost of moving between two tiles.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="mover">The creature that would move between the two tiles.</param>
        /// <returns>If the return value is -1, then the end tile cannot be moved into.</returns>
        public static int CalculateMovementCost(Tile start, Tile end, Living mover)
        {
            int total = 0;

            foreach (IAddMovementCost item in MovementCostRules)
            {
                total += item.GetMovementCost(start, end, mover);
            }

            return total;
        }
    }
}