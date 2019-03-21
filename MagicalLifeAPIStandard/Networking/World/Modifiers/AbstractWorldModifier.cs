using ProtoBuf;

namespace MagicalLifeAPI.Networking.World.Modifiers
{
    /// <summary>
    /// Implementers of this do operations on the world to change its state.
    /// </summary>
    [ProtoContract]
    public abstract class AbstractWorldModifier
    {
        public abstract void ModifyWorld();
    }
}