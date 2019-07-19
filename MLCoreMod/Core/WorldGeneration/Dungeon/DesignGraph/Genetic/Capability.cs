using System;
using System.Collections.Generic;
using System.Text;

namespace MLCoreMod.Core.WorldGeneration.Dungeon.DesignGraph.Genetic
{
    /// <summary>
    /// Represents a capability of the generator.
    /// </summary>
    public abstract class Capability
    {
        /// <summary>
        /// Should generate the capability with random state values.
        /// </summary>
        /// <returns></returns>
        public abstract void SetRandomStats();

        /// <summary>
        /// When called the capability must decide whether or not to have an effect upon the node.
        /// </summary>
        /// <param name="node"></param>
        public abstract void Activate(DungeonNode node);

        /// <summary>
        /// Used to determine if two capabilities are of the same type/gene type.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public abstract bool SameGeneType(Capability other);

        /// <summary>
        /// Perform a mutation of some sort onto this capability.
        /// </summary>
        public abstract void Mutate();
    }
}