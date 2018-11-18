using ProtoBuf;

namespace MagicalLifeAPI.Networking.World.Modifiers
{
    /// <summary>
    /// Implementers of this do operations on the world to change its state.
    /// </summary>
    [ProtoContract]
    [ProtoInclude(1, typeof(LivingCreatedModifier))]
    [ProtoInclude(2, typeof(ItemCreatedModifier))]
    [ProtoInclude(3, typeof(LivingLocationModifier))]
    public abstract class AbstractWorldModifier
    {
        public abstract void ModifyWorld();
    }
}