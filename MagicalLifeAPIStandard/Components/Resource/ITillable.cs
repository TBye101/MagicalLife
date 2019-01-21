using ProtoBuf;

namespace MagicalLifeAPI.Components.Resource
{
    /// <summary>
    /// Used to hold a <see cref="AbstractTillable"/> component.
    /// </summary>
    [ProtoContract]
    public interface ITillable
    {
        [ProtoMember(1)]
        AbstractTillable TillableBehavior { get; set; }
    }
}