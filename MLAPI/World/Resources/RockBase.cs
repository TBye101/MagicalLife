using MLAPI.Components.Resource;
using MLAPI.World.Base;
using ProtoBuf;

namespace MLAPI.World.Resources
{
    /// <summary>
    /// The base class for all stone-like resources.
    /// </summary>
    [ProtoContract]
    public abstract class RockBase : Resource
    {
        protected RockBase(string name, int durability, ComponentHarvestable harvestBehavior)
            : base(name, durability, harvestBehavior, false)
        {
        }

        protected RockBase()
        {
        }
    }
}