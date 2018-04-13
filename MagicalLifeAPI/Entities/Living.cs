using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.Entities.Eventing;
using MagicalLifeAPI.Entities.Movement;
using MagicalLifeAPI.Entities.Util;
using MagicalLifeAPI.GUI;
using MagicalLifeAPI.Pathfinding;
using MagicalLifeAPI.Universal;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace MagicalLifeAPI.Entities
{
    /// <summary>
    /// All living things inherit from this, and utilize it.
    /// </summary>
    public abstract class Living : Selectable
    {
        /// <summary>
        /// A queue that holds the queued movement steps up for this living creature.
        /// </summary>
        public Queue<PathLink> QueuedMovement { get; set; } = new Queue<PathLink>();

        /// <summary>
        /// How many hit points this creature has.
        /// </summary>
        public Util.Attribute Health { get; set; }

        /// <summary>
        /// How fast this creature can move.
        /// </summary>
        public Util.Attribute MovementSpeed { get; set; }

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
        protected Living(int health, int movementSpeed, Point location)
        {
            this.Health = new Util.Attribute(health);
            this.MovementSpeed = new Util.Attribute(movementSpeed);
            Living.LivingCreated(this, new LivingEventArg(this, location));
            this.MapLocation = location;
            World.World.TurnEnd += this.World_TurnEnd;
        }

        private void World_TurnEnd(object sender, World.WorldEventArgs e)
        {
            Living l = this;
            EntityWorldMovement.MoveEntity(ref l);
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
            EventHandler<LivingEventArg> handler = LivingModified;
            if (handler != null)
            {
                handler(e.Living, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="LivingCreated"/> event.
        /// </summary>
        /// <param name="e"></param>
        public static void LivingCreatedHandler(LivingEventArg e)
        {
            EventHandler<LivingEventArg> handler = LivingCreated;
            if (handler != null)
            {
                handler(e.Living, e);
            }
        }
    }
}