using MagicalLifeAPI.Entities;
using MagicalLifeAPI.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalLifeAPI.Pathfinding.Cost
{
    /// <summary>
    /// Each implementer of this can add movement cost to the transition between two tiles. 
    /// The cost of many of these are used to determine the movement cost between moving between two tiles.
    /// </summary>
    public interface IAddMovementCost
    {
        /// <summary>
        /// Returns the additional cost of the living creature moving between points 'a' and 'b' due to some rule this knows about.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="living"></param>
        /// <returns></returns>
        Int32 GetMovementCost(Tile start, Tile end, Living living);
    }
}
