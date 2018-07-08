using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.DataTypes.Attribute;
using MagicalLifeAPI.Entities.Eventing;
using MagicalLifeAPI.Entities.Util;
using MagicalLifeAPI.GUI;
using MagicalLifeAPI.Networking;
using MagicalLifeAPI.Pathfinding;
using Microsoft.Xna.Framework;
using ProtoBuf;
using System;
using System.Collections.Generic;

namespace MagicalLifeAPI.Entities
{
    /// <summary>
    /// All living things inherit from this, and utilize it.
    /// </summary>
    [ProtoContract]
    public abstract class Living : Selectable, IHasSubclasses
    {
        /// <summary>
        /// A queue that holds the queued movement steps up for this living creature.
        /// </summary>
        [ProtoMember(1)]
        public ProtoQueue<PathLink> QueuedMovement { get; set; } = new ProtoQueue<PathLink>();

        /// <summary>
        /// How many hit points this creature has.
        /// </summary>
        [ProtoMember(2)]
        public Attribute32 Health { get; set; }

        /// <summary>
        /// How fast this creature can during a single tick.
        /// </summary>
        [ProtoMember(3)]
        public AttributeFloat Movement { get; set; }

        /// <summary>
        /// The location of the creature on the screen. This represents the progress through a tile for a moving creature.
        /// </summary>
        [ProtoMember(4)]
        public PointFloat ScreenLocation { get; set; }

        /// <summary>
        /// The dimension that this creature is in.
        /// </summary>
        [ProtoMember(5)]
        public int Dimension { get; set; }

        /// <summary>
        /// Raised when a <see cref="Living"/> is created.
        /// </summary>
        public static event EventHandler<LivingEventArg> LivingCreated;

        /// <summary>
        /// Raised when this <see cref="Living"/> is modified.
        /// </summary>
        public event EventHandler<LivingEventArg> LivingModified;

        /// <summary>
        /// Initializes a new instance of the <see cref="Living"/> base class.
        /// </summary>
        /// <param name="health"></param>
        /// <param name="movementSpeed"></param>
        protected Living(int health, float movementSpeed, Point location, int dimension)
        {
            this.Health = new Util.Attribute32(health);
            this.Movement = new AttributeFloat(movementSpeed);
            this.MapLocation = location;
            this.ScreenLocation = new PointFloat(location.X, location.Y);
            this.Dimension = dimension;
            Living.LivingCreatedHandler(new LivingEventArg(this, location));
        }

        public Living()
        {
        }

        /// <summary>
        /// Returns the name of the texture.
        /// </summary>
        /// <returns></returns>
        public abstract string GetTextureName();

        /// <summary>
        /// Raises the <see cref="LivingModified"/> event.
        /// </summary>
        /// <param name="e"></param>
        public void LivingModifiedHandler(LivingEventArg e)
        {
            LivingModified?.Invoke(e.Living, e);
        }

        /// <summary>
        /// Raises the <see cref="LivingCreated"/> event.
        /// </summary>
        /// <param name="e"></param>
        public static void LivingCreatedHandler(LivingEventArg e)
        {
            LivingCreated?.Invoke(e.Living, e);
        }

        public Dictionary<Type, int> GetSubclassInformation()
        {
            return new Dictionary<Type, int>()
            {
                { typeof(Humanoid.Human), 999}
            };
        }

        public Type GetBaseType()
        {
            return typeof(Living);
        }
    }
}