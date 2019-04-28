using MagicalLifeAPI.Components.Resource;
using MagicalLifeAPI.World.Base;
using ProtoBuf;

namespace MagicalLifeAPI.World.Resources
{
    /// <summary>
    /// A base class for all trees.
    /// </summary>
    [ProtoContract]
    public abstract class TreeBase : Vegetation
    {
        protected TreeBase(string name, int durability, ComponentHarvestable harvestBehavior)
            : base(name, durability, harvestBehavior)
        {
        }

        protected TreeBase() : base()
        {
        }
    }
}