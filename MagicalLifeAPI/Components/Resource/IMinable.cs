using ProtoBuf;

namespace MagicalLifeAPI.Components.Resource
{
    /// <summary>
    /// Used to hold a <see cref="AbstractMinable"/> component.
    /// </summary>
    [ProtoContract]
    public interface IMinable
    {
        [ProtoMember(1)]
        AbstractMinable MiningBehavior { get; set; }
    }
}
