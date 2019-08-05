using MLAPI.Components.Resource;
using MLAPI.World.Base;
using ProtoBuf;

namespace MLAPI.World.Resources
{
    /// <summary>
    /// A base class for all trees.
    /// </summary>
    [ProtoContract]
    public abstract class TreeBase : Vegetation
    {
        protected TreeBase(string name, int durability, ComponentHarvestable harvestBehavior)
            : base(name, durability, harvestBehavior, true)
        {
        }

        protected TreeBase()
        {
        }
    }
}