using MagicalLifeAPI.Entity;
using MagicalLifeAPI.World.Base;
using System;

namespace MagicalLifeAPI.Pathfinding.Cost
{
    /// <summary>
    /// Each implementer of this can add movement cost to the transition between two tiles.
    /// The cost of many of these are used to determine the movement cost between moving between two tiles.
    /// </summary>
    public interface IAddMovementCost
    {
        /// <summary>
        /// Returns the additional cost of the living creature moving between Point2Ds 'a' and 'b' due to some rule this knows about.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="mover"></param>
        /// <returns></returns>
        Int32 GetMovementCost(Tile start, Tile end, Living mover);
    }
}