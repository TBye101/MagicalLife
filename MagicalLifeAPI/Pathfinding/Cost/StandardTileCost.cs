using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicalLifeAPI.Entities;
using MagicalLifeAPI.World;

namespace MagicalLifeAPI.Pathfinding.Cost
{
    /// <summary>
    /// The normal cost for moving between tiles. No special rules here.
    /// </summary>
    public class StandardTileCost : IAddMovementCost
    {
        public int GetMovementCost(Tile start, Tile end, Living living)
        {
            return end.MovementCost;
        }
    }
}
