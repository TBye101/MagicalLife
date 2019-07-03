using MagicalLifeAPI.Components;
using MagicalLifeAPI.DataTypes;
using ProtoBuf;

namespace MagicalLifeAPI.GUI
{
    /// <summary>
    /// All objects in the game that can be clicked have this.
    /// </summary>
    [ProtoContract]
    public sealed class ComponentSelectable : Component
    {
        [ProtoMember(1)]
        private readonly SelectionType Type;

        /// <summary>
        /// The location of this selectable in game object.
        /// </summary>
        [ProtoMember(2)]
        public Point3D MapLocation { get; set; }

        [ProtoMember(3)]
        public int Dimension { get; set; }

        /// <param name="type">The map selection type to use for the containing object.</param>
        public ComponentSelectable(SelectionType type)
        {
            this.Type = type;
        }

        private ComponentSelectable()
        {
            //Protobuf-net constructor.
        }

        /// <summary>
        /// This returns a <see cref="SelectionType"/> so we can differentiate between the categories of various in game objects.
        /// Ex: An item such as wood would be considered the same as another type of item, but creatures are not the same as wood.
        /// </summary>
        /// <param name="selectable"></param>
        /// <returns></returns>
        public SelectionType InGameObjectType()
        {
            return this.Type;
        }
    }
}