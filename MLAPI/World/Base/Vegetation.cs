using MLAPI.Components.Resource;
using ProtoBuf;

namespace MLAPI.World.Base
{
    /// <summary>
    /// A base class used by anything that can grow, and is alive.
    /// </summary>
    [ProtoContract]
    public abstract class Vegetation : Resource
    {
        /// <summary>
        /// Default growth rate of all vegetation
        /// </summary>
        /// <remarks>
        /// Override on derived class to change default for specific plants.
        /// </remarks>
        [ProtoMember(1)]
        protected int GrowthRate { get; set; } = 20;

        /// <summary>
        /// The constructor for <see cref="Vegetation"/>.
        /// </summary>
        /// <param name="name">The name of this vegetation.</param>
        protected Vegetation(string name, int durability, ComponentHarvestable harvestBehavior, bool walkable)
            : base(name, durability, harvestBehavior, walkable)
        {
        }

        /// <summary>
        /// The constructor for <see cref="Vegetation"/>.
        /// </summary>
        /// <param name="name">The name of this vegetation.</param>
        protected Vegetation()
        {
        }
    }
}