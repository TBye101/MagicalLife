using MagicalLifeAPI.Universal;
using ProtoBuf;

namespace MagicalLifeAPI.World.Base
{
    /// <summary>
    /// Represents almost everything in a movable/harvested form.
    /// </summary>
    [ProtoContract]
    public abstract class Item : Unique
    {
        /// <summary>
        /// The name of this <see cref="Item"/>;
        /// </summary>
        [ProtoMember(1)]
        public string Name { get; }
    }
}