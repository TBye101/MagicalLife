using MagicalLifeAPI.Entities;
using MagicalLifeAPI.Universal;
using Microsoft.Xna.Framework;
using ProtoBuf;

namespace MagicalLifeAPI.GUI
{
    /// <summary>
    /// All objects in the game that can be clicked on inherit from this.
    /// </summary>
    [ProtoBuf.ProtoContract]
    [ProtoBuf.ProtoInclude(2, typeof(Living))]
    public abstract class Selectable : Unique
    {
        /// <summary>
        /// This returns a <see cref="SelectionType"/> so we can differentiate between the catagories of various in game objects.
        /// Ex: An item such as wood would be considered the same as another type of item, but creatures are not the same as wood.
        /// </summary>
        /// <param name="selectable"></param>
        /// <returns></returns>
        public abstract SelectionType InGameObjectType(Selectable selectable);

        /// <summary>
        /// The location of this selectable in game object.
        /// </summary>
        [ProtoMember(1)]
        public Point MapLocation { get; set; }
    }
}