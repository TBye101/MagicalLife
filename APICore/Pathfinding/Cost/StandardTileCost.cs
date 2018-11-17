using MagicalLifeAPI.Entity;
using MagicalLifeAPI.World.Base;

namespace MagicalLifeAPI.Pathfinding.Cost
{
    /// <summary>
    /// The normal cost for moving between tiles. No special rules here.
    /// </summary>
    public class StandardTileCost : IAddMovementCost
    {
        public int GetMovementCost(Tile start, Tile end, Living mover)
        {
            return end.MovementCost;
        }
    }
}