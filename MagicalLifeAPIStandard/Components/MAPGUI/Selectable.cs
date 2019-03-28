using MagicalLifeAPI.Components;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entity;
using MagicalLifeAPI.World.Base;
using ProtoBuf;
using System;

namespace MagicalLifeAPI.GUI
{
    /// <summary>
    /// All objects in the game that can be clicked on inherit from this.
    /// </summary>
    [ProtoContract]
    public sealed class Selectable : Component
    {
        [ProtoMember(1)]
        private readonly SelectionType Type;

        /// <summary>
        /// The location of this selectable in game object.
        /// </summary>
        [ProtoMember(2)]
        public Point2D MapLocation { get; set; }

        /// <param name="type">The map selection type to use for the containing object.</param>
        public Selectable(SelectionType type)
        {
            this.Type = type;
        }

        private Selectable()
        {
            //Protobuf-net constructor.
        }

        /// <summary>
        /// This returns a <see cref="SelectionType"/> so we can differentiate between the categories of various in game objects.
        /// Ex: An item such as wood would be considered the same as another type of item, but creatures are not the same as wood.
        /// </summary>
        /// <param name="selectable"></param>
        /// <returns></returns>
        public SelectionType InGameObjectType(Selectable selectable)
        {
            return this.Type;
        }
    }
}