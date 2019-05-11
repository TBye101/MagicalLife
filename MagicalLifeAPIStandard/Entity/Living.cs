using MagicalLifeAPI.Components;
using MagicalLifeAPI.Components.Entity;
using MagicalLifeAPI.Components.Generic.Renderable;
using MagicalLifeAPI.DataTypes;
using MagicalLifeAPI.DataTypes.Attribute;
using MagicalLifeAPI.Entity.AI.Task;
using MagicalLifeAPI.Entity.Eventing;
using MagicalLifeAPI.Entity.Skills;
using MagicalLifeAPI.GUI;
using MagicalLifeAPI.Pathfinding;
using MagicalLifeAPI.Util.Reusable;
using ProtoBuf;
using System;
using System.Collections.Generic;

namespace MagicalLifeAPI.Entity
{
    /// <summary>
    /// All living things inherit from this, and utilize it.
    /// </summary>
    [ProtoContract]
    public abstract class Living : HasComponents
    {
        /// <summary>
        /// How many hit Point2Ds this creature has.
        /// </summary>
        [ProtoMember(2)]
        public Attribute32 Health { get; set; }

        /// <summary>
        /// The dimension that this creature is in.
        /// </summary>
        [ProtoMember(5)]
        public int Dimension { get; set; }

        [ProtoMember(6)]
        public MagicalTask Task { get; set; }

        /// <summary>
        /// The ID of the player that this creature belongs to.
        /// </summary>
        [ProtoMember(7)]
        public Guid PlayerID { get; set; }

        [ProtoMember(10)]
        public Guid ID { get; }

        [ProtoMember(11)]
        public abstract AbstractVisual Visual { get; set; }

        [ProtoMember(12)]
        public List<Skill> CreatureSkills { get; set; }

        [ProtoMember(13)]
        public string CreatureTypeName { get; set; }

        [ProtoMember(14)]
        public string CreatureName { get; set; }

        [ProtoMember(15)]
        public Inventory Inventory { get; set; }

        /// <summary>
        /// Raised when a <see cref="Living"/> is created.
        /// </summary>
        public static event EventHandler<LivingEventArg> LivingCreated;

        /// <summary>
        /// Raised when this <see cref="Living"/> is modified.
        /// </summary>
        public event EventHandler<LivingEventArg> LivingModified;

        /// <summary>
        ///
        /// </summary>
        /// <param name="health"></param>
        /// <param name="movementSpeed"></param>
        /// <param name="location"></param>
        /// <param name="dimension"></param>
        /// <param name="playerID"></param>
        /// <param name="creatureTypeName">The name of our creature's type. Ex: Lion, Human, Robot.</param>
        /// <param name="creatureName">The name of this specific creature.</param>
        protected Living(int health, double movementSpeed, Point2D location,
            int dimension, Guid playerID, string creatureTypeName, string creatureName)
            : base(true)
        {
            this.AddComponent(new ComponentSelectable(SelectionType.Creature));
            this.AddComponent(new ComponentMovement(movementSpeed, location));

            this.ID = Guid.NewGuid();
            this.PlayerID = playerID;
            this.Initialize(health, movementSpeed, location, dimension);
            this.CreatureSkills = new List<Skill>();
            this.CreatureTypeName = creatureTypeName;
            this.CreatureName = creatureName;
            this.Inventory = new Inventory(true);
        }

        protected Living()
        {
        }

        protected void Initialize(int health, double movementSpeed, Point2D location, int dimension)
        {
            this.Health = new Attribute32(health);
            this.GetExactComponent<ComponentSelectable>().MapLocation = location;
            this.Dimension = dimension;
            LivingCreatedHandler(new LivingEventArg(this, location));
        }

        public void AssignTask(MagicalTask task)
        {
            this.Task = task;
            this.Task.Completed += this.Task_Completed;
        }

        private void Task_Completed(MagicalTask task)
        {
            this.Task = null;
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
    }
}