using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entity;
using MagicalLifeAPI.World.Base;
using ProtoBuf;

namespace MagicalLifeAPI.GUI
{
    /// <summary>
    /// All objects in the game that can be clicked on inherit from this.
    /// </summary>
    [ProtoContract]
    [ProtoInclude(2, typeof(Living))]
    [ProtoInclude(3, typeof(Tile))]
    public abstract class Selectable
    {
        /// <summary>
        /// This returns a <see cref="SelectionType"/> so we can differentiate between the categories of various in game objects.
        /// Ex: An item such as wood would be considered the same as another type of item, but creatures are not the same as wood.
        /// </summary>
        /// <param name="selectable"></param>
        /// <returns></returns>
        public abstract SelectionType InGameObjectType(Selectable selectable);

        /// <summary>
        /// The location of this selectable in game object.
        /// </summary>
        [ProtoMember(1)]
        public Point2D MapLocation { get; set; }
    }
}